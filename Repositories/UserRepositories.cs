using ApiAuth.Models;

namespace ApiAuth.Repositories
{
    public class UserRepositories
    {
        public static User get(string username, string password)
        {
            var users = new List<User>()
            {
               new() {Id = 1, Username = "NOME1", Password = "1234", Role = "manager"},
               new() {Id = 2, Username = "NOME2", Password = "1234", Role = "ceo"}
            };

            return users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
