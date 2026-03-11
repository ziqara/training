using Library.Tovar;
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
    public partial class RemoveTovarForm: Form
    {
        private MySqlTovarRepository model_;
        private List<Tovar> allTovars_;

        public RemoveTovarForm(MySqlTovarRepository model)
        {
            InitializeComponent();
            model_ = model;
            allTovars_ = new List<Tovar>();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли артикул
            if (comboBoxArticul.SelectedItem == null)
            {
                MessageBox.Show("Выберите артикул товара для удаления",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем выбранный артикул
            string selectedArticul = comboBoxArticul.SelectedItem.ToString();

            // Находим товар по артикулу
            Tovar tovarToDelete = allTovars_.FirstOrDefault(t => t.articul == selectedArticul);

            if (tovarToDelete == null)
            {
                MessageBox.Show("Товар не найден", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ПРОВЕРЯЕМ, ЕСТЬ ЛИ ЗАКАЗЫ С ЭТИМ ТОВАРОМ
            try
            {
                if (model_.HasOrder(tovarToDelete.articul))
                {
                    MessageBox.Show(
                        $"Невозможно удалить товар '{tovarToDelete.name}' (арт. {tovarToDelete.articul}).\n\n" +
                        $"Данный товар используется в заказах.\n" +
                        $"Удаление товара, который есть в заказах, невозможно.",
                        "Удаление невозможно",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return; // ВЫХОДИМ, НЕ УДАЛЯЕМ
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке заказов: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Если дошли сюда - значит заказов нет, можно удалять
            DialogResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить товар?\n\n" +
                $"Артикул: {tovarToDelete.articul}\n" +
                $"Название: {tovarToDelete.name}\n" +
                $"Цена: {tovarToDelete.price}",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Удаляем товар (теперь можно, т.к. проверили что заказов нет)
                    model_.RemoveTovar(tovarToDelete);

                    // Обновляем список
                    allTovars_ = model_.ReadAllTovars();

                    // Обновляем комбобокс
                    comboBoxArticul.Items.Clear();
                    foreach (var tovar in allTovars_)
                    {
                        comboBoxArticul.Items.Add(tovar.articul);
                    }

                    // Если остались товары, выбираем первый
                    if (comboBoxArticul.Items.Count > 0)
                        comboBoxArticul.SelectedIndex = 0;

                    MessageBox.Show($"Товар '{tovarToDelete.name}' успешно удален!",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении товара: {ex.Message}",
                        "Ошибка удаления",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void RemoveTovarForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Загружаем все товары
                allTovars_ = model_.ReadAllTovars();

                // Очищаем комбобокс
                comboBoxArticul.Items.Clear();

                // Заполняем комбобокс артикулами
                foreach (var tovar in allTovars_)
                {
                    comboBoxArticul.Items.Add(tovar.articul);
                }

                // Если есть товары, выбираем первый
                if (comboBoxArticul.Items.Count > 0)
                    comboBoxArticul.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки товаров: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
