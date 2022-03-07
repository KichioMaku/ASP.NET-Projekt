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
        Task Cancel(OrderModel order);
        Task Return(OrderModel order);
        Task Complaint(OrderModel order);
        Task<OrderEntity> GetById(int id);
        Task Przyjete(int id);
        Task Realizowane(int id);
        Task Wyslane(int id);
        Task Dostarczone(int id);
        Task Zwrocone(int id);
        Task Anulowane(int id);



    }
}
