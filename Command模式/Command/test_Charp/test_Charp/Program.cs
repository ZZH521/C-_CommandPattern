using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace test_Charp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PublicFunction.LoadConfig();
            Application.Run(new Form1());
        }
    }
}
