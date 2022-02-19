using Projekt_.net.Entities;
using Projekt_.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.Services
{
    public interface IOrderService
    {
        Task Add(OrderModel order);
        Task<IEnumerable<OrderEntity>> GetAll(string name);
        Task Delete(int id);
        Task Update(OrderModel order);
    }
}
