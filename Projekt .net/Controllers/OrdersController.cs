using Microsoft.AspNetCore.Mvc;
using Projekt_.net.Database;
using Projekt_.net.Models;
using Projekt_.net.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.Controllers
{
    public class OrdersController : Controller
    {
        //private readonly AppDbContext _dbContext;
        private readonly IOrderService _orderService;

        public OrdersController (IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(OrderModel order)
        {
            await _orderService.Add(order);
            return View();
        }
    }
}
