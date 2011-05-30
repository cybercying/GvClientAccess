﻿using System;
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

namespace GvClientAccess
{
    public partial class Form1 : Form
    {
        public Form1()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("Connecting....");
            TcpClient client = new TcpClient("192.168.0.124", 3557);
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
            XmlReader reader = XmlReader.Create(client.GetStream(), xrs);
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
            MessageBox.Show("Connected!! [" + reader.Name + "]");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
