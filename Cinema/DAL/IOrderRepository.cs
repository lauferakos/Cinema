using Cinema.Controllers.Dto;
using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL
{
    public interface IOrderRepository
    {
        IReadOnlyCollection<Order> List();
        IReadOnlyCollection<Order> GetOrdersByViewerId(int viewerId);
        Order FindById(int orderId);

        Order Insert(CreateOrder value);
        Order Delete(int orderId);

    }
}
