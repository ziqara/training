using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Orders
{
    public class MySqlOrdersRepositroy : IOrdersRepository
    {
        private const string connStr = "Host=192.168.1.48;Port=5432;Database=shoes_shop;Username=st50-6;Password=506;";
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                connection.Open();

                string sql = "SELECT \r\n    " +
                    "o.number OrderNumber,\r\n    " +
                    "o.dateoforder OrderDate,\r\n    " +
                    "o.dateofdelivey DeliveryDate,\r\n    " +
                    "o.pick_up_point_id PickupPointId,\r\n    " +
                    "u.name CustomerName,\r\n    o.code OrderCode,\r\n    " +
                    "o.status OrderStatus,\r\n    " +
                    "STRING_AGG(CONCAT(oi.product_articul, ', ', oi.quantity), '; ') AS Products\r\n" +
                    "FROM \r\n    " +
                    "\"orders\" o\r\n" +
                    "JOIN \r\n    " +
                    "order_items oi ON o.number = oi.order_number\r\n" +
                    "JOIN\r\n    \"user\" u ON o.user_login = u.login\r\n" +
                    "GROUP BY \r\n    o.number, o.dateoforder, o.dateofdelivey, o.pick_up_point_id, u.name, o.code, o.status;";

                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.number = reader.GetInt32(0);
                        order.dateOfOrder = reader.GetDateTime(1);
                        order.dateOfDelivery = reader.GetDateTime(2);
                        order.pickUpPointId = reader.GetInt32(3);
                        order.name = reader.GetString(4);
                        order.code = reader.GetInt32(5);
                        order.status = reader.GetString(6);
                        order.productArticulAndQuantity = reader.GetString(7);

                        orders.Add(order);
                    }
                }
                return orders;
            }
        }
    }
}
