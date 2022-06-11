using Microsoft.EntityFrameworkCore;
using pharmacyManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace pharmacyManagementSystem.Repository
{
    public class OrdersRepository : IOrdersRepostiory
    {
        private readonly pharmacyManagamentContext _context;
        public OrdersRepository(pharmacyManagamentContext context)
        {
            _context = context;
        }

        public Order Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(ordr => ordr.User).ToList();
        }


        public IEnumerable<Order> GetOrders(int id)
        {
            var order = _context.Orders.Where(u => u.UserId == id).ToList();
            return order;

        }


    }
}