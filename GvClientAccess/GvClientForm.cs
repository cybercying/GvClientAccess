﻿/**
 * Written by Cherng-Yann Ing.
 * 
 * Genius Vision NVR/CMS Client XML Communication Protocol Example.
 * 
 * PLEASE NOTE: This sample code is by-no-means production code, but only used as a 
 * demonstration regarding how to establishing XML communication with Genius Vision 
 * NVR/CMS products. Therefore no warranty is provided. Use on your own risk.
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

using Microsoft.Win32;

namespace GvClientAccess
{
    public partial class GvClientForm : Form
    {
        RegistryKey rkey;

        public GvClientForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rkey = Registry.CurrentUser.CreateSubKey("Software\\GeniusVision\\Sample");
            edRemoteHost.Text = rkey.GetValue("RemoteHost", "192.168.0.124").ToString();
            edPort.Text = rkey.GetValue("Port", "3557").ToString();
            edUserName.Text = rkey.GetValue("UserName", "admin").ToString();
            edPassword.Text = rkey.GetValue("Password", "1234").ToString();
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
        delegate void EventDisplayDelegate(String type, String detail);
        XmlReader reader;
        Thread receiver;
        TcpClient client;
        XmlWriter writer;

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
            closeAll(true);
            rkey.SetValue("RemoteHost", edRemoteHost.Text);

            addEventDisplay("Connection", "Connecting to remote host: " + edRemoteHost.Text + ":");
            client = new TcpClient(edRemoteHost.Text, Convert.ToInt32(edPort.Text));
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Encoding = new UTF8Encoding(false);
            xws.ConformanceLevel = ConformanceLevel.Fragment;
            writer = XmlWriter.Create(client.GetStream(), xws);            
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
            writer.WriteAttributeString("UserName", edUserName.Text);
            writer.WriteAttributeString("Password", GetSHA1(edPassword.Text));
            writer.WriteAttributeString("ClientVersion", "1");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();

            reader.Read();
            if (reader.Name == "UserAccess")
            {
                if (reader["AccessDenied"] != "Y")
                {
                    addEventDisplay("Connection", "Connected and authorized");
                    receiver = new Thread(new ThreadStart(ReceiveThread));
                    receiver.Start();
                }
                btnQueryAll.Enabled = true;
            }
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
                            else if (reader.Name == "DataEntry")
                            {
                                this.Invoke((EventDisplayDelegate)addEventDisplay, "DataEntry", "Type: " + reader["Type"]);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void closeAll(bool show)
        {
            Trace.WriteLine("Closing...");
            if (receiver != null)
            {
                if (show)
                {
                    addEventDisplay("Thread", "Waiting thread to terminate...");
                }
                receiver.Abort();
               receiver.Join();
               receiver = null;
            }
            if (client != null)
            {
                if (show)
                {
                    addEventDisplay("Thread", "Waiting connecting to terminate...");
                }
                client.Close();
                client = null;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeAll(false);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnQueryAll_Click(object sender, EventArgs e)
        {
            writer.WriteStartElement("QueryDataEntry");
            writer.WriteStartElement("QEntry");
            writer.WriteAttributeString("Options", ":all_hdr:dev_info:");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();
        }
    }
}
