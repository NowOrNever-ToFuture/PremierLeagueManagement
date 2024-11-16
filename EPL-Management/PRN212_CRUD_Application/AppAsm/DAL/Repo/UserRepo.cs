using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class UserRepo
    {
        private EplmanagementContext _context;

        public User? GetUser(string username, string passwordHash)
        {
            _context = new();
            return _context.Users.FirstOrDefault(x => x.Username.ToLower().Equals(username.ToLower()) && x.PasswordHash.Equals(passwordHash));
        }
    }
}
