﻿using Projekt_.net.Entities;
using Projekt_.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.Services
{
    public class OrderServices : IOrderService
    {
        public Task Add(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderEntity>> GetAll(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(OrderModel order)
        {
            throw new NotImplementedException();
        }
    }
}
