using Library.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoex
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginform = new LoginForm();

            if (loginform.ShowDialog() == DialogResult.OK)
            {
                User authenticatedUser = loginform.AuthenticatedUser;
                Application.Run(new MainForm(authenticatedUser));
            }
            else
            {
                Application.Exit();
            }
            
        }
    }
}
