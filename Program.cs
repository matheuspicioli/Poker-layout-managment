using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections.Generic;

namespace WindowManipulator
{
    class Program
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT Rect);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);

        static void Main(string[] args)
        {
            // Info
            // Menor tela do PS. Width: 476. Height: 356

            // Process[] processlist = Process.GetProcesses();
            Process[] processlist = Process.GetProcessesByName("PokerStars");
            foreach (Process process in processlist)
            {
                // Apenas em app que tenha tela
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    Console.WriteLine("----");
                    Console.WriteLine("Process: {0}\nWindow title: {1}", process.ProcessName, process.MainWindowTitle);
                    IntPtr handle = process.MainWindowHandle;
                    RECT Rect = new RECT();
                    if (GetWindowRect(handle, ref Rect)) {
                        Console.WriteLine("Manipulando janela");
                        MoveWindow(handle, 50, 50, 700, 500, true);
                    } else {
                        Console.WriteLine("Not found");
                    }
                    Console.WriteLine("----");
                }
                //     Console.WriteLine("----");
                //     Console.WriteLine("Process: {0}\nID: {1}\nWindow title: {2}\nWindow handle: {3}", process.ProcessName, process.Id, process.MainWindowTitle, process.MainWindowHandle);
                //     Console.WriteLine("----");
            }
        }
    }
}
