namespace EUO
{
    partial class MainForm
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
            this.comboBoxIPListen = new System.Windows.Forms.ComboBox();
            this.labelIPListen = new System.Windows.Forms.Label();
            this.labelPortListen = new System.Windows.Forms.Label();
            this.textBoxPortListen = new System.Windows.Forms.TextBox();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.checkBoxAutoScroll = new System.Windows.Forms.CheckBox();
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.labelClients = new System.Windows.Forms.Label();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.buttonKickUser = new System.Windows.Forms.Button();
            this.listBoxAccounts = new System.Windows.Forms.ListBox();
            this.labelAccounts = new System.Windows.Forms.Label();
            this.listBoxChars = new System.Windows.Forms.ListBox();
            this.labelChars = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxIPListen
            // 
            this.comboBoxIPListen.Location = new System.Drawing.Point(90, 12);
            this.comboBoxIPListen.Name = "comboBoxIPListen";
            this.comboBoxIPListen.Size = new System.Drawing.Size(100, 21);
            this.comboBoxIPListen.TabIndex = 0;
            // 
            // labelIPListen
            // 
            this.labelIPListen.AutoSize = true;
            this.labelIPListen.Location = new System.Drawing.Point(12, 15);
            this.labelIPListen.Name = "labelIPListen";
            this.labelIPListen.Size = new System.Drawing.Size(59, 13);
            this.labelIPListen.TabIndex = 1;
            this.labelIPListen.Text = "IP to listen:";
            // 
            // labelPortListen
            // 
            this.labelPortListen.AutoSize = true;
            this.labelPortListen.Location = new System.Drawing.Point(12, 41);
            this.labelPortListen.Name = "labelPortListen";
            this.labelPortListen.Size = new System.Drawing.Size(72, 13);
            this.labelPortListen.TabIndex = 2;
            this.labelPortListen.Text = "Port to Listen:";
            // 
            // textBoxPortListen
            // 
            this.textBoxPortListen.Location = new System.Drawing.Point(90, 38);
            this.textBoxPortListen.Name = "textBoxPortListen";
            this.textBoxPortListen.Size = new System.Drawing.Size(100, 20);
            this.textBoxPortListen.TabIndex = 3;
            this.textBoxPortListen.Text = "2593";
            this.textBoxPortListen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(15, 64);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(175, 23);
            this.buttonStartServer.TabIndex = 4;
            this.buttonStartServer.Text = "Start Server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.HorizontalScrollbar = true;
            this.listBoxLog.Location = new System.Drawing.Point(196, 34);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.ScrollAlwaysVisible = true;
            this.listBoxLog.Size = new System.Drawing.Size(284, 134);
            this.listBoxLog.TabIndex = 5;
            this.listBoxLog.SelectedIndexChanged += new System.EventHandler(this.listBoxLog_SelectedIndexChanged);
            this.listBoxLog.Validated += new System.EventHandler(this.listBoxLog_SelectedIndexChanged);
            this.listBoxLog.TextChanged += new System.EventHandler(this.listBoxLog_SelectedIndexChanged);
            // 
            // checkBoxAutoScroll
            // 
            this.checkBoxAutoScroll.AutoSize = true;
            this.checkBoxAutoScroll.Checked = true;
            this.checkBoxAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoScroll.Location = new System.Drawing.Point(405, 14);
            this.checkBoxAutoScroll.Name = "checkBoxAutoScroll";
            this.checkBoxAutoScroll.Size = new System.Drawing.Size(75, 17);
            this.checkBoxAutoScroll.TabIndex = 7;
            this.checkBoxAutoScroll.Text = "Auto-scroll";
            this.checkBoxAutoScroll.UseVisualStyleBackColor = true;
            this.checkBoxAutoScroll.CheckedChanged += new System.EventHandler(this.checkBoxAutoScroll_CheckedChanged);
            // 
            // listBoxClients
            // 
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.HorizontalScrollbar = true;
            this.listBoxClients.Location = new System.Drawing.Point(486, 34);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.ScrollAlwaysVisible = true;
            this.listBoxClients.Size = new System.Drawing.Size(139, 134);
            this.listBoxClients.TabIndex = 9;
            this.listBoxClients.SelectedIndexChanged += new System.EventHandler(this.listBoxClients_SelectedIndexChanged);
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(193, 15);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(25, 13);
            this.labelLog.TabIndex = 10;
            this.labelLog.Text = "Log";
            // 
            // labelClients
            // 
            this.labelClients.AutoSize = true;
            this.labelClients.Location = new System.Drawing.Point(486, 15);
            this.labelClients.Name = "labelClients";
            this.labelClients.Size = new System.Drawing.Size(50, 13);
            this.labelClients.TabIndex = 11;
            this.labelClients.Text = "Clients: 0";
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Enabled = false;
            this.buttonClearLog.Location = new System.Drawing.Point(15, 93);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(81, 23);
            this.buttonClearLog.TabIndex = 12;
            this.buttonClearLog.Text = "Clear log";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // buttonKickUser
            // 
            this.buttonKickUser.Enabled = false;
            this.buttonKickUser.Location = new System.Drawing.Point(109, 93);
            this.buttonKickUser.Name = "buttonKickUser";
            this.buttonKickUser.Size = new System.Drawing.Size(81, 23);
            this.buttonKickUser.TabIndex = 13;
            this.buttonKickUser.Text = "Kick User";
            this.buttonKickUser.UseVisualStyleBackColor = true;
            this.buttonKickUser.Click += new System.EventHandler(this.buttonKickUser_Click);
            // 
            // listBoxAccounts
            // 
            this.listBoxAccounts.FormattingEnabled = true;
            this.listBoxAccounts.HorizontalScrollbar = true;
            this.listBoxAccounts.Location = new System.Drawing.Point(196, 187);
            this.listBoxAccounts.Name = "listBoxAccounts";
            this.listBoxAccounts.ScrollAlwaysVisible = true;
            this.listBoxAccounts.Size = new System.Drawing.Size(139, 134);
            this.listBoxAccounts.TabIndex = 14;
            this.listBoxAccounts.SelectedIndexChanged += new System.EventHandler(this.listBoxAccounts_SelectedIndexChanged);
            // 
            // labelAccounts
            // 
            this.labelAccounts.AutoSize = true;
            this.labelAccounts.Location = new System.Drawing.Point(193, 171);
            this.labelAccounts.Name = "labelAccounts";
            this.labelAccounts.Size = new System.Drawing.Size(64, 13);
            this.labelAccounts.TabIndex = 15;
            this.labelAccounts.Text = "Accounts: 0";
            // 
            // listBoxChars
            // 
            this.listBoxChars.FormattingEnabled = true;
            this.listBoxChars.HorizontalScrollbar = true;
            this.listBoxChars.Location = new System.Drawing.Point(341, 187);
            this.listBoxChars.Name = "listBoxChars";
            this.listBoxChars.ScrollAlwaysVisible = true;
            this.listBoxChars.Size = new System.Drawing.Size(139, 134);
            this.listBoxChars.TabIndex = 16;
            // 
            // labelChars
            // 
            this.labelChars.AutoSize = true;
            this.labelChars.Location = new System.Drawing.Point(338, 171);
            this.labelChars.Name = "labelChars";
            this.labelChars.Size = new System.Drawing.Size(70, 13);
            this.labelChars.TabIndex = 17;
            this.labelChars.Text = "Characters: 0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 344);
            this.Controls.Add(this.labelChars);
            this.Controls.Add(this.listBoxChars);
            this.Controls.Add(this.labelAccounts);
            this.Controls.Add(this.listBoxAccounts);
            this.Controls.Add(this.buttonKickUser);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.labelClients);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.listBoxClients);
            this.Controls.Add(this.checkBoxAutoScroll);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonStartServer);
            this.Controls.Add(this.textBoxPortListen);
            this.Controls.Add(this.labelPortListen);
            this.Controls.Add(this.labelIPListen);
            this.Controls.Add(this.comboBoxIPListen);
            this.Icon = global::EUO.Properties.Resources.UO_Icon;
            this.Name = "MainForm";
            this.Text = "EUO Server";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Disposed += new System.EventHandler(this.MainForm_Disposed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

		private System.Windows.Forms.ComboBox comboBoxIPListen;
		private System.Windows.Forms.Label labelIPListen;
		private System.Windows.Forms.Label labelPortListen;
		private System.Windows.Forms.TextBox textBoxPortListen;
		private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.CheckBox checkBoxAutoScroll;
        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Label labelClients;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.Button buttonKickUser;
        private System.Windows.Forms.ListBox listBoxAccounts;
        private System.Windows.Forms.Label labelAccounts;
        private System.Windows.Forms.ListBox listBoxChars;
        private System.Windows.Forms.Label labelChars;

	}
}

