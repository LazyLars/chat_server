namespace chat_server
{
    partial class GuiServer
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbServer = new System.Windows.Forms.ListBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbServer
            // 
            this.lbServer.FormattingEnabled = true;
            this.lbServer.Location = new System.Drawing.Point(11, 41);
            this.lbServer.Margin = new System.Windows.Forms.Padding(2);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(881, 329);
            this.lbServer.TabIndex = 4;
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(11, 11);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(116, 26);
            this.btnStartServer.TabIndex = 5;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            // 
            // GuiServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 387);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.lbServer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GuiServer";
            this.Text = "Echo Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TGui_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbServer;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Timer timer1;
    }
}

