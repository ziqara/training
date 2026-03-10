using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Library.Tovar
{
    public class MySqlTovarRepository : ITovarRepository
    {
        private const string connStr = "Host=192.168.1.48;Port=5432;Database=shoes_shop;Username=st50-6;Password=506;";

        public List<Tovar> ReadAllTovars()
        {
            List<Tovar> tovars = new List<Tovar>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                connection.Open();

                string readSql = "SELECT * FROM tovar";
                NpgsqlCommand command = new NpgsqlCommand(readSql, connection);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tovar tovar = new Tovar(reader.GetString(0));

                        tovar.name = reader.GetString(1);
                        tovar.unit = reader.GetString(2);
                        tovar.price = reader.GetInt32(3);
                        tovar.supplier = reader.GetString(4);
                        tovar.manufacturer = reader.GetString(5);
                        tovar.category = reader.GetString(6);
                        tovar.discount = reader.GetInt32(7);
                        tovar.stockquantity = reader.GetInt32(8);
                        tovar.description = reader.GetString(9);
                        tovar.picture = reader.IsDBNull(10) ? "" : reader.GetString(10);

                        tovars.Add(tovar);
                    }
                }
            }

            return tovars;
        }

        public void AddTovar(Tovar tovar)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                connection.Open();
                string addSql = "INSERT INTO articul, name, unit, price, supplier, manufacturer, category, discount, stockquantity, description, picture" +
                    "VALUES (@articul, @name, @unit, @price, @supplier, @manufacturer, @category, @discount, @stockquantity, @description, @picture)";

                NpgsqlCommand command = new NpgsqlCommand(addSql, connection);

                command.Parameters.AddWithValue("@articul", tovar.articul);
                command.Parameters.AddWithValue("@name", tovar.name);
                command.Parameters.AddWithValue("@unit", tovar.unit);
                command.Parameters.AddWithValue("@price", tovar.price);
                command.Parameters.AddWithValue("@supplier", tovar.supplier);
                command.Parameters.AddWithValue("@manufacturer", tovar.manufacturer);
                command.Parameters.AddWithValue("@category", tovar.category);
                command.Parameters.AddWithValue("@discount", tovar.discount);
                command.Parameters.AddWithValue("@stockquantity", tovar.stockquantity);
                command.Parameters.AddWithValue("@description", tovar.description);
                command.Parameters.AddWithValue("@picture", tovar.picture);

                command.ExecuteNonQuery();
            }
        }
    }
}
