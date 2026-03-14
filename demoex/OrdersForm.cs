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
            LoadOrders();
            CheckUserPermissions();
            currentUser = user;
            if (user != null)
            { this.Text = $"Заказы - {user.name} - {user.role}"; }
        }

        private void LoadOrders()
        {
            try
            {
                allOrders = ordersRepositroy.GetAllOrders();
                ShowOrders(allOrders);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowOrders(List<Order> allOrders)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var order in allOrders)
            {
                var card = new CardOfOrder();
                card.ShowOrderInfo(order);

                card.Margin = new Padding(10);
                card.Tag = order;
                card.DoubleClick += cardOfOrder1_DoubleClick;

                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void cardOfOrder1_DoubleClick(object sender, EventArgs e)
        {
            var card = sender as Control;
            if (card?.Tag is Order order)
            {
                EditOrder(order);
            }
        }

        private void EditOrder(Order order)
        {
            if (currentUser?.role != "Администратор")
            {
                MessageBox.Show("Только администратор может редактировать заказы",
                    "Доступ запрещен", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OrderEditForm editForm = new OrderEditForm(ordersRepositroy, 1, order, currentUser);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrders();
            }
        }

        private void CheckUserPermissions()
        {
            if (currentUser == null || currentUser.role != "Администратор")
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;

                if (currentUser == null)
                {
                    Label lblGuestInfo = new Label
                    {
                        Text = "Гостю доступен только просмотр заказов",
                        ForeColor = Color.Red,
                        Location = new Point(10, 10),
                        AutoSize = true
                    };
                    this.Controls.Add(lblGuestInfo);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (currentUser?.role != "Администратор")
            {
                MessageBox.Show("Только администратор может создавать заказы",
                    "Доступ запрещен", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OrderEditForm editForm = new OrderEditForm(ordersRepositroy, 0, null, currentUser);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrders();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для удаления дважды кликните по карточке заказа и нажмите кнопку удаления в форме редактирования",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
