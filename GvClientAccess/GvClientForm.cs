/**
 * Written by Cherng-Yann Ing.
 * 
 * Genius Vision NVR/CMS Client XML Communication Protocol Example.
 * 
 * For more information about Genius Vision products, visit http://geniusvision.net/
 * 
 * This source code is licensed under LGPL. (http://www.gnu.org/copyleft/lesser.html)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;

namespace GvClientAccess
{
    public partial class GvClientForm : Form
    {
        public GvClientForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private static string GetSHA1(string text)
        {
            UTF8Encoding UE = new UTF8Encoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            SHA1Managed hashString = new SHA1Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            return Convert.ToBase64String(hashValue);
        }

        delegate void MyDelegate();
        delegate void DeviceInfoDelegate(DeviceInfo di);
        XmlReader reader;
        Thread receiver;
        TcpClient client;

        class DeviceInfo
        {
            public String Name;
            public String Param;
            public String Value;
            public int Verb;
        }

        int eventCount = 1;

        void addEventDisplay(String type, String detail)
        {
            ListViewItem li = listView1.Items.Insert(0, Convert.ToString(eventCount++));
            li.SubItems.Add(type);
            li.SubItems.Add(detail);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addEventDisplay("Connection", "Connecting....");
            client = new TcpClient("192.168.0.124", 3557);
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Encoding = new UTF8Encoding(false);
            xws.ConformanceLevel = ConformanceLevel.Fragment;
            XmlWriter writer = XmlWriter.Create(client.GetStream(), xws);            
            writer.WriteStartElement("Login");
            writer.WriteAttributeString("UserName", "Handshake");
            writer.WriteAttributeString("Password", "7157d7fa-5f8b-44eb-946c-e05940fa3b0e");
            writer.WriteAttributeString("Pin", "CxClient");
            writer.WriteEndElement();
            writer.Flush();

            XmlReaderSettings xrs = new XmlReaderSettings();
            xrs.ConformanceLevel = ConformanceLevel.Fragment;
            reader = XmlReader.Create(client.GetStream(), xrs);
            reader.Read();
            Debug.Assert(reader.Name == "LoginResult" && reader["Status"] == "200" && reader["Message"]=="OK");
            writer.WriteStartElement("InitControlConnection");
            writer.WriteAttributeString("Cookie", Convert.ToString(DateTime.Now.ToFileTime()));
            writer.WriteStartElement("Com_LoginRequest");
            writer.WriteAttributeString("UserName", "admin");
            writer.WriteAttributeString("Password", GetSHA1("1234"));
            writer.WriteAttributeString("ClientVersion", "1");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();

            reader.Read();
            addEventDisplay("Connection", "Connected and authorized");
            receiver = new Thread(new ThreadStart(ReceiveThread));
            receiver.Start();
        }

        void OnDeviceInfo(DeviceInfo di)
        {
            addEventDisplay("DeviceInfo", "[" + di.Name + "] " + di.Param + "=>" + di.Value + ", Verb: " + Convert.ToString(di.Verb));
        }
        
        void ReceiveThread()
        {
            try
            {
                Trace.WriteLine("ReceiveThread().1");
                while (!reader.EOF)
                {
                    reader.Read();
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "DeviceInfo")
                            {
                                DeviceInfo di = new DeviceInfo();
                                di.Name = reader["Name"];
                                di.Param = reader["Param"];
                                di.Value = reader["Value"];
                                di.Verb = Convert.ToInt32(reader["Verb"]);
                                this.Invoke((DeviceInfoDelegate)OnDeviceInfo, di);
                            }
                            break;
                    }
                }
                Trace.WriteLine("ReceiveThread().2");
            }
            catch(ThreadAbortException err)
            {
                Trace.WriteLine("ReceiveThread() aborted: " + err);
            }
        }

        void Test2()
        {
            MessageBox.Show("Delegate!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Trace.WriteLine("Closing...");
            if (receiver != null)
            {
                receiver.Abort();
            }
        }
    }
}
