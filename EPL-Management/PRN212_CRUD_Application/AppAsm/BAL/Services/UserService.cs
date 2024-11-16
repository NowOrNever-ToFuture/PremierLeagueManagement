using DAL.Entities;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class UserService
    {
        private UserRepo _repo = new();

        public static int LoggedInUserId { get; private set; }

        public User? Authenticate(string username, string passwordHash)
        {
            var user = _repo.GetUser(username, passwordHash);
            if (user != null)
            {
                LoggedInUserId = user.UserId; // Set the logged-in user's ID
            }
            return user;
        }



    }
}
