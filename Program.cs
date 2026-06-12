using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookshop_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            // Show login as a modal dialog first. If login succeeds, run the main WelcomeFrame as the application's main form.
            using (var login = new Bookshop.Login())
            {
                var dlg = login.ShowDialog();
                if (dlg == System.Windows.Forms.DialogResult.OK)
                {
                    Application.Run(new Bookshop.WelcomeFrame());
                }
            }
        }
    }
    }
