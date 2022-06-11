using pharmacyManagementSystem.Models;
using pharmacyManagementSystem.Repository;
using System.Collections.Generic;
using System.Linq;

namespace pharmacyManagementSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly pharmacyManagamentContext _context;

        public UserRepository(pharmacyManagamentContext context)
        {
            _context = context;
        }
        public UserDetail Create(UserDetail user)
        {
            _context.UserDetails.Add(user);
            _context.SaveChanges();

            return user;
        }
        public IEnumerable<UserDetail> GetAll()
        {
            return _context.UserDetails;
        }


        public UserDetail GetByEmail(string email)
        {
            return _context.UserDetails.FirstOrDefault(x => x.Email == email);
        }

        public UserDetail GetById(int id)
        {
            return _context.UserDetails.FirstOrDefault(u => u.UserId == id);
        }
    }
}
