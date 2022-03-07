using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_.net.Database;
using Projekt_.net.Entities;
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
        public async Task<IActionResult> OrderAccepted(string name)
        {
            var orders = await _orderService.GetAll(name);
            return View(orders);
        }
        public async Task<IActionResult> OrderCancelled(string name)
        {
            var orders = await _orderService.GetAll(name);
            return View(orders);
        }

        public async Task<IActionResult> OrderDelivered(string name)
        {
            var orders = await _orderService.GetAll(name);
            return View(orders);
        }
        public async Task<IActionResult> OrderReturned(string name)
        {
            var orders = await _orderService.GetAll(name);
            return View(orders);
        }

        public async Task<IActionResult> OrderInProgress(string name)
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
                OrderStatusEnum = order.OrderStatusEnum
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
        public async Task<IActionResult> Wyslane(int id)
        {
            var dbOrder = await _orderService.GetById(id);
            if (id != dbOrder.Id) 
                return View("Error");
            await _orderService.Wyslane(id);
            return RedirectToAction("OrderShipped");
        }
        public async Task<IActionResult> Realizowane(int id)
        {
            var dbOrder = await _orderService.GetById(id);
            if (id != dbOrder.Id)
                return View("Error");
            await _orderService.Realizowane(id);
            return RedirectToAction("OrderInProgress");
        }
        public async Task<IActionResult> Anulowane(int id)
        {
            var dbOrder = await _orderService.GetById(id);
            if (id != dbOrder.Id)
                return View("Error");
            await _orderService.Anulowane(id);
            return RedirectToAction("OrderCanceled");
        }
        public async Task<IActionResult> Dostarczone(int id)
        {
            var dbOrder = await _orderService.GetById(id);
            if (id != dbOrder.Id)
                return View("Error");
            await _orderService.Dostarczone(id);
            return RedirectToAction("OrderDelivered");
        }
        public async Task<IActionResult> Zwrocone(int id)
        {
            var dbOrder = await _orderService.GetById(id);
            if (id != dbOrder.Id)
                return View("Error");
            await _orderService.Zwrocone(id);
            return RedirectToAction("OrderRetured");
        }
        public async Task<IActionResult> Cancel(int id)
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
                CancellationReason = order.CancellationReason,
                OrderStatusEnum = order.OrderStatusEnum
            };
            return View(newOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id, OrderModel order)
        {
            if (id != order.Id) return View("Error");
            if (!ModelState.IsValid) return View(order);
            await _orderService.Cancel(order);
            return RedirectToAction("OrderCancelled");
        }
        public async Task<IActionResult> Return(int id)
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
                Date = order.Date,
                ReturnReason = order.ReturnReason,
                OrderStatusEnum = order.OrderStatusEnum,
                ReturnDate = order.ReturnDate
            };
            return View(newOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Return(int id, OrderModel order)
        {
            if (id != order.Id) return View("Error");
            if (!ModelState.IsValid) return View(order);
            await _orderService.Return(order);
            return RedirectToAction("OrderReturned");
        }
        public async Task<IActionResult> Complaint(int id)
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
                OrderStatusEnum = order.OrderStatusEnum
        };
            return View(newOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Complaint(int id, OrderModel order)
        {
            if (id != order.Id) return View("Error");
            if (!ModelState.IsValid) return View(order);
            await _orderService.Complaint(order);
            return RedirectToAction("OrderInProgress");
        }
    }
}

