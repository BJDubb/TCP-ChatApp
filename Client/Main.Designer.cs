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
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(26, 38);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(26, 67);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 1;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // messageButton
            // 
            this.messageButton.Location = new System.Drawing.Point(669, 289);
            this.messageButton.Name = "messageButton";
            this.messageButton.Size = new System.Drawing.Size(75, 23);
            this.messageButton.TabIndex = 2;
            this.messageButton.Text = "Message";
            this.messageButton.UseVisualStyleBackColor = true;
            this.messageButton.Click += new System.EventHandler(this.MessageButton_Click);
            // 
            // messageBox
            // 
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.messageBox.Location = new System.Drawing.Point(176, 289);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(487, 23);
            this.messageBox.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.userHeader,
            this.messageHeader});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(176, 38);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(568, 235);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // userHeader
            // 
            this.userHeader.Text = "User";
            this.userHeader.Width = 113;
            // 
            // messageHeader
            // 
            this.messageHeader.Text = "Message";
            this.messageHeader.Width = 450;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.messageButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Name = "Main";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
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
    }
}

