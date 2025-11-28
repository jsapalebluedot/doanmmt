// File: Server/Program.cs
using System;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace server
{
    static class Program
    {
        // Khai báo các biến kết nối mạng toàn cục cho Server
        public static Socket? server; // Socket để lắng nghe kết nối
        public static Socket? client; // Socket của Client đã kết nối
        public static NetworkStream? ns;
        public static StreamReader? nr;
        public static StreamWriter? nw;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Đảm bảo chạy Form 'server' (tên class bạn đã đặt)
            Application.Run(new server());
        }
    }
}