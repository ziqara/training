using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Order
    {

        [DisplayName("Номер заказа")]
        public int number { get; set; }
        [DisplayName("Артикул заказа")]
        public string productArticulAndQuantity { get; set; }
        [DisplayName("Дата заказа")]
        public DateTime dateOfOrder {get; set;}
        [DisplayName("Дата доставки")]
        public DateTime dateOfDelivery { get; set; }
        [DisplayName("Адрес пункта выдачи")]
        public int pickUpPointId { get; set; }
        [DisplayName("ФИО авторизированного клиента")]
        public string name { get; set; }
        [DisplayName("Код для получения")]
        public int code { get; set; }
        [DisplayName("Статус заказа")]
        public string status { get; set; }
    }
}
