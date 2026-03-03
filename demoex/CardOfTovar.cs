using Library.Tovar;
using Library.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoex
{
    public partial class CardOfTovar : UserControl, ITovarView
    {
        private Tovar tovar_;
        public CardOfTovar()
        {
            InitializeComponent();
        }

        public Tovar GetTovarInfo()
        {
            return tovar_;
        }

        public void ShowTovarInfo(Tovar tovar)
        {
            tovar_ = tovar;
            lblName.Text = tovar.name;
            lblCategory.Text = tovar.category;
            lblDesctiption.Text = tovar.description;
            lblManufacturer.Text = tovar.manufacturer;
            lblSupplier.Text = tovar.supplier;
            lblPrice.Text = tovar.price.ToString();
            lblUnit.Text = tovar.unit;
            lblStockQuantity.Text = tovar.stockquantity.ToString();
            lblDiscount.Text = tovar.discount.ToString();

            string fullPath = Path.Combine(Application.StartupPath, "Resources", tovar.picture);

            if (File.Exists(fullPath))
                pictureBox1.Image = Image.FromFile(fullPath);
        }
    }
}
