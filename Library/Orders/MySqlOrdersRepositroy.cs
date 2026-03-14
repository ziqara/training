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

        public void AddOrder(Order order)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                connection.Open();

                // Начинаем транзакцию
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Вставляем заказ
                        string sql = @"INSERT INTO orders 
                    (dateoforder, dateofdelivey, pick_up_point_id, user_login, code, status)
                    VALUES 
                    (@dateOfOrder, @dateOfDelivery, @pickUpPointId, @userLogin, @code, @status)
                    RETURNING number;";

                        int orderNumber;
                        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@dateOfOrder", order.dateOfOrder.Date);
                            command.Parameters.AddWithValue("@dateOfDelivery", order.dateOfDelivery.Date);
                            command.Parameters.AddWithValue("@pickUpPointId", order.pickUpPointId);
                            command.Parameters.AddWithValue("@userLogin", order.user_login ?? "");
                            command.Parameters.AddWithValue("@code", order.code);
                            command.Parameters.AddWithValue("@status", order.status);

                            // Получаем сгенерированный номер заказа
                            orderNumber = Convert.ToInt32(command.ExecuteScalar());
                            order.number = orderNumber;
                        }

                        // Вставляем товары заказа
                        foreach (var item in order.OrderItems)
                        {
                            // ВАЖНО: не используем id из объекта
                            string itemSql = @"INSERT INTO order_items 
                        (order_number, product_articul, quantity)
                        VALUES 
                        (@orderNumber, @productArticul, @quantity);";

                            using (NpgsqlCommand itemCommand = new NpgsqlCommand(itemSql, connection, transaction))
                            {
                                itemCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
                                itemCommand.Parameters.AddWithValue("@productArticul", item.product_articul);
                                itemCommand.Parameters.AddWithValue("@quantity", item.quantity);

                                itemCommand.ExecuteNonQuery();
                            }

                            // Обновляем количество товара на складе (уменьшаем)
                            string updateStockSql = @"UPDATE tovar 
                        SET stockquantity = stockquantity - @quantity 
                        WHERE articul = @productArticul;";

                            using (NpgsqlCommand updateStockCommand = new NpgsqlCommand(updateStockSql, connection, transaction))
                            {
                                updateStockCommand.Parameters.AddWithValue("@quantity", item.quantity);
                                updateStockCommand.Parameters.AddWithValue("@productArticul", item.product_articul);
                                updateStockCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Ошибка при добавлении заказа: {ex.Message}", ex);
                    }
                }
            }
        }

        public void DeleteOrder(int orderNumber)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                connection.Open();

                // Начинаем транзакцию
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Получаем товары заказа для возврата на склад
                        List<OrderItem> items = GetOrderItems(orderNumber);

                        // Возвращаем товары на склад
                        foreach (var item in items)
                        {
                            string returnStockSql = @"UPDATE tovar 
                                SET stockquantity = stockquantity + @quantity 
                                WHERE articul = @productArticul;";

                            NpgsqlCommand returnStockCommand = new NpgsqlCommand(returnStockSql, connection, transaction);
                            returnStockCommand.Parameters.AddWithValue("@quantity", item.quantity);
                            returnStockCommand.Parameters.AddWithValue("@productArticul", item.product_articul);
                            returnStockCommand.ExecuteNonQuery();
                        }

                        // Удаляем товары заказа
                        string deleteItemsSql = "DELETE FROM order_items WHERE order_number = @orderNumber;";
                        NpgsqlCommand deleteItemsCommand = new NpgsqlCommand(deleteItemsSql, connection, transaction);
                        deleteItemsCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
                        deleteItemsCommand.ExecuteNonQuery();

                        // Удаляем заказ
                        string deleteOrderSql = "DELETE FROM orders WHERE number = @orderNumber;";
                        NpgsqlCommand deleteOrderCommand = new NpgsqlCommand(deleteOrderSql, connection, transaction);
                        deleteOrderCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
                        deleteOrderCommand.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }



        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                connection.Open();

                string sql = @"SELECT 
            o.number OrderNumber,
            o.dateoforder OrderDate,
            o.dateofdelivey DeliveryDate,
            o.pick_up_point_id PickupPointId,
            u.name CustomerName,
            o.user_login UserLogin,
            o.code OrderCode,
            o.status OrderStatus,
            pp.address PickupPointAddress,
            pp.postal_index PickupPointIndex,
            STRING_AGG(CONCAT(oi.product_articul, ', ', oi.quantity), '; ') AS Products
        FROM 
            orders o
        LEFT JOIN 
            order_items oi ON o.number = oi.order_number
        LEFT JOIN
            ""user"" u ON o.user_login = u.login
        LEFT JOIN
            pickuppoint pp ON o.pick_up_point_id = pp.id
        GROUP BY 
            o.number, o.dateoforder, o.dateofdelivey, o.pick_up_point_id, 
            o.user_login, u.name, o.code, o.status, pp.address, pp.postal_index
        ORDER BY o.number DESC;";

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
                        order.name = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        order.user_login = reader.GetString(5);
                        order.code = reader.GetInt32(6);
                        order.status = reader.GetString(7);
                        order.PickUpPointAddress = reader.IsDBNull(8) ? "" : $"{reader.GetString(8)} (индекс: {reader.GetInt32(9)})";
                        order.productArticulAndQuantity = reader.IsDBNull(10) ? "" : reader.GetString(10);

                        orders.Add(order);
                    }
                }
            }

            // Загружаем детали заказов
            foreach (var order in orders)
            {
                order.OrderItems = GetOrderItems(order.number);
            }

            return orders;
        }

        public List<Tovar.Tovar> GetAvailableProducts()
        {
            List<Library.Tovar.Tovar> products = new List<Library.Tovar.Tovar>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                connection.Open();

                string sql = "SELECT articul, name, price, stockquantity FROM tovar WHERE stockquantity > 0 ORDER BY name;";

                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Используем конструктор с артикулом
                        Library.Tovar.Tovar product = new Library.Tovar.Tovar(reader.GetString(0));

                        // Заполняем остальные свойства
                        product.name = reader.GetString(1);
                        product.price = reader.GetInt32(2);
                        product.stockquantity = reader.GetInt32(3);

                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public List<string> GetAvailableStatuses()
        {
            return new List<string>
            {
                "Новый",
                "В обработке",
                "Готов к выдаче",
                "Завершен"
            };
        }

        public Order GetOrderById(int orderNumber)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                connection.Open();

                string sql = @"SELECT 
            o.number OrderNumber,
            o.dateoforder OrderDate,
            o.dateofdelivey DeliveryDate,
            o.pick_up_point_id PickupPointId,
            o.user_login UserLogin,
            u.name CustomerName,
            o.code OrderCode,
            o.status OrderStatus,
            pp.address PickupPointAddress,
            pp.postal_index PickupPointIndex
        FROM 
            orders o
        LEFT JOIN
            ""user"" u ON o.user_login = u.login
        LEFT JOIN
            pickuppoint pp ON o.pick_up_point_id = pp.id
        WHERE 
            o.number = @orderNumber;";

                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@orderNumber", orderNumber);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Order order = new Order();
                        order.number = reader.GetInt32(0);
                        order.dateOfOrder = reader.GetDateTime(1);
                        order.dateOfDelivery = reader.GetDateTime(2);
                        order.pickUpPointId = reader.GetInt32(3);
                        order.user_login = reader.GetString(4);
                        order.name = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        order.code = reader.GetInt32(6);
                        order.status = reader.GetString(7);
                        order.PickUpPointAddress = reader.IsDBNull(8) ? "" : $"{reader.GetString(8)} (индекс: {reader.GetInt32(9)})";

                        reader.Close(); // Важно закрыть reader перед следующим запросом

                        // Загружаем детали заказа отдельным запросом
                        order.OrderItems = GetOrderItems(order.number);

                        return order;
                    }
                }
            }
            return null;
        }

        private List<OrderItem> GetOrderItems(int orderNumber)
        {
            List<OrderItem> items = new List<OrderItem>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                connection.Open();

                string sql = @"SELECT 
            oi.id,
            oi.product_articul,
            COALESCE(p.name, 'Неизвестный товар') as product_name,
            oi.quantity,
            COALESCE(p.price, 0) as price
        FROM 
            order_items oi
        LEFT JOIN
            tovar p ON oi.product_articul = p.articul
        WHERE 
            oi.order_number = @orderNumber;";

                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@orderNumber", orderNumber);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderItem item = new OrderItem();
                        item.id = reader.GetInt32(0);
                        item.order_number = orderNumber;
                        item.product_articul = reader.GetString(1);
                        item.product_name = reader.GetString(2);
                        item.quantity = reader.GetInt32(3);
                        item.price = reader.GetInt32(4);

                        items.Add(item);

                        // ОТЛАДКА
                        System.Diagnostics.Debug.WriteLine($"Загружен товар: {item.product_name}, {item.quantity} шт.");
                    }
                }
            }

            return items;
        }

        public List<PickUpPoint> GetPickUpPoints()
        {
            List<PickUpPoint> points = new List<PickUpPoint>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                connection.Open();

                string sql = "SELECT id, postal_index, address FROM pickuppoint ORDER BY address;";

                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PickUpPoint point = new PickUpPoint();
                        point.id = reader.GetInt32(0);
                        point.postal_index = reader.GetInt32(1);
                        point.address = reader.GetString(2);

                        points.Add(point);
                    }
                }
            }

            return points;
        }

        public List<User.User> GetUsers()
        {
            List<Library.User.User> users = new List<Library.User.User>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                connection.Open();

                string sql = "SELECT login, name, role FROM \"user\" ORDER BY name;";

                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Library.User.User user = new Library.User.User();
                        user.login = reader.GetString(0);
                        user.name = reader.GetString(1);
                        user.role = reader.GetString(2);

                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public void UpdateOrder(Order order)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                connection.Open();

                // Начинаем транзакцию
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Получаем старые товары заказа для возврата на склад
                        List<OrderItem> oldItems = GetOrderItems(order.number);

                        // Возвращаем старые товары на склад
                        foreach (var oldItem in oldItems)
                        {
                            string returnStockSql = @"UPDATE tovar 
                        SET stockquantity = stockquantity + @quantity 
                        WHERE articul = @productArticul;";

                            using (NpgsqlCommand returnStockCommand = new NpgsqlCommand(returnStockSql, connection, transaction))
                            {
                                returnStockCommand.Parameters.AddWithValue("@quantity", oldItem.quantity);
                                returnStockCommand.Parameters.AddWithValue("@productArticul", oldItem.product_articul);
                                returnStockCommand.ExecuteNonQuery();
                            }
                        }

                        // Обновляем заказ
                        string sql = @"UPDATE orders SET 
                    dateoforder = @dateOfOrder,
                    dateofdelivey = @dateOfDelivery,
                    pick_up_point_id = @pickUpPointId,
                    user_login = @userLogin,
                    code = @code,
                    status = @status
                    WHERE number = @orderNumber;";

                        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@orderNumber", order.number);
                            command.Parameters.AddWithValue("@dateOfOrder", order.dateOfOrder.Date);
                            command.Parameters.AddWithValue("@dateOfDelivery", order.dateOfDelivery.Date);
                            command.Parameters.AddWithValue("@pickUpPointId", order.pickUpPointId);
                            command.Parameters.AddWithValue("@userLogin", order.user_login ?? "");
                            command.Parameters.AddWithValue("@code", order.code);
                            command.Parameters.AddWithValue("@status", order.status);

                            command.ExecuteNonQuery();
                        }

                        // Удаляем старые товары
                        string deleteSql = "DELETE FROM order_items WHERE order_number = @orderNumber;";
                        using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteSql, connection, transaction))
                        {
                            deleteCommand.Parameters.AddWithValue("@orderNumber", order.number);
                            deleteCommand.ExecuteNonQuery();
                        }

                        // Вставляем новые товары и списываем со склада
                        foreach (var item in order.OrderItems)
                        {
                            // ВАЖНО: не используем id из объекта, вставляем только нужные поля
                            string itemSql = @"INSERT INTO order_items 
                        (order_number, product_articul, quantity)
                        VALUES 
                        (@orderNumber, @productArticul, @quantity);";

                            using (NpgsqlCommand itemCommand = new NpgsqlCommand(itemSql, connection, transaction))
                            {
                                itemCommand.Parameters.AddWithValue("@orderNumber", order.number);
                                itemCommand.Parameters.AddWithValue("@productArticul", item.product_articul);
                                itemCommand.Parameters.AddWithValue("@quantity", item.quantity);

                                itemCommand.ExecuteNonQuery();
                            }

                            // Уменьшаем количество товара на складе
                            string updateStockSql = @"UPDATE tovar 
                        SET stockquantity = stockquantity - @quantity 
                        WHERE articul = @productArticul;";

                            using (NpgsqlCommand updateStockCommand = new NpgsqlCommand(updateStockSql, connection, transaction))
                            {
                                updateStockCommand.Parameters.AddWithValue("@quantity", item.quantity);
                                updateStockCommand.Parameters.AddWithValue("@productArticul", item.product_articul);
                                updateStockCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Ошибка при обновлении заказа: {ex.Message}", ex);
                    }
                }
            }
        }
    }
}
