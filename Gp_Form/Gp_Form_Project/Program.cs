using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProgrammingFormProject
{
    static class Program
    {
        public static ApplicationContext End;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            End = new ApplicationContext();
            End.MainForm = new MinePage();
            Application.Run(End);
        }
    }
}
