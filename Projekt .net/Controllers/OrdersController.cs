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

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        public async Task<IActionResult> Index(string name)
        {
            var orders = await _orderService.GetAll(name);
            return View(orders);
        }
        public async Task<IActionResult> OrderShipped(string name)
        {
            var orders = await _orderService.GetAll(name);
            return View(orders);
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
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null) return View("Error");
            var newOrder = new OrderModel()
            {
                Id = order.Id,
                Contractor = order.Contractor,
                Items = order.Items,
                Address = order.Address,
                NetOrderValue = order.NetOrderValue,
                OrderDate = order.OrderDate,
            };
            return View(newOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, OrderModel order)
        {
            if (id != order.Id) return View("Error");
            if (!ModelState.IsValid) return View(order);
            await _orderService.Update(order);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteGet(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null) return View("Error");
            return View(order);
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null) return View("Error");
            await _orderService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Wyslano(int id)
        {
            var dbOrder = await _orderService.GetById(id);
            if (id != dbOrder.Id) 
                return View("Error");
            await _orderService.Wyslano(id);
            return RedirectToAction("Index");
        }
    }
}
