using Library;
using Library.Orders;
using Library.Tovar;
using Library.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoex
{
    public partial class OrdersForm: Form
    {
        private List<Order> allOrders = new List<Order>();
        private MySqlOrdersRepositroy ordersRepositroy;
        private User currentUser;
        public OrdersForm(User user)
        {
            InitializeComponent();
            ordersRepositroy = new MySqlOrdersRepositroy();
            allOrders = ordersRepositroy.GetAllOrders();
            ShowOrders(allOrders);

            currentUser = user;
            if (user != null)
            { this.Text = $"Заказы - {user.name} - {user.role}"; }
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            
        }

        private void ShowOrders(List<Order> allOrders)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var t in allOrders)
            {
                var card = new CardOfOrder();
                card.ShowOrderInfo(t);

                card.Margin = new Padding(10);
                card.Tag = t;
                card.DoubleClick += cardOfOrder1_DoubleClick;

                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void cardOfOrder1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("редактирование");
        }
    }
}
