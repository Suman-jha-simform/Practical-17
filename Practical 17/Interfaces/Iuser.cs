using Practical_17.Models;

namespace Practical_17.Interfaces
{
    public interface Iuser
    {
        Users GetUser(string emailAddress);
        bool AddUser(Users user, Roles role);

        string GetUserRole(string emailAddress);
    }
}
