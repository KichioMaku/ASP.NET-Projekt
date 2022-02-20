using Projekt_.net.Entities;
using Projekt_.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.Services
{
    public interface IItemService
    {
        Task Add(ItemModel item);
        Task<IEnumerable<Entities.ItemEntity>> GetAll(string name);
        Task Delete(int id);
        Task Edit(int id);
    }
}
