using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class UserService : IUserService
    {
        private readonly SULSContext context;

        public UserService(SULSContext context)
        {
            this.context = context;
        }

        public void CreateUser(string username, string email, string password)
        {
            User user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password)
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var passwordHash = this.HashPassword(password);
            var user = this.context.Users.FirstOrDefault(
                x => x.Username == username
                     && x.Password == passwordHash);
            return user;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}