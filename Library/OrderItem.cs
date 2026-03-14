using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class OrderItem
    {
        public int id { get; set; }
        public int order_number { get; set; }
        public string product_articul { get; set; }
        public string product_name { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }

        // Вычисляемое поле для отображения в DataGridView
        public decimal TotalPrice => quantity * price;
    }
}