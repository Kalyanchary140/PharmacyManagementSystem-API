using pharmacyManagementSystem.Models;
using System.Collections.Generic;

namespace pharmacyManagementSystem.Repository
{
    public interface IOrdersRepostiory
    {
        IEnumerable<Order> GetAll();
        Order Create(Order order);
        IEnumerable<Order> GetOrders(int id);
    }
}
