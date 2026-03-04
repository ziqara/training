using Library.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoex
{
    public partial class LoginForm: Form
    {
        private UserModel model_ = new UserModel();
        public User AuthenticatedUser { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string login = txtLogin.Text;
            string password = txtPassword.Text;

            User user = model_.Authorization(login, password);
            if (user != null)
            {
                AuthenticatedUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Пароль неверен. Убедитесь, что:\n• Используется правильный регистр\n• Нет лишних пробелов\n• Выбран правильный пользователь",
                "Не удалось войти",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;
            User user = model_.Authorization(login, password);
            AuthenticatedUser = user;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
