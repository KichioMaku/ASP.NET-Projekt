using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class OrdersController : Controller
    {
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
        
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(OrderModel order)
        {
            if (!ModelState.IsValid) return View(order);

            await _orderService.Add(order);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List(string name)
        {
            var orders = await _orderService.GetAll(name);
            return View(orders);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteGet(int id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var task = await _orderService.GetById(id);
            if (task == null)
            {
                return View("Error");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            var task = await _orderService.GetById(id);
            if (task == null)
            {
                return View("Error");
            }
            await _orderService.Delete(id);
            return View("List");
        }
        

    }
}
