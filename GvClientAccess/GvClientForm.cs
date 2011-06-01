/**
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
            if (InvokeRequired)
            {
                Invoke((EventDisplayDelegate)addEventDisplay, type, detail);
            }
            else
            {
                ListViewItem li = listView1.Items.Insert(0, Convert.ToString(eventCount++));
                li.SubItems.Add(type);
                li.SubItems.Add(detail);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            closeAll(true);
            rkey.SetValue("RemoteHost", edRemoteHost.Text);
            rkey.SetValue("Port", edPort.Text);
            rkey.SetValue("UserName", edUserName.Text);
            rkey.SetValue("Password", edPassword.Text);

            receiver = new Thread(new ThreadStart(ReceiveThread));
            receiver.Start();
        }

        void ParseDeviceInfo(DeviceInfo di)
        {
            addEventDisplay("DeviceInfo", "[" + di.Name + "] " + di.Param + "=>" + di.Value + ", Verb: " + Convert.ToString(di.Verb));
            String Key = "Ch:" + di.Name;
            if (EntryMap.ContainsKey(Key))
            {
                DataEntry ent = EntryMap[Key];
                ent.handleDeviceInfo(di);
            } // otherwise just drop it
        }

        class DataEntry
        {
            public String Key;
            public String Type;
            public bool IsDeleted;
            public long TimeCreated;
            public long TimeUpdated;
            public String SortKey;

            // Type == GV_OpenChannel
            public String ChannelName;
            public String Driver;
            public String Description;
            public String DomainName, IPAddress, IPPort, Channel, UserName, Password, Options, AudioInput, VideoInput;
            public bool UncondRec, Disabled;
            
            // Type == GV_Userlog
            public long UserlogTime; // time of initial log
            public String UserlogType;
            public String UserlogMessageRid;
            public Dictionary<String, String> UserlogSymbols;

            public ListViewItem lvi;

            public Dictionary<String, String> diMap;

            public void handleDeviceInfo(DeviceInfo di)
            {
                if (diMap == null) // lazy creation
                {
                    diMap = new Dictionary<string, string>();
                }
                if (di.Verb == 0)
                {
                    diMap[di.Param] = di.Value;
                }
                else if (di.Verb == 1)
                {
                    Dictionary<String, String> newMap = new Dictionary<String, String>();
                    foreach(String s in diMap.Keys)
                    {
                        if (!s.StartsWith(di.Param))
                        {
                            newMap.Add(s, diMap[s]);
                        }
                    }
                    diMap = newMap; // replace old map
                }
            }

            internal void AddUserLogSymbol(string name, string value)
            {
                if (UserlogSymbols == null)
                {
                    UserlogSymbols = new Dictionary<string, string>();
                }
                UserlogSymbols[name] = value;
            }
        }

        Dictionary<String, DataEntry> EntryMap = new Dictionary<string,DataEntry>();

        void ParseDataEntry()
        {
            try
            {
                DataEntry ent = new DataEntry();
                ent.Key = reader["Key2"];
                ent.Type = reader["Type"];
                ent.IsDeleted = reader["IsDeleted"] == "Y";
                ent.TimeCreated = Convert.ToInt64(reader["TimeCreated"]);
                ent.TimeUpdated = Convert.ToInt64(reader["TimeUpdated"]);
                ent.SortKey = reader["SortKey"];
                //ent.Xml = reader.ReadOuterXml();

                if (ent.Type == "GV_OpenChannel")
                {
                    reader.ReadStartElement();
                    Debug.Assert(reader.Name == "OpenChannel");
                    // here to read <OpenChannel> data....
                    ent.ChannelName = reader["Name"];
                    //addEventDisplay("DataEntry", "Type: " + ent.Type + ", inner: " + reader.Name + ", Key: " + ent.Key);
                    //Trace.WriteLine(ent.Type + ", xml: " + reader.Name + ", outer: " + ent.Xml);
                    if (reader.ReadToDescendant("CameraConfig"))
                    {
                        ent.Driver = reader["Driver"];
                        ent.Description = reader["Description"];
                        ent.DomainName = reader["DomainName"];
                        ent.IPAddress = reader["IPAddress"];
                        ent.IPPort = reader["IPPort"];
                        if (ent.IPPort == null)
                        {
                            ent.IPPort = "80";
                        }
                        ent.Channel = reader["Channel"];
                        ent.UncondRec = reader["UncondRec"] == "Y";
                        ent.Disabled = reader["Disabled"] == "Y";
                        ent.Options = reader["Options"];
                        ent.AudioInput = reader["AudioInput"];
                        ent.VideoInput = reader["VideoInput"];
                        if (reader.ReadToDescendant("HttpAuthorization"))
                        {
                            ent.UserName = reader["UserName"];
                            ent.Password = reader["Password"];
                        }
                    }
                }
                else if (ent.Type == "GV_Userlog")
                {
                    reader.ReadToDescendant("Userlog");
                    ent.UserlogTime = Convert.ToInt64(reader["Time"]);
                    ent.UserlogType = reader["Type"];
                    bool exitLoop = false;
                    while(!exitLoop && reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Name == "Com_EventDescription")
                                {
                                    ent.UserlogMessageRid = reader["MessageRid"];
                                }
                                else if (reader.Name == "Com_ReplaceStr")
                                {
                                    ent.AddUserLogSymbol(reader["Name"], reader["Value"]);
                                }
                                break;

                            case XmlNodeType.EndElement:
                                if (reader.Name == "Userlog")
                                {
                                    exitLoop = true;
                                }
                                break;
                        }
                    }
                }
                updateEntry(ent);
            }
            catch (NullReferenceException err)
            {
                Trace.WriteLine(err.ToString());
            }
        }

        void updateEntry(DataEntry ent)
        {
            DataEntry old;
            if (EntryMap.ContainsKey(ent.Key))
            {
                old = EntryMap[ent.Key];
                if (old.lvi != null)
                {
                    old.lvi.Remove();
                    old.lvi = null;
                }
                if (ent.IsDeleted)
                {
                    EntryMap.Remove(ent.Key);
                    return;
                }
            }
            if (ent.IsDeleted) return;
            if (ent.Type == "GV_OpenChannel")
            {
                ent.lvi = lvChannels.Items.Add(ent.ChannelName);
                ent.lvi.SubItems.Add("");
                ent.lvi.SubItems.Add(ent.Driver);
                ent.lvi.Tag = ent;
            }
            else if (ent.Type == "SysChannel")
            {
                ent.lvi = lvChannels.Items.Add("(System)");
                ent.lvi.Tag = ent;
            }
            else if (ent.Type == "GV_Userlog")
            {
                ent.lvi = lvUserlog.Items.Add(humanTime(ent.UserlogTime));
                ent.lvi.SubItems.Add(ent.UserlogType);
                ent.lvi.SubItems.Add(ent.UserlogMessageRid);
                String str = "";
                if (ent.UserlogSymbols != null)
                {
                    foreach (String s in ent.UserlogSymbols.Keys)
                    {
                        if (str.Length > 0)
                        {
                            str += ", ";
                        }
                        String value = ent.UserlogSymbols[s];
                        str += s + "=>" + value;
                    }
                }
                ent.lvi.SubItems.Add(str);
            }
            EntryMap[ent.Key] = ent;
        }

        void ParseTopLevelXml()
        {
            if (reader.Name == "DeviceInfo")
            {
                DeviceInfo di = new DeviceInfo();
                di.Name = reader["Name"];
                di.Param = reader["Param"];
                di.Value = reader["Value"];
                di.Verb = Convert.ToInt32(reader["Verb"]);
                ParseDeviceInfo(di);
            }
            else if (reader.Name == "DataEntry")
            {
                ParseDataEntry();
            }
            else
            {
                Trace.WriteLine("ParseTopLevelXml(): Unhandled top-level command: " + reader.Name);
            }
        }

        String mAuthKey;
        TcpClient mqclient;
        XmlWriter mqwriter;
        XmlReader mqreader;
        Thread mqthread;
        
        void ReceiveThread()
        {
            try
            {
                Trace.WriteLine("ReceiveThread...");

                addEventDisplay("Connection", "Connecting to remote host: " + edRemoteHost.Text + ":" + edPort.Text);
                client = new TcpClient(edRemoteHost.Text, Convert.ToInt32(edPort.Text));
                addEventDisplay("Connection", "Connected to remote host: " + edRemoteHost.Text + ":" + edPort.Text);
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
                Debug.Assert(reader.Name == "LoginResult" && reader["Status"] == "200" && reader["Message"] == "OK");
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
                        DataEntry s = new DataEntry();
                        s.Key = "Ch:/Sys";
                        s.Type = "SysChannel"; // special object
                        updateEntry(s);

                        addEventDisplay("Connection", "Connected and authorized");
                    }
                    mAuthKey = reader["AuthorizeKey"];
                    Trace.WriteLine("MQConn.1");
                    mqclient = new TcpClient(edRemoteHost.Text, Convert.ToInt32(edPort.Text));
                    addEventDisplay("MQConnection", "Connected to remote host: " + edRemoteHost.Text + ":" + edPort.Text);
                    mqwriter = XmlWriter.Create(mqclient.GetStream(), xws);
                    mqwriter.WriteStartElement("Login");
                    mqwriter.WriteAttributeString("UserName", "TestUser");
                    mqwriter.WriteAttributeString("Password", mAuthKey);
                    mqwriter.WriteAttributeString("Pin", "CxClient");
                    mqwriter.WriteEndElement();
                    mqwriter.Flush();
                    Trace.WriteLine("MQConn.2");
                    mqreader = XmlReader.Create(mqclient.GetStream(), xrs);
                    Trace.WriteLine("MQConn.3");
                    mqreader.Read();
                    Trace.WriteLine("MQConn.4: " + mqreader["Status"]);
                    if (mqreader["Status"] == "200") // success
                    {
                        mqthread = new Thread(new ThreadStart(MQReadThread));
                        mqthread.Start();
                    }
                    
                    btnQueryAll.Enabled = true;
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Depth == 0)
                                {
                                    this.Invoke((MyDelegate)ParseTopLevelXml);
                                }
                                break;
                        }
                    }
                }
                else
                {
                    addEventDisplay("Connection", "Access denied!");
                }
                Trace.WriteLine("ReceiveThread().2");
            }
            catch(Exception err)
            {
                Trace.WriteLine("ReceiveThread() aborted: " + err);
            }
        }

        void MQReadThread()
        {
            try
            {
                Trace.WriteLine("MQReceiveThread.1");
                while (mqreader.Read())
                {
                    switch (mqreader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (mqreader.Depth == 0)
                            {
                                this.Invoke((MyDelegate)ParseTopLevelXmlMQ);
                            }
                            break;
                    }
                }
                Trace.WriteLine("MQReceiveThread().2");
            }
            catch(Exception err)
            {
                Trace.WriteLine("MQReceiveThread() aborted: " + err);
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
                receiver.Join(500);
                receiver = null;
            }
            if (mqthread != null)
            {
                if (show)
                {
                    addEventDisplay("Thread", "Waiting MQ thread to terminate...");
                }
                mqthread.Abort();
                mqthread.Join(500);
                mqthread = null;
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
            if (mqclient != null)
            {
                if (show)
                {
                    addEventDisplay("Thread", "Waiting MQ connecting to terminate...");
                }
                mqclient.Close();
                mqclient = null;
            }
            if (show)
            {
                lvChannels.Items.Clear();
                lvDeviceInfo.Items.Clear();
                lvUserlog.Items.Clear();
            }
            EntryMap.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeAll(false);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void lvChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvDeviceInfo.Items.Clear();
            if (lvChannels.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvChannels.SelectedItems[0];
                DataEntry ent = (DataEntry)lvi.Tag;
                lvDeviceInfo.Items.Clear();
                if (ent.diMap != null)
                {
                    foreach (String s in ent.diMap.Keys)
                    {
                        ListViewItem lv2 = lvDeviceInfo.Items.Add(s);
                        lv2.SubItems.Add(ent.diMap[s]);
                    }
                }
                edDriver.Text = ent.Driver;
                edChannelName.Text = ent.ChannelName;
                edDescription.Text = ent.Description;
                edDomainName.Text = ent.DomainName;
                edIPAddress.Text = ent.IPAddress;
                edIPPort.Text = ent.IPPort;
                edCamUserName.Text = ent.UserName;
                edCamPassword.Text = ent.Password;
                edChannel.Text = ent.Channel;
                edUncondRec.Checked = ent.UncondRec;
                edCamDisabled.Checked = ent.Disabled;
            }
        }

        private void btnUpdateChannel_Click(object sender, EventArgs e)
        {
            writer.WriteStartElement("ConfigureChannel");
            writer.WriteAttributeString("Name", edChannelName.Text);
            writer.WriteStartElement("CameraConfig");
            writer.WriteAttributeString("Driver", edDriver.Text);
            writer.WriteAttributeString("Description", edDescription.Text);
            writer.WriteAttributeString("DomainName", edDomainName.Text);
            writer.WriteAttributeString("IPAddress", edIPAddress.Text);
            writer.WriteAttributeString("IPPort", edIPPort.Text);
            writer.WriteAttributeString("Channel", edChannel.Text);
            writer.WriteAttributeString("UncondRec", edUncondRec.Checked ? "Y" : "N");
            writer.WriteAttributeString("Disabled", edCamDisabled.Checked ? "Y" : "N");
            writer.WriteStartElement("HttpAuthorization");
            writer.WriteAttributeString("UserName", edCamUserName.Text);
            writer.WriteAttributeString("Password", edCamPassword.Text);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();
        }

        private void tcMain_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tbMediaQuery)
            {
                if (edQueryType.SelectedIndex == -1)
                {
                    edQueryType.SelectedIndex = 0;
                }
                edQueryChannel.Items.Clear();
                foreach (String s in EntryMap.Keys)
                {
                    if (s.StartsWith("Ch:"))
                    {
                        DataEntry ent = EntryMap[s];
                        if (ent.Type == "GV_OpenChannel")
                        {
                            edQueryChannel.Items.Add(ent.ChannelName);
                        }
                    }
                }
                if (edQueryChannel.SelectedIndex == -1 && edQueryChannel.Items.Count > 0)
                {
                    edQueryChannel.SelectedIndex = 0;
                }
            }
        }

        String mMediaQueryCookie;

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (edQueryChannel.SelectedItem == null)
            {
                MessageBox.Show("Must select a channel!");
                return;
            }
            lvEvent.Items.Clear();
//            MessageBox.Show("StartTime: " + Convert.ToString(dtStartTime.Value.ToFileTimeUtc()));
            mqwriter.WriteStartElement("MediaQuery");
            mqwriter.WriteAttributeString("Id", "Q001"); // Q001 is an internal identifier for this query session
            mqwriter.WriteAttributeString("Channel", edQueryChannel.SelectedItem.ToString());
            mMediaQueryCookie = Convert.ToString(DateTime.Now.ToFileTimeUtc()); // cookie is to identify query for current request.
            mqwriter.WriteAttributeString("Cookie", mMediaQueryCookie);
            mqwriter.WriteAttributeString("Type", "Event");
            mqwriter.WriteAttributeString("Time", Convert.ToString(dtStartTime.Value.ToFileTimeUtc()));
            mqwriter.WriteAttributeString("EndTime", Convert.ToString(dtEndTime.Value.ToFileTimeUtc()));
            mqwriter.WriteEndElement();
            mqwriter.Flush();
            Trace.WriteLine("MediaQuery.1");
        }

        void fetchMediaQuery()
        {
            mqwriter.WriteStartElement("Fetch");
            mqwriter.WriteAttributeString("Id", "Q001");
            mqwriter.WriteAttributeString("Cookie", mMediaQueryCookie);
            mqwriter.WriteEndElement();
            mqwriter.Flush();
        }

        void ParseQueryResult()
        {
            Trace.WriteLine("MediaQuery.2");
            String Id = mqreader["Id"];
            if (Id == "Q001") // this is for MediaQuery tab
            {
                Trace.WriteLine("MediaQuery.3");
                if (mMediaQueryCookie == mqreader["Cookie"]) // check to discard network residue
                {
                    Trace.WriteLine("MediaQuery.4");
                    if (mqreader["Valid"] == "Y") // checks for validity
                    {
                        Trace.WriteLine("MediaQuery.5");
                        fetchMediaQuery();
                    }
                }
            }
        }

        String humanTime(long p)
        {
            return DateTime.FromFileTimeUtc(p).ToString();
        }

        String humanTime(String str)
        {
            return DateTime.FromFileTimeUtc(Convert.ToInt64(str)).ToString();
        }

        void ParseMediaMetadata()
        {
            Trace.WriteLine("MediaQuery.6");
            String Id = mqreader["Id"];
            if (Id == "Q001") // this is for MediaQuery tab
            {
                Trace.WriteLine("MediaQuery.7");
                if (mMediaQueryCookie == mqreader["Cookie"]) // check to discard network residue
                {
                    Trace.WriteLine("MediaQuery.8");
                    bool isEof = mqreader["IsEOF"] == "Y";
                    bool exitLoop = false;
                    while (!exitLoop && mqreader.Read())
                    {
                        Trace.WriteLine(mqreader.NodeType);
                        switch (mqreader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (mqreader.Name == "ClipIndex")
                                {
                                    ListViewItem lvi = lvEvent.Items.Add(mqreader["Type"]);
                                    lvi.SubItems.Add(humanTime(mqreader["StartTime"]));
                                    lvi.SubItems.Add(humanTime(mqreader["EndTime"]));
                                }
                                break;

                            case XmlNodeType.EndElement:
                                if (mqreader.Name == "MediaMetadata")
                                {
                                    if (!isEof)
                                    {
                                        fetchMediaQuery(); // continue to fetch next batch of data...
                                    }
                                    exitLoop = true;
                                }
                                break;
                        }
                    }
                }
            }
        }

        void ParseTopLevelXmlMQ()
        {
            if (mqreader.Name == "QueryResult")
            {
                ParseQueryResult();
            }
            else if (mqreader.Name == "MediaMetadata")
            {
                ParseMediaMetadata();
            }
            else
            {
                Trace.WriteLine("ParseTopLevelXmlMQ(): Unhandled top-level command: " + mqreader.Name);
            }
        }
    }
}
