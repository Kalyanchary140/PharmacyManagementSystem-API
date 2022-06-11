using pharmacyManagementSystem.Models;
using System.Collections.Generic;

namespace pharmacyManagementSystem.Repository
{
    public interface IUserRepository
    {
        UserDetail Create(UserDetail user);
        IEnumerable<UserDetail> GetAll();
        UserDetail GetByEmail(string email);
        UserDetail GetById(int id);
    }
}