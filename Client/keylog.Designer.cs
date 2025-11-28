namespace client
{
    partial class keylog
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
            this.txtKQ = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            // KHAI BÁO CÁC NÚT ĐIỀU KHIỂN BỔ SUNG
            this.btnShutdown = new System.Windows.Forms.Button();
            this.btnRegistry = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnTakePic = new System.Windows.Forms.Button();

            this.SuspendLayout();
            // 
            // txtKQ
            // 
            this.txtKQ.Enabled = false;
            this.txtKQ.Location = new System.Drawing.Point(12, 77);
            this.txtKQ.Name = "txtKQ";
            this.txtKQ.Size = new System.Drawing.Size(400, 182);
            this.txtKQ.TabIndex = 0;
            this.txtKQ.Text = "";
            // 
            // button1 (HOOK)
            // 
            this.button1.Location = new System.Drawing.Point(12, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "HOOK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2 (UNHOOK)
            // 
            this.button2.Location = new System.Drawing.Point(93, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 58);
            this.button2.TabIndex = 2;
            this.button2.Text = "UNHOOK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3 (PRINT)
            // 
            this.button3.Location = new System.Drawing.Point(174, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 58);
            this.button3.TabIndex = 3;
            this.button3.Text = "PRINT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // butXoa
            // 
            this.butXoa.Location = new System.Drawing.Point(255, 13);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(75, 58);
            this.butXoa.TabIndex = 4;
            this.butXoa.Text = "Xóa";
            this.butXoa.UseVisualStyleBackColor = true;
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);

            // 
            // btnShutdown (TẮT MÁY)
            // 
            this.btnShutdown.Location = new System.Drawing.Point(336, 13);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(75, 58);
            this.btnShutdown.TabIndex = 5;
            this.btnShutdown.Text = "TẮT MÁY";
            this.btnShutdown.UseVisualStyleBackColor = true;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);

            // 
            // btnRegistry
            // 
            this.btnRegistry.Location = new System.Drawing.Point(12, 270);
            this.btnRegistry.Name = "btnRegistry";
            this.btnRegistry.Size = new System.Drawing.Size(75, 58);
            this.btnRegistry.TabIndex = 6;
            this.btnRegistry.Text = "REGISTRY";
            this.btnRegistry.UseVisualStyleBackColor = true;
            this.btnRegistry.Click += new System.EventHandler(this.btnRegistry_Click);

            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(93, 270);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 58);
            this.btnProcess.TabIndex = 7;
            this.btnProcess.Text = "PROCESS";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);

            // 
            // btnTakePic
            // 
            this.btnTakePic.Location = new System.Drawing.Point(174, 270);
            this.btnTakePic.Name = "btnTakePic";
            this.btnTakePic.Size = new System.Drawing.Size(75, 58);
            this.btnTakePic.TabIndex = 8;
            this.btnTakePic.Text = "TAKE PIC";
            this.btnTakePic.UseVisualStyleBackColor = true;
            this.btnTakePic.Click += new System.EventHandler(this.btnTakePic_Click);

            // 
            // keylog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 340); // Tăng kích thước cửa sổ để chứa các nút mới

            this.Controls.Add(this.btnTakePic);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnRegistry);
            this.Controls.Add(this.btnShutdown);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtKQ);
            this.Name = "keylog";
            this.Text = "Keystroke Remote Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.keylog_closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtKQ;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button butXoa;

        // KHAI BÁO CÁC NÚT ĐIỀU KHIỂN BỔ SUNG
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.Button btnRegistry;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnTakePic;
    }


}