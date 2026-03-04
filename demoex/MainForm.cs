using Library.Tovar;
using Library.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoex
{
    public partial class MainForm : Form
    {
        private List<Tovar> allTovars_ = new List<Tovar>();
        private MySqlTovarRepository mySqlTovarRepository;
        private User currentUser;
        public MainForm(User user)
        {
            InitializeComponent();
            mySqlTovarRepository = new MySqlTovarRepository();
            allTovars_ = mySqlTovarRepository.ReadAllTovars();
            ShowTovars(allTovars_);
            currentUser = user;
            if (user == null)
            {
                this.Text = $"Товары для гостя";
            }
            else { this.Text = $"Товары - {user.name} - {user.role}";}
        }

        private void ShowTovars(List<Tovar> allTovars_)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var t in allTovars_)
            {
                var card = new CardOfTovar();
                card.ShowTovarInfo(t);

                card.Margin = new Padding(10);

                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}
