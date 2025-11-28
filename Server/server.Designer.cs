namespace server
{
    partial class server
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtIPPort;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnStartServer = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtIPPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartServer.Location = new System.Drawing.Point(12, 12);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(260, 50);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "BẮT ĐẦU LẮNG NGHE";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.button1_Click); // Giữ nguyên tên hàm sự kiện
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(12, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(126, 17);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Trạng thái: Chưa mở";
            // 
            // txtIPPort
            // 
            this.txtIPPort.Location = new System.Drawing.Point(12, 100);
            this.txtIPPort.Name = "txtIPPort";
            this.txtIPPort.ReadOnly = true;
            this.txtIPPort.Size = new System.Drawing.Size(260, 20);
            this.txtIPPort.TabIndex = 2;
            this.txtIPPort.Text = "IP: 127.0.0.1 | Port: 5656";
            this.txtIPPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 135);
            this.Controls.Add(this.txtIPPort);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStartServer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "server";
            this.Text = "Server Control Center";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}