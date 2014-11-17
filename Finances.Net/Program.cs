using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finances.Net
{
    static class Program
    {

        private static Form1 _form1 = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _form1 = new Form1();
            Application.Run(_form1);
        }

        internal static void Exit()
        {
            _form1._Close();
        }
    }
}
