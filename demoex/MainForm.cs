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

            // Загружаем поставщиков в комбобокс
            LoadSuppliersToComboBox();

            // Показываем все товары
            ShowTovars(allTovars_);

            // Подключаем события
            txtSearch.TextChanged += txtSearch_TextChanged;
            cbxSupplier.SelectedIndexChanged += cbxSupplier_SelectedIndexChanged;

            currentUser = user;
            UserRoleMappingForGuest();
            if (user == null)
            {
                this.Text = $"Товары для гостя";
            }
            else
            {
                this.Text = $"Товары - {user.name} - {user.role}";
            }
        }

        private void ShowTovars(List<Tovar> allTovars_)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var t in allTovars_)
            {
                var card = new CardOfTovar();
                card.ShowTovarInfo(t);

                card.Margin = new Padding(10);
                card.Tag = t;
                card.DoubleClick += cardOfTovar1_DoubleClick;

                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            OrdersForm form = new OrdersForm(currentUser);
            form.Show();
        }

        private void UserRoleMappingForGuest()
        {
            if (currentUser == null)
            {
                btnAdd.Enabled = false;
                deleteBtn.Enabled = false;
                orderButton.Enabled = false;
                txtSearch.Enabled = false;
                cbxSupplier.Enabled = false;
                label2.ForeColor = Color.Red;
                label2.Text = "Гостю доступен только просмотр товаров!";
                label1.Visible = false;
                label3.Visible = false;
            }
        }

        private void cardOfTovar1_DoubleClick(object sender, EventArgs e)
        {
            var card = sender as Control;
            if (card == null || card.Tag == null) return;

            var tovar = card.Tag as Tovar;
            if (tovar == null) return;

            AddEditForm editForm = new AddEditForm(mySqlTovarRepository, 1, tovar);
            DialogResult result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    mySqlTovarRepository.EditTovar(editForm.GetNewTovar());
                    allTovars_.Clear();
                    allTovars_ = mySqlTovarRepository.ReadAllTovars();
                    ShowTovars(allTovars_);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                  "Ошибка редактирования товара",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditForm addForm = new AddEditForm(mySqlTovarRepository, 0, null);
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    mySqlTovarRepository.AddTovar(addForm.GetNewTovar());
                    allTovars_.Clear();
                    allTovars_ = mySqlTovarRepository.ReadAllTovars();
                    ShowTovars(allTovars_);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Ошибка добавления клиента",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            RemoveTovarForm removeForm = new RemoveTovarForm(mySqlTovarRepository);

            // Подписываемся на событие закрытия формы
            removeForm.FormClosed += (s, args) =>
            {
                // После закрытия формы удаления обновляем список товаров
                allTovars_.Clear();
                allTovars_ = mySqlTovarRepository.ReadAllTovars();
                ShowTovars(allTovars_);
            };

            removeForm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void ApplyFilters()
        {
            List<Tovar> filteredTovars = allTovars_;

            // Применяем фильтр по поставщику
            if (cbxSupplier.SelectedItem != null && cbxSupplier.SelectedItem.ToString() != "Все поставщики")
            {
                string selectedSupplier = cbxSupplier.SelectedItem.ToString();
                filteredTovars = filteredTovars
                    .Where(t => t.supplier == selectedSupplier)
                    .ToList();
            }

            // Применяем поиск, если есть текст в поиске
            string searchText = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                filteredTovars = filteredTovars.Where(t =>
                    (t.articul?.ToLower().Contains(searchText) ?? false) ||
                    (t.name?.ToLower().Contains(searchText) ?? false) ||
                    (t.unit?.ToLower().Contains(searchText) ?? false) ||
                    (t.price.ToString().Contains(searchText)) ||
                    (t.supplier?.ToLower().Contains(searchText) ?? false) ||
                    (t.manufacturer?.ToLower().Contains(searchText) ?? false) ||
                    (t.category?.ToLower().Contains(searchText) ?? false) ||
                    (t.discount.ToString().Contains(searchText)) ||
                    (t.stockquantity.ToString().Contains(searchText)) ||
                    (t.description?.ToLower().Contains(searchText) ?? false)
                ).ToList();
            }
            ShowTovars(filteredTovars);
        }

        private void LoadSuppliersToComboBox()
        {
            // Получаем уникальных поставщиков из списка товаров
            var uniqueSuppliers = allTovars_
                .Where(t => !string.IsNullOrEmpty(t.supplier)) // Исключаем пустых поставщиков
                .Select(t => t.supplier)
                .Distinct() // Уникальные значения
                .OrderBy(s => s) // Сортируем по алфавиту
                .ToList();

            // Очищаем комбобокс
            cbxSupplier.Items.Clear();

            // Добавляем пункт "Все поставщики"
            cbxSupplier.Items.Add("Все поставщики");

            // Добавляем всех поставщиков
            foreach (var supplier in uniqueSuppliers)
            {
                cbxSupplier.Items.Add(supplier);
            }

            // Выбираем "Все поставщики" по умолчанию
            if (cbxSupplier.Items.Count > 0)
                cbxSupplier.SelectedIndex = 0;
        }
    }
}
