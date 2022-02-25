using Projekt_.net.Entities;
using Projekt_.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.Services
{
    public interface IContractorsService
    {
        Task Add(ContractorsModel contractor);
        Task<IEnumerable<ContractorsEntity>> GetAll(string name);
        Task Delete(int id);
        Task Update(ContractorsModel contractor);
        Task<ContractorsEntity> GetById(int id);
    }
}
