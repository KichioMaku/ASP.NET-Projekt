using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projekt_.net.Database;
using Projekt_.net.Entities;
using Projekt_.net.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Projekt_.net.Enums;


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

        public async Task Update(OrderModel order)
        {
            var orderFromDb = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (orderFromDb != null)
            {
                orderFromDb.Contractor = order.Contractor;
                orderFromDb.Items = order.Items;
                orderFromDb.Address = order.Address;
                orderFromDb.NetOrderValue = order.NetOrderValue;
                orderFromDb.OrderDate = order.OrderDate;
                orderFromDb.OrderStatusEnum = order.OrderStatusEnum;
            }

            await _dbContext.SaveChangesAsync();
        }
        public async Task Cancel(OrderModel order)
        {
            var orderFromDb = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (orderFromDb != null)
            {
                orderFromDb.Contractor = order.Contractor;
                orderFromDb.Items = order.Items;
                orderFromDb.Address = order.Address;
                orderFromDb.NetOrderValue = order.NetOrderValue;
                orderFromDb.OrderDate = order.OrderDate;
                orderFromDb.CancellationReason = order.CancellationReason;
                orderFromDb.OrderStatusEnum = order.OrderStatusEnum;
            }

            await _dbContext.SaveChangesAsync();
        }
        public async Task Return(OrderModel order)
        {
            var orderFromDb = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (orderFromDb != null)
            {
                orderFromDb.Contractor = order.Contractor;
                orderFromDb.Items = order.Items;
                orderFromDb.Address = order.Address;
                orderFromDb.NetOrderValue = order.NetOrderValue;
                orderFromDb.OrderDate = order.OrderDate;
                orderFromDb.Date = order.Date;
                orderFromDb.ReturnDate = DateTime.Now.ToString();
                orderFromDb.ReturnReason = order.ReturnReason;
                orderFromDb.OrderStatusEnum = order.OrderStatusEnum;
            }

            await _dbContext.SaveChangesAsync();
        }
        public async Task Complaint(OrderModel order)
        {
            var orderFromDb = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (orderFromDb != null)
            {
                orderFromDb.Contractor = order.Contractor;
                orderFromDb.Items = order.Items;
                orderFromDb.Address = order.Address;
                orderFromDb.NetOrderValue = order.NetOrderValue;
                orderFromDb.OrderDate = order.OrderDate;
                orderFromDb.CancellationReason = "Reklamacja";
                orderFromDb.OrderStatusEnum = order.OrderStatusEnum;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var orderFromDb = await _dbContext.Orders.FirstOrDefaultAsync(u => u.Id == id);
            _dbContext.Orders.Remove(orderFromDb);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Wyslane(int id)
        {
            var dbOrder = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (dbOrder != null)
            {
                dbOrder.Date = DateTime.Now.ToString();
                dbOrder.OrderStatusEnum = OrderStatusEnum.Wysłane;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task Przyjete(int id)
        {
            var dbOrder = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (dbOrder != null)
            {
                dbOrder.OrderStatusEnum = OrderStatusEnum.Przyjęte;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task Realizowane(int id)
        {
            var dbOrder = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (dbOrder != null)
            {
                dbOrder.OrderStatusEnum = OrderStatusEnum.Realizowane;
            }
            await _dbContext.SaveChangesAsync();
        }


        public async Task Dostarczone(int id)
        {
            var dbOrder = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (dbOrder != null)
            {
                dbOrder.DeliveryDate = DateTime.Now.ToString();
                dbOrder.OrderStatusEnum = OrderStatusEnum.Dostarczone;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task Zwrocone(int id)
        {
            var dbOrder = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (dbOrder != null)
            {
                dbOrder.ReturnDate = DateTime.Now.ToString();
                dbOrder.OrderStatusEnum = OrderStatusEnum.Zwrócone;
            }
            await _dbContext.SaveChangesAsync();
        }


        public async Task Anulowane(int id)
        {
            var dbOrder = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (dbOrder != null)
            {
                dbOrder.OrderStatusEnum = OrderStatusEnum.Anulowane;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
