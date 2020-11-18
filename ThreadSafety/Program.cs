using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadSafety
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DpiFix();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var view = new View();
            var presenter = new Presenter(view);
            Application.Run(view);
        }

        const int WinDefaultDpi = 96;

        /// <summary>
        /// Исправление блюра при включенном масштабировании в ОС windows 8 и выше
        /// </summary>
        public static void DpiFix()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
        }

        /// <summary>
        /// WinAPI SetProcessDPIAware 
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// Исправление размера шрифтов
        /// </summary>
        /// <param name="c"></param>
        public static float DpiFixFonts(Control c)
        {
            Graphics g = c.CreateGraphics();
            float dx = g.DpiX
                , dy = g.DpiY
                , fontsScale = Math.Max(dx, dy) / WinDefaultDpi
                ;
            g.Dispose();
            return fontsScale;
        }
    }
}
