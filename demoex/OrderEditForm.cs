using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Orders;
using Library.Tovar;
using Library.User;
using Library;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace demoex
{
    public partial class OrderEditForm : Form
    {
        private MySqlOrdersRepositroy ordersRepository;
        private int mode; // 0 - добавление, 1 - редактирование
        private Order currentOrder;
        private User currentUser;
        private List<PickUpPoint> pickUpPoints;
        private List<Tovar> availableProducts;
        private List<User> availableUsers;
        private BindingList<OrderItem> orderItems;
        private Random random = new Random();

        public OrderEditForm(MySqlOrdersRepositroy repository, int editMode, Order order, User user)
        {
            InitializeComponent();
            ordersRepository = repository;
            mode = editMode;
            currentOrder = order;
            currentUser = user;

            LoadData();
            SetupForm();
        }

        private void LoadData()
        {
            try
            {
                pickUpPoints = ordersRepository.GetPickUpPoints();
                availableProducts = ordersRepository.GetAvailableProducts();
                availableUsers = ordersRepository.GetUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupForm()
        {
            // Заполняем комбобокс пунктов выдачи
            cmbPickUpPoint.DisplayMember = "address";
            cmbPickUpPoint.ValueMember = "id";
            cmbPickUpPoint.DataSource = new BindingList<PickUpPoint>(pickUpPoints);

            // Заполняем комбобокс статусов
            cmbStatus.Items.Clear();
            foreach (var status in ordersRepository.GetAvailableStatuses())
            {
                cmbStatus.Items.Add(status);
            }

            // Заполняем комбобокс товаров
            cmbProduct.DisplayMember = "name";
            cmbProduct.ValueMember = "articul";
            cmbProduct.DataSource = new BindingList<Tovar>(availableProducts);

            // Заполняем комбобокс пользователей
            cmbUser.DisplayMember = "name";
            cmbUser.ValueMember = "login";
            cmbUser.DataSource = new BindingList<User>(availableUsers);

            // Настройка DataGridView для товаров
            SetupOrderItemsGrid();

            if (mode == 0) // Добавление
            {
                this.Text = "Добавление заказа";
                currentOrder = new Order();
                currentOrder.dateOfOrder = DateTime.Now;
                currentOrder.dateOfDelivery = DateTime.Now.AddDays(3);
                currentOrder.status = "Новый";

                if (currentUser != null)
                {
                    currentOrder.user_login = currentUser.login;

                    // Выбираем текущего пользователя в комбобоксе
                    var userToSelect = availableUsers.FirstOrDefault(u => u.login == currentUser.login);
                    if (userToSelect != null)
                        cmbUser.SelectedItem = userToSelect;
                }

                // Генерируем случайный код для получения (от 1000 до 9999)
                currentOrder.code = random.Next(1000, 9999);

                orderItems = new BindingList<OrderItem>();
            }
            else // Редактирование
            {
                this.Text = $"Редактирование заказа №{currentOrder.number}";
                orderItems = new BindingList<OrderItem>(currentOrder.OrderItems);

                // Выбираем пользователя в комбобоксе
                var userToSelect = availableUsers.FirstOrDefault(u => u.login == currentOrder.user_login);
                if (userToSelect != null)
                    cmbUser.SelectedItem = userToSelect;
            }

            // Заполняем форму данными
            DisplayOrderData();

            // Настраиваем видимость полей в зависимости от роли
            if (currentUser != null && currentUser.role != "Администратор")
            {
                // Обычные пользователи не могут менять статус и пользователя
                cmbStatus.Enabled = false;
                cmbUser.Enabled = false;
                txtCode.ReadOnly = true;
            }
        }

        private void SetupOrderItemsGrid()
        {
            dataGridViewItems.AutoGenerateColumns = false;
            dataGridViewItems.Columns.Clear();

            // Колонка с артикулом
            DataGridViewTextBoxColumn articulColumn = new DataGridViewTextBoxColumn();
            articulColumn.DataPropertyName = "product_articul"; // Должно совпадать со свойством в OrderItem
            articulColumn.HeaderText = "Артикул";
            articulColumn.Width = 100;
            articulColumn.ReadOnly = true;
            dataGridViewItems.Columns.Add(articulColumn);

            // Колонка с названием товара
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "product_name"; // Должно совпадать со свойством в OrderItem
            nameColumn.HeaderText = "Товар";
            nameColumn.Width = 200;
            nameColumn.ReadOnly = true;
            dataGridViewItems.Columns.Add(nameColumn);

            // Колонка с количеством
            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.DataPropertyName = "quantity"; // Должно совпадать со свойством в OrderItem
            quantityColumn.HeaderText = "Количество";
            quantityColumn.Width = 80;
            dataGridViewItems.Columns.Add(quantityColumn);

            // Колонка с ценой
            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.DataPropertyName = "price"; // Должно совпадать со свойством в OrderItem
            priceColumn.HeaderText = "Цена";
            priceColumn.Width = 80;
            priceColumn.DefaultCellStyle.Format = "C";
            priceColumn.ReadOnly = true;
            dataGridViewItems.Columns.Add(priceColumn);

            // Колонка со стоимостью
            DataGridViewTextBoxColumn totalColumn = new DataGridViewTextBoxColumn();
            totalColumn.HeaderText = "Стоимость";
            totalColumn.Width = 100;
            totalColumn.DefaultCellStyle.Format = "C";
            totalColumn.ReadOnly = true;
            // Используем вычисляемое свойство TotalPrice из класса OrderItem
            totalColumn.DataPropertyName = "TotalPrice";
            dataGridViewItems.Columns.Add(totalColumn);

            // Добавляем кнопку удаления
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "";
            deleteColumn.Text = "Удалить";
            deleteColumn.UseColumnTextForButtonValue = true;
            deleteColumn.Width = 60;
            dataGridViewItems.Columns.Add(deleteColumn);

            dataGridViewItems.CellClick += DataGridViewItems_CellClick;
            dataGridViewItems.CellValueChanged += DataGridViewItems_CellValueChanged;
            dataGridViewItems.DataSource = orderItems;
        }

        private void DisplayOrderData()
        {
            txtOrderNumber.Text = currentOrder.number > 0 ? currentOrder.number.ToString() : "(новый)";
            dtpOrderDate.Value = currentOrder.dateOfOrder;
            dtpDeliveryDate.Value = currentOrder.dateOfDelivery;

            if (currentOrder.pickUpPointId > 0)
            {
                var pointToSelect = pickUpPoints.FirstOrDefault(p => p.id == currentOrder.pickUpPointId);
                if (pointToSelect != null)
                    cmbPickUpPoint.SelectedItem = pointToSelect;
            }

            cmbStatus.SelectedItem = currentOrder.status;
            txtCode.Text = currentOrder.code.ToString();

            // УБИРАЕМ ТЕСТОВЫЕ ДАННЫЕ!
            // Просто обновляем DataSource
            dataGridViewItems.DataSource = null;
            dataGridViewItems.DataSource = orderItems;
            dataGridViewItems.Refresh();

            CalculateTotal();
        }

        private void UpdateOrderFromForm()
        {
            currentOrder.dateOfOrder = dtpOrderDate.Value.Date;
            currentOrder.dateOfDelivery = dtpDeliveryDate.Value.Date;

            if (cmbPickUpPoint.SelectedItem != null)
            {
                currentOrder.pickUpPointId = ((PickUpPoint)cmbPickUpPoint.SelectedItem).id;
            }

            if (cmbUser.SelectedItem != null)
            {
                currentOrder.user_login = ((User)cmbUser.SelectedItem).login;
                currentOrder.name = ((User)cmbUser.SelectedItem).name;
            }

            if (int.TryParse(txtCode.Text, out int code))
            {
                currentOrder.code = code;
            }

            if (cmbStatus.SelectedItem != null)
            {
                currentOrder.status = cmbStatus.SelectedItem.ToString();
            }

            // ВАЖНО: сбрасываем ID у всех товаров перед сохранением
            foreach (var item in orderItems)
            {
                item.id = 0; // Устанавливаем 0, чтобы БД сама сгенерировала новые ID
            }

            currentOrder.OrderItems = orderItems.ToList();

            // Формируем строковое представление товаров
            currentOrder.productArticulAndQuantity = string.Join("; ",
                orderItems.Select(i => $"{i.product_articul}, {i.quantity}"));
        }

        private void CalculateTotal()
        {
            decimal total = orderItems.Sum(i => i.quantity * i.price);
            lblTotal.Text = $"Итого: {total:C}";
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem == null)
            {
                MessageBox.Show("Выберите товар", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Введите корректное количество", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Tovar selectedProduct = (Tovar)cmbProduct.SelectedItem;

            // Проверяем наличие на складе
            if (quantity > selectedProduct.stockquantity)
            {
                MessageBox.Show($"На складе только {selectedProduct.stockquantity} шт.",
                    "Недостаточно товара", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, есть ли уже такой товар в заказе
            var existingItem = orderItems.FirstOrDefault(i => i.product_articul == selectedProduct.articul);
            if (existingItem != null)
            {
                // Проверяем, не превысит ли общее количество наличие на складе
                if (existingItem.quantity + quantity > selectedProduct.stockquantity)
                {
                    MessageBox.Show($"Всего на складе {selectedProduct.stockquantity} шт. Уже в заказе {existingItem.quantity} шт.",
                        "Недостаточно товара", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                existingItem.quantity += quantity;
            }
            else
            {
                OrderItem newItem = new OrderItem
                {
                    product_articul = selectedProduct.articul,
                    product_name = selectedProduct.name,
                    quantity = quantity,
                    price = selectedProduct.price
                };
                orderItems.Add(newItem);
            }

            dataGridViewItems.Refresh();
            CalculateTotal();

            // Очищаем поля ввода
            txtQuantity.Clear();
            cmbProduct.SelectedIndex = -1;
        }

        private void DataGridViewItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что клик был по кнопке удаления (последняя колонка)
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewItems.Columns.Count - 1)
            {
                if (mode == 1 && currentUser?.role != "Администратор")
                {
                    MessageBox.Show("Только администратор может удалять товары из заказа",
                        "Доступ запрещен", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Удалить товар из заказа?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    orderItems.RemoveAt(e.RowIndex);
                    CalculateTotal();
                }
            }
        }

        private void DataGridViewItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2) // Колонка количества
            {
                var item = orderItems[e.RowIndex];
                var product = availableProducts.FirstOrDefault(p => p.articul == item.product_articul);

                if (product != null && item.quantity > product.stockquantity)
                {
                    MessageBox.Show($"На складе только {product.stockquantity} шт.",
                        "Недостаточно товара", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    item.quantity = product.stockquantity;
                    dataGridViewItems.Refresh();
                }

                CalculateTotal();
            }
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            txtCode.Text = random.Next(1000, 9999).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация
            if (cmbPickUpPoint.SelectedItem == null)
            {
                MessageBox.Show("Выберите пункт выдачи", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbUser.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус заказа", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCode.Text) || !int.TryParse(txtCode.Text, out _))
            {
                MessageBox.Show("Введите корректный код получения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (orderItems.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы один товар в заказ", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // ВАЖНО: сбрасываем ID у товаров перед сохранением
                foreach (var item in orderItems)
                {
                    item.id = 0;
                }

                UpdateOrderFromForm();

                if (mode == 0) // Добавление
                {
                    ordersRepository.AddOrder(currentOrder);
                    MessageBox.Show($"Заказ успешно создан! Номер заказа: {currentOrder.number}",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Редактирование
                {
                    ordersRepository.UpdateOrder(currentOrder);
                    MessageBox.Show("Заказ успешно обновлен", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения заказа: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}