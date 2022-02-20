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
    public class ItemService : IItemService
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        public ItemService(AppDbContext dbContext, IHttpContextAccessor accessor, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _httpContextAccessor = accessor;
            _userManager = userManager;
        }

        public async Task Add(ItemModel item)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var entity = new ItemEntity
            {
                ItemName = item.ItemName,
                Quantity = item.Quantity,
                Price = item.Price,
                Owner = currentUser,
            };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var deletedItem = await _dbContext.Items.FirstOrDefaultAsync(t => t.Id == id);
            _dbContext.Items.Remove(deletedItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entities.ItemEntity>> GetAll(string name)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            IQueryable<Entities.ItemEntity> itemsQuery = _dbContext.Items;

            itemsQuery = itemsQuery.Where(x => x.Owner == currentUser);

            if (!string.IsNullOrEmpty(name))
            {
                itemsQuery = itemsQuery.Where(x => x.ItemName.Contains(name));
            }
            var items = await itemsQuery.ToListAsync();

            return items;
        }

        public Task Edit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
