using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.User
{
    public class UserModel
    {
        private readonly IUserRepository userRepository;

        public UserModel()
        {
            userRepository = new MySqlUserRepository();
        }

        public User Authorization(string login, string password)
        {
            User user = userRepository.GetUserByLogin(login);
            if (user == null)
            {
                return null;
            }

            if (user.password == password)
            {
                return user;
            }

            return null;
        }
    }
}
