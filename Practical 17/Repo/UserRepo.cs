using Practical_17.Interfaces;
using Practical_17.Models;

namespace Practical_17.Repo
{
    public class UserRepo : Iuser
    {
        private readonly ApplicationContext _context;

        public UserRepo(ApplicationContext context)
        {
            _context = context;
        }
        public bool AddUser(Users user, Roles role)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            _context.Roles.Add(role);
            _context.SaveChanges();
            return true;
        }

        public Users GetUser(string  emailAddress)
        {
            var userInDb =  _context.Users.Find(emailAddress);
            if (userInDb == null)
            {
                return null;
            }
            return userInDb;
        }

        public string GetUserRole(string emailAddress)
        {
           var userRole = _context.Roles.Find(emailAddress);
            if (userRole == null)
            {
                return null;
            }
            return userRole.Role;
        }
    }
}
