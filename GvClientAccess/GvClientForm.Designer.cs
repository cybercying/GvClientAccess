namespace GvClientAccess
{
    partial class GvClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.edUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.edRemoteHost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edPort = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnQueryAll = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvChannels = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvDeviceInfo = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.edChannel = new System.Windows.Forms.TextBox();
            this.edDomainName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.edCamUserName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.edCamPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.edDriver = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edChannelName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.edDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.edIPAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.edIPPort = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.edUncondRec = new System.Windows.Forms.CheckBox();
            this.edCamDisabled = new System.Windows.Forms.CheckBox();
            this.btnUpdateChannel = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.7643F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.23569F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.07349F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.92651F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(673, 379);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "UserName";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Location = new System.Drawing.Point(129, 79);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(541, 264);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 76;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Detail";
            this.columnHeader3.Width = 199;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Logs";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.edUserName);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.edPassword);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(129, 42);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(541, 31);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // edUserName
            // 
            this.edUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edUserName.Location = new System.Drawing.Point(3, 3);
            this.edUserName.Name = "edUserName";
            this.edUserName.Size = new System.Drawing.Size(146, 22);
            this.edUserName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password";
            // 
            // edPassword
            // 
            this.edPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edPassword.Location = new System.Drawing.Point(209, 3);
            this.edPassword.Name = "edPassword";
            this.edPassword.PasswordChar = '*';
            this.edPassword.Size = new System.Drawing.Size(138, 22);
            this.edPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "RemoteHost";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.Controls.Add(this.edRemoteHost);
            this.flowLayoutPanel3.Controls.Add(this.label5);
            this.flowLayoutPanel3.Controls.Add(this.edPort);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(129, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(541, 33);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // edRemoteHost
            // 
            this.edRemoteHost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.edRemoteHost.Location = new System.Drawing.Point(3, 3);
            this.edRemoteHost.Name = "edRemoteHost";
            this.edRemoteHost.Size = new System.Drawing.Size(194, 22);
            this.edRemoteHost.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "Port";
            // 
            // edPort
            // 
            this.edPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.edPort.Location = new System.Drawing.Point(233, 3);
            this.edPort.Name = "edPort";
            this.edPort.Size = new System.Drawing.Size(77, 22);
            this.edPort.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear Logs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnConnect);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.btnQueryAll);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 411);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(687, 43);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(9, 9);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(90, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnQueryAll
            // 
            this.btnQueryAll.Enabled = false;
            this.btnQueryAll.Location = new System.Drawing.Point(171, 9);
            this.btnQueryAll.Name = "btnQueryAll";
            this.btnQueryAll.Size = new System.Drawing.Size(75, 23);
            this.btnQueryAll.TabIndex = 1;
            this.btnQueryAll.Text = "Initial Query";
            this.btnQueryAll.UseVisualStyleBackColor = true;
            this.btnQueryAll.Click += new System.EventHandler(this.btnQueryAll_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(687, 411);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(679, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(679, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Channels";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvChannels);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(673, 379);
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvChannels
            // 
            this.lvChannels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader8});
            this.lvChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvChannels.Location = new System.Drawing.Point(0, 0);
            this.lvChannels.Name = "lvChannels";
            this.lvChannels.Size = new System.Drawing.Size(289, 379);
            this.lvChannels.TabIndex = 0;
            this.lvChannels.UseCompatibleStateImageBehavior = false;
            this.lvChannels.View = System.Windows.Forms.View.Details;
            this.lvChannels.SelectedIndexChanged += new System.EventHandler(this.lvChannels_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 115;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            this.columnHeader5.Width = 84;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Driver";
            this.columnHeader8.Width = 81;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(380, 379);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvDeviceInfo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(372, 353);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "DeviceInfo";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lvDeviceInfo
            // 
            this.lvDeviceInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.lvDeviceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDeviceInfo.Location = new System.Drawing.Point(3, 3);
            this.lvDeviceInfo.Name = "lvDeviceInfo";
            this.lvDeviceInfo.Size = new System.Drawing.Size(366, 347);
            this.lvDeviceInfo.TabIndex = 1;
            this.lvDeviceInfo.UseCompatibleStateImageBehavior = false;
            this.lvDeviceInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "DeviceInfo";
            this.columnHeader6.Width = 165;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Value";
            this.columnHeader7.Width = 201;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tableLayoutPanel2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(372, 353);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "CameraSetup";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.50273F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.49727F));
            this.tableLayoutPanel2.Controls.Add(this.edChannel, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.edDomainName, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel5, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.edDriver, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.edChannelName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.edDescription, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel4, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel6, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.btnUpdateChannel, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.52941F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.47059F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(366, 347);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // edChannel
            // 
            this.edChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edChannel.Location = new System.Drawing.Point(99, 203);
            this.edChannel.Name = "edChannel";
            this.edChannel.Size = new System.Drawing.Size(264, 22);
            this.edChannel.TabIndex = 0;
            // 
            // edDomainName
            // 
            this.edDomainName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edDomainName.Location = new System.Drawing.Point(99, 130);
            this.edDomainName.Name = "edDomainName";
            this.edDomainName.Size = new System.Drawing.Size(264, 22);
            this.edDomainName.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 135);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "DomainName";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.edCamUserName);
            this.flowLayoutPanel5.Controls.Add(this.label12);
            this.flowLayoutPanel5.Controls.Add(this.edCamPassword);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(99, 235);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(264, 28);
            this.flowLayoutPanel5.TabIndex = 4;
            // 
            // edCamUserName
            // 
            this.edCamUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edCamUserName.Location = new System.Drawing.Point(3, 3);
            this.edCamUserName.Name = "edCamUserName";
            this.edCamUserName.Size = new System.Drawing.Size(105, 22);
            this.edCamUserName.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(114, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "Password";
            // 
            // edCamPassword
            // 
            this.edCamPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edCamPassword.Location = new System.Drawing.Point(168, 3);
            this.edCamPassword.Name = "edCamPassword";
            this.edCamPassword.PasswordChar = '*';
            this.edCamPassword.Size = new System.Drawing.Size(91, 22);
            this.edCamPassword.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(40, 243);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "UserName";
            // 
            // edDriver
            // 
            this.edDriver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edDriver.Location = new System.Drawing.Point(99, 32);
            this.edDriver.Name = "edDriver";
            this.edDriver.Size = new System.Drawing.Size(264, 22);
            this.edDriver.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Channel Name";
            // 
            // edChannelName
            // 
            this.edChannelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edChannelName.Location = new System.Drawing.Point(99, 3);
            this.edChannelName.Name = "edChannelName";
            this.edChannelName.Size = new System.Drawing.Size(264, 22);
            this.edChannelName.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Driver";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "Description";
            // 
            // edDescription
            // 
            this.edDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edDescription.Location = new System.Drawing.Point(99, 61);
            this.edDescription.Multiline = true;
            this.edDescription.Name = "edDescription";
            this.edDescription.Size = new System.Drawing.Size(264, 61);
            this.edDescription.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "IP Address";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.edIPAddress);
            this.flowLayoutPanel4.Controls.Add(this.label10);
            this.flowLayoutPanel4.Controls.Add(this.edIPPort);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(99, 160);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(264, 34);
            this.flowLayoutPanel4.TabIndex = 5;
            // 
            // edIPAddress
            // 
            this.edIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edIPAddress.Location = new System.Drawing.Point(3, 3);
            this.edIPAddress.Name = "edIPAddress";
            this.edIPAddress.Size = new System.Drawing.Size(149, 22);
            this.edIPAddress.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(158, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "Port";
            // 
            // edIPPort
            // 
            this.edIPPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edIPPort.Location = new System.Drawing.Point(188, 3);
            this.edIPPort.Name = "edIPPort";
            this.edIPPort.Size = new System.Drawing.Size(69, 22);
            this.edIPPort.TabIndex = 1;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.edUncondRec);
            this.flowLayoutPanel6.Controls.Add(this.edCamDisabled);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(99, 269);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(264, 75);
            this.flowLayoutPanel6.TabIndex = 9;
            // 
            // edUncondRec
            // 
            this.edUncondRec.AutoSize = true;
            this.edUncondRec.Location = new System.Drawing.Point(3, 3);
            this.edUncondRec.Name = "edUncondRec";
            this.edUncondRec.Size = new System.Drawing.Size(142, 16);
            this.edUncondRec.TabIndex = 0;
            this.edUncondRec.Text = "Unconditional Recording";
            this.edUncondRec.UseVisualStyleBackColor = true;
            // 
            // edCamDisabled
            // 
            this.edCamDisabled.AutoSize = true;
            this.edCamDisabled.Location = new System.Drawing.Point(3, 25);
            this.edCamDisabled.Name = "edCamDisabled";
            this.edCamDisabled.Size = new System.Drawing.Size(64, 16);
            this.edCamDisabled.TabIndex = 1;
            this.edCamDisabled.Text = "Disabled";
            this.edCamDisabled.UseVisualStyleBackColor = true;
            // 
            // btnUpdateChannel
            // 
            this.btnUpdateChannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateChannel.Location = new System.Drawing.Point(3, 321);
            this.btnUpdateChannel.Name = "btnUpdateChannel";
            this.btnUpdateChannel.Size = new System.Drawing.Size(90, 23);
            this.btnUpdateChannel.TabIndex = 10;
            this.btnUpdateChannel.Text = "Update!";
            this.btnUpdateChannel.UseVisualStyleBackColor = true;
            this.btnUpdateChannel.Click += new System.EventHandler(this.btnUpdateChannel_Click);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(49, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "Channel";
            // 
            // GvClientForm
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 454);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "GvClientForm";
            this.Text = "GvClient XML Protocol Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox edRemoteHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edPassword;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edPort;
        private System.Windows.Forms.Button btnQueryAll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvChannels;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lvDeviceInfo;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox edDriver;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edChannelName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox edDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.TextBox edCamUserName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox edCamPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.TextBox edIPAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox edIPPort;
        private System.Windows.Forms.TextBox edDomainName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.CheckBox edUncondRec;
        private System.Windows.Forms.CheckBox edCamDisabled;
        private System.Windows.Forms.Button btnUpdateChannel;
        private System.Windows.Forms.TextBox edChannel;
        private System.Windows.Forms.Label label14;

    }
}

