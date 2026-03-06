using Library;
using Library.Orders;
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
            orderDataTable.Font = new System.Drawing.Font("Times New Roman", 12F);

            currentUser = user;
            if (user != null)
            { this.Text = $"Заказы - {user.name} - {user.role}"; }
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            orderDataTable.DataSource = allOrders;
        }
    }
}
