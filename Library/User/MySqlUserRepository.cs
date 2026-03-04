using Npgsql;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.User
{
    public class MySqlUserRepository : IUserRepository
    {   private const string connStr = "Host=192.168.1.48;Port=5432;Database=shoes_shop;Username=st50-6;Password=506;";
        public User GetUserByLogin(string Login)
        {
            if (string.IsNullOrEmpty(Login))
                return null;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
                {
                    connection.Open();
                    string sql = "SELECT \"login\",\"name\", \"password\", \"role\" FROM public.user WHERE \"login\" = @login LIMIT 1";

                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@login", Login);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                return new User
                                {
                                    login = reader.GetString(0),    
                                    name = reader.GetString(1),     
                                    password = reader.GetString(2), 
                                    role = reader.GetString(3)
                                };
                        }
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Ошибка при поиске пользователя с логином '{Login}'.", ex);
            }
        }


    }
}
