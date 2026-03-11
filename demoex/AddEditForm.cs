using Library.Tovar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoex
{
    public partial class AddEditForm : Form
    {
        private Tovar newTovar_;
        private string selectedImagePath_;
        private MySqlTovarRepository model_;
        private int type_;
        public AddEditForm(MySqlTovarRepository model, int type, Tovar tovar)
        {
            InitializeComponent();
            newTovar_ = tovar;
            model_ = model;
            type_ = type;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (type_ == 0)
            {
                Tovar addTovar = new Tovar(txtArticul.Text);
                addTovar.name = txtName.Text;
                addTovar.unit = txtUnit.Text;
                addTovar.price = (int)numPrice.Value;
                addTovar.supplier = txtSupplier.Text;
                addTovar.manufacturer = txtManufacturer.Text;
                addTovar.category = txtCategory.Text;
                addTovar.discount = (int)numDiscount.Value;
                addTovar.stockquantity = (int)numStockQuantity.Value;
                addTovar.description = txtDescription.Text;
                addTovar.picture = selectedImagePath_;

                newTovar_ = (Tovar)addTovar;
                DialogResult = DialogResult.OK;
            }

            if (type_ == 1)
            {
                newTovar_.name = txtName.Text;
                newTovar_.unit = txtUnit.Text;
                newTovar_.price = (int)numPrice.Value;
                newTovar_.supplier = txtSupplier.Text;
                newTovar_.manufacturer = txtManufacturer.Text;
                newTovar_.category = txtCategory.Text;
                newTovar_.discount = (int)numDiscount.Value;
                newTovar_.stockquantity = (int)numStockQuantity.Value;
                newTovar_.description = txtDescription.Text;
                newTovar_.picture = selectedImagePath_;
                DialogResult = DialogResult.OK;
            }
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            if (type_ == 0)
            {
                txtArticul.Text = string.Empty;
                txtName.Text = string.Empty;
                txtUnit.Text = string.Empty;
                numPrice.Value = 0;
                txtSupplier.Text = string.Empty;
                txtManufacturer.Text = string.Empty;
                txtCategory.Text = string.Empty;
                numDiscount.Value = 0;
                numStockQuantity.Value = 0;
                txtDescription.Text = string.Empty;
                this.Text = "Добавление товара";
            }

            if (type_ == 1)
            {
                txtArticul.Text = newTovar_.articul;
                txtName.Text = newTovar_.name;
                txtUnit.Text = newTovar_.unit;
                numPrice.Value = newTovar_.price;
                txtSupplier.Text = newTovar_.supplier;
                txtManufacturer.Text = newTovar_.manufacturer;
                txtCategory.Text = newTovar_.category;
                numDiscount.Value = newTovar_.discount;
                numStockQuantity.Value = newTovar_.stockquantity;
                txtDescription.Text = newTovar_.description;
                btnImage.Text = "Обновить";
                // Загружаем картинку
                string fullPath = Path.Combine(Application.StartupPath, "Resources", newTovar_.picture);
                if (File.Exists(fullPath))
                {
                    imageBox.Image = Image.FromFile(fullPath);
                    imageBox.SizeMode = PictureBoxSizeMode.Zoom;
                    selectedImagePath_ = newTovar_.picture; // сохраняем имя файла
                }
                this.Text = "Редактирование товара";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Tovar GetNewTovar()
        {
            return newTovar_;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                openFileDialog.Title = "Выберите изображение для товара";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string sourcePath = openFileDialog.FileName;
                        string fileName = Path.GetFileName(sourcePath);

                        // Создаем путь к папке Resources в директории приложения
                        string resourcesPath = Path.Combine(Application.StartupPath, "Resources");

                        // Полный путь к файлу в папке Resources
                        string targetPath = Path.Combine(resourcesPath, fileName);

                        // Копируем файл в папку Resources
                        File.Copy(sourcePath, targetPath, true);

                        // Сохраняем только имя файла (без пути)
                        selectedImagePath_ = fileName;

                        // Загружаем изображение в PictureBox
                        imageBox.Image?.Dispose();
                        imageBox.Image = Image.FromFile(targetPath);
                        imageBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

