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

        // Для работы с формой добавим список товаров
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        [DisplayName("Дата заказа")]
        public DateTime dateOfOrder { get; set; }

        [DisplayName("Дата доставки")]
        public DateTime dateOfDelivery { get; set; }

        [DisplayName("ID пункта выдачи")]
        public int pickUpPointId { get; set; }

        // Для отображения адреса пункта выдачи
        public string PickUpPointAddress { get; set; }

        [DisplayName("Логин пользователя")]
        public string user_login { get; set; }

        [DisplayName("ФИО авторизированного клиента")]
        public string name { get; set; }

        [DisplayName("Код для получения")]
        public int code { get; set; }

        [DisplayName("Статус заказа")]
        public string status { get; set; }
    }
}