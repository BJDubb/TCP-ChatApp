namespace ChatApp.Client
{
    partial class Main
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
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.messageButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.userHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.messageHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.onlineUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.connectionStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(41, 38);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(41, 67);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 1;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // messageButton
            // 
            this.messageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.messageButton.Enabled = false;
            this.messageButton.Location = new System.Drawing.Point(993, 298);
            this.messageButton.Name = "messageButton";
            this.messageButton.Size = new System.Drawing.Size(75, 23);
            this.messageButton.TabIndex = 2;
            this.messageButton.Text = "Send";
            this.messageButton.UseVisualStyleBackColor = true;
            this.messageButton.Click += new System.EventHandler(this.MessageButton_Click);
            // 
            // messageBox
            // 
            this.messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.messageBox.Location = new System.Drawing.Point(176, 298);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(811, 23);
            this.messageBox.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.userHeader,
            this.messageHeader});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(176, 38);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(892, 244);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // userHeader
            // 
            this.userHeader.Text = "User";
            this.userHeader.Width = 89;
            // 
            // messageHeader
            // 
            this.messageHeader.Text = "Message";
            this.messageHeader.Width = 863;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::Client.Properties.Resources.DisconIco;
            this.pictureBox1.InitialImage = global::Client.Properties.Resources.DisconIco;
            this.pictureBox1.Location = new System.Drawing.Point(41, 370);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // onlineUsers
            // 
            this.onlineUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.onlineUsers.HideSelection = false;
            this.onlineUsers.Location = new System.Drawing.Point(26, 107);
            this.onlineUsers.Name = "onlineUsers";
            this.onlineUsers.Size = new System.Drawing.Size(121, 205);
            this.onlineUsers.TabIndex = 7;
            this.onlineUsers.UseCompatibleStateImageBehavior = false;
            this.onlineUsers.View = System.Windows.Forms.View.Details;
            this.onlineUsers.SelectedIndexChanged += new System.EventHandler(this.OnlineUsers_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Online Users";
            this.columnHeader1.Width = 116;
            // 
            // connectionStatus
            // 
            this.connectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.connectionStatus.AutoSize = true;
            this.connectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.connectionStatus.Location = new System.Drawing.Point(41, 428);
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(116, 20);
            this.connectionStatus.TabIndex = 8;
            this.connectionStatus.Text = "Not Connected";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 472);
            this.Controls.Add(this.connectionStatus);
            this.Controls.Add(this.onlineUsers);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.messageButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Name = "Main";
            this.Text = "ChatApp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Shown += new System.EventHandler(this.Main_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button messageButton;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader userHeader;
        private System.Windows.Forms.ColumnHeader messageHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView onlineUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label connectionStatus;
    }
}

