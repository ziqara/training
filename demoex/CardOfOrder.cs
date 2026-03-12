using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.View;
using Library;

namespace demoex
{
    public partial class CardOfOrder: UserControl, IOrderView
    {
        private Order order_;

        public CardOfOrder()
        {
            InitializeComponent();
            AssignDoubleClickRecursive(this);
        }

        public Order GetOrderInfo()
        {
            return order_;
        }

        public void ShowOrderInfo(Order order)
        {
            lblArticul.Text = order.productArticulAndQuantity;
            lblStatus.Text = order.status;
            lblPickUpPoint.Text = order.pickUpPointId.ToString();
            lblDateOfOrder.Text = order.dateOfOrder.ToString("dd.MM.yyyy");
            lblDateOfDelivery.Text = order.dateOfDelivery.ToString("dd.MM.yyyy");
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
