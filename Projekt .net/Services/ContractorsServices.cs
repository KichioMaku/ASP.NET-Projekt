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
    public class ContractorsServices : IContractorsService
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public ContractorsServices(AppDbContext dbContext, IHttpContextAccessor accessor, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _httpContextAccessor = accessor;
            _userManager = userManager;
        }
        public async Task Add(ContractorsModel contractor)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var entity = new ContractorsEntity
            {
                ContractorName = contractor.ContractorName,
                EmailAddress = contractor.EmailAddress,
                Address = contractor.Address,
                PhoneNumber = contractor.PhoneNumber,
                NIP = contractor.NIP,
                Owner = currentUser,
            };
            await _dbContext.Contractors.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ContractorsEntity> GetById(int id)
        {
            var contractorFromDb = await _dbContext.Contractors.FirstOrDefaultAsync(u => u.Id == id);
            return contractorFromDb;
        }

        public async Task<IEnumerable<ContractorsEntity>> GetAll(string name)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            IQueryable<ContractorsEntity> ContractorsQuery = _dbContext.Contractors;
            ContractorsQuery = ContractorsQuery.Where(x => x.Owner == currentUser);
            if (!string.IsNullOrEmpty(name))
            {
                ContractorsQuery = ContractorsQuery.Where(x => x.ContractorName.Contains(name));
            }
            var contractors = await ContractorsQuery.ToListAsync();
            return contractors;
        }

        public async Task Update(ContractorsModel contractor)
        {
            var contractorFromDb = await _dbContext.Contractors.FirstOrDefaultAsync(o => o.Id == contractor.Id);
            if (contractorFromDb != null)
            {
                contractorFromDb.ContractorName = contractor.ContractorName;
                contractorFromDb.EmailAddress = contractor.EmailAddress;
                contractorFromDb.Address = contractor.Address;
                contractorFromDb.PhoneNumber = contractor.PhoneNumber;
                contractorFromDb.NIP = contractor.NIP;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var contractorFromDb = await _dbContext.Contractors.FirstOrDefaultAsync(u => u.Id == id);
            _dbContext.Contractors.Remove(contractorFromDb);
            await _dbContext.SaveChangesAsync();
        }

    }
}
