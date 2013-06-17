namespace CodeWithMe
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
            this.buttonClient = new System.Windows.Forms.Button();
            this.buttonServer = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageNetwork = new System.Windows.Forms.TabPage();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.pageLogs = new System.Windows.Forms.TabPage();
            this.richTextBoxLogs = new System.Windows.Forms.RichTextBox();
            this.richTextBoxCode = new System.Windows.Forms.RichTextBox();
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.pageNetwork.SuspendLayout();
            this.pageLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClient
            // 
            this.buttonClient.Location = new System.Drawing.Point(63, 6);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(94, 37);
            this.buttonClient.TabIndex = 0;
            this.buttonClient.Text = "Connect as Client";
            this.buttonClient.UseVisualStyleBackColor = true;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
            // 
            // buttonServer
            // 
            this.buttonServer.Location = new System.Drawing.Point(63, 49);
            this.buttonServer.Name = "buttonServer";
            this.buttonServer.Size = new System.Drawing.Size(94, 37);
            this.buttonServer.TabIndex = 1;
            this.buttonServer.Text = "Start as Server";
            this.buttonServer.UseVisualStyleBackColor = true;
            this.buttonServer.Click += new System.EventHandler(this.buttonServer_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageNetwork);
            this.tabControl.Controls.Add(this.pageLogs);
            this.tabControl.Location = new System.Drawing.Point(3, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(253, 284);
            this.tabControl.TabIndex = 2;
            // 
            // pageNetwork
            // 
            this.pageNetwork.Controls.Add(this.labelUsername);
            this.pageNetwork.Controls.Add(this.textBoxUser);
            this.pageNetwork.Controls.Add(this.labelPort);
            this.pageNetwork.Controls.Add(this.labelHost);
            this.pageNetwork.Controls.Add(this.textBoxHost);
            this.pageNetwork.Controls.Add(this.textBoxPort);
            this.pageNetwork.Controls.Add(this.buttonServer);
            this.pageNetwork.Controls.Add(this.buttonClient);
            this.pageNetwork.Location = new System.Drawing.Point(4, 22);
            this.pageNetwork.Name = "pageNetwork";
            this.pageNetwork.Padding = new System.Windows.Forms.Padding(3);
            this.pageNetwork.Size = new System.Drawing.Size(245, 258);
            this.pageNetwork.TabIndex = 0;
            this.pageNetwork.Text = "Network";
            this.pageNetwork.UseVisualStyleBackColor = true;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(75, 98);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(70, 17);
            this.labelUsername.TabIndex = 8;
            this.labelUsername.Text = "Username:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(52, 118);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(109, 20);
            this.textBoxUser.TabIndex = 7;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPort.Location = new System.Drawing.Point(165, 156);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(35, 17);
            this.labelPort.TabIndex = 6;
            this.labelPort.Text = "Port:";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHost.Location = new System.Drawing.Point(63, 156);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(53, 17);
            this.labelHost.TabIndex = 5;
            this.labelHost.Text = "Host/IP:";
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(36, 176);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(109, 20);
            this.textBoxHost.TabIndex = 3;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(160, 176);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(44, 20);
            this.textBoxPort.TabIndex = 2;
            // 
            // pageLogs
            // 
            this.pageLogs.Controls.Add(this.richTextBoxLogs);
            this.pageLogs.Location = new System.Drawing.Point(4, 22);
            this.pageLogs.Name = "pageLogs";
            this.pageLogs.Padding = new System.Windows.Forms.Padding(3);
            this.pageLogs.Size = new System.Drawing.Size(245, 258);
            this.pageLogs.TabIndex = 1;
            this.pageLogs.Text = "Logs";
            this.pageLogs.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLogs
            // 
            this.richTextBoxLogs.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLogs.Location = new System.Drawing.Point(-4, 0);
            this.richTextBoxLogs.Name = "richTextBoxLogs";
            this.richTextBoxLogs.Size = new System.Drawing.Size(253, 262);
            this.richTextBoxLogs.TabIndex = 0;
            this.richTextBoxLogs.Text = "";
            // 
            // richTextBoxCode
            // 
            this.richTextBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxCode.Enabled = false;
            this.richTextBoxCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxCode.Location = new System.Drawing.Point(258, -1);
            this.richTextBoxCode.Name = "richTextBoxCode";
            this.richTextBoxCode.Size = new System.Drawing.Size(928, 666);
            this.richTextBoxCode.TabIndex = 3;
            this.richTextBoxCode.Text = "";
            this.richTextBoxCode.TextChanged += new System.EventHandler(this.richTextBoxCode_TextChanged);
            this.richTextBoxCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxCode_KeyPress);
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.richTextBoxChat.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxChat.Location = new System.Drawing.Point(3, 288);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.Size = new System.Drawing.Size(249, 317);
            this.richTextBoxChat.TabIndex = 4;
            this.richTextBoxChat.Text = "";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(217, 611);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(40, 43);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMsg.Location = new System.Drawing.Point(3, 611);
            this.textBoxMsg.Multiline = true;
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.Size = new System.Drawing.Size(208, 43);
            this.textBoxMsg.TabIndex = 6;
            this.textBoxMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMsg_KeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 666);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.richTextBoxChat);
            this.Controls.Add(this.richTextBoxCode);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "CodeWithMe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.pageNetwork.ResumeLayout(false);
            this.pageNetwork.PerformLayout();
            this.pageLogs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.Button buttonServer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pageNetwork;
        private System.Windows.Forms.TabPage pageLogs;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label labelUsername;
        public System.Windows.Forms.RichTextBox richTextBoxLogs;
        public System.Windows.Forms.TextBox textBoxUser;
        public System.Windows.Forms.RichTextBox richTextBoxCode;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxMsg;
        public System.Windows.Forms.RichTextBox richTextBoxChat;
    }
}

