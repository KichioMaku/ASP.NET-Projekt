using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projekt_.net.Database;
using Projekt_.net.Entities;
using Projekt_.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Projekt_.net.Services
{
    public class OrderServices : IOrderService
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderServices(AppDbContext dbContext, IHttpContextAccessor accessor, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _httpContextAccessor = accessor;
            _userManager = userManager;
        }
        public async Task Add(OrderModel order)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var entity = new OrderEntity
            {
                Contractor = order.Contractor,
                Items = order.Items,
                Address = order.Address,
                NetOrderValue = order.NetOrderValue,
                OrderDate = order.OrderDate,
                OrderStatusEnum = order.OrderStatusEnum,
                Owner = currentUser,
            };
            await _dbContext.Orders.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

       public async Task<OrderEntity> GetById(int id)
        {
            var orderFromDb = await _dbContext.Orders.FirstOrDefaultAsync(u => u.Id == id);
            return orderFromDb;
        }

        public async Task<IEnumerable<OrderEntity>> GetAll(string name)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            IQueryable<OrderEntity> ordersQuery = _dbContext.Orders;
            ordersQuery = ordersQuery.Where(x => x.Owner == currentUser);
            if (!string.IsNullOrEmpty(name))
            {
                ordersQuery = ordersQuery.Where(x => x.Contractor.Contains(name));
            }
            var orders = await ordersQuery.ToListAsync();
            return orders;
        }

        public Task Update(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            var orderFromDb = await _dbContext.Orders.FirstOrDefaultAsync(u => u.Id == id);
            _dbContext.Orders.Remove(orderFromDb);
            await _dbContext.SaveChangesAsync();
        }
    }
}
