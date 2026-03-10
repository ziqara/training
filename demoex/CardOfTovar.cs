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
            lblDiscount.BackColor = ColorTranslator.FromHtml("#7FFF00");
            AssignDoubleClickRecursive(this);
        }

        public Tovar GetTovarInfo()
        {
            return tovar_;
        }

        public void ShowTovarInfo(Tovar tovar)
        {
            this.BackColor = ColorTranslator.FromHtml("#00FA9A");
            tovar_ = tovar;
            lblName.Text = tovar.name;
            lblCategory.Text = tovar.category;
            lblDesctiption.Text = tovar.description;
            lblManufacturer.Text = tovar.manufacturer;
            lblSupplier.Text = tovar.supplier;
            ShowDiscountPrice(tovar);

            lblUnit.Text = tovar.unit;
            ShowQuantitySock(tovar);
            lblDiscount.Text = tovar.discount.ToString();

            pictureBox1.BackColor = Color.White;
            string fullPath = Path.Combine(Application.StartupPath, "Resources", tovar.picture);
            if (File.Exists(fullPath))
               pictureBox1.Image = Image.FromFile(fullPath);
        }

        public void ShowDiscountPrice(Tovar tovar)
        {
            tovar_ = tovar;
            if (tovar.discount > 15)
            {
                lblPrice.Text = tovar.price.ToString();
                lblPrice.ForeColor = Color.Red;
                lblPrice.Font = new Font(lblPrice.Font, FontStyle.Strikeout);
                Discount(tovar);
                this.BackColor = ColorTranslator.FromHtml("#2E8B57");
                pictureBox1.BackColor = Color.White;
            }
            else
            {
                lblPrice.Text = tovar.price.ToString();
                discountPrice.Hide();
            }
        }

        public void Discount(Tovar tovar)
        {
            tovar_ = tovar;
            discountPrice.Text = (tovar.price - (tovar.price / 100 * tovar.discount)).ToString();
        }

        public void ShowQuantitySock(Tovar tovar)
        {
            tovar_ = tovar;
            if (tovar.stockquantity == 0)
            {
                lblStockQuantity.Text = tovar.stockquantity.ToString();
                lblStockQuantity.ForeColor = Color.Blue;
                label6.ForeColor = Color.Blue;
            }
            else
            {
                lblStockQuantity.Text = tovar.stockquantity.ToString();
            }
        }

        private void AssignDoubleClickRecursive(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.DoubleClick += (s, e) => this.OnDoubleClick(e);
            }
        }
    }
}
