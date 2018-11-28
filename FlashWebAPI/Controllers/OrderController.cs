using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashWebAPI.Models;
using FlashWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        [Route("GetAll")]
        [HttpGet]
        public List<Order> GetAll()
        {
            return OrderService.GetAll();
        }
        [Route("active")]
        [HttpGet]
        public List<Order> GetActive()
        {
            return OrderService.GetActive();
        }
        [Route("pending")]
        [HttpGet]
        public List<Order> GetPending()
        {
            return OrderService.GetPending();
        }
        [Route("add")]
        [HttpPost]
        public bool AddOrder([FromBody] Order order)
        {
            if (order != null)
            {
                return OrderService.AddOrder(order);
            }
            else
            {
                return false;
            }
        }
        [Route("update")]
        [HttpPost]
        public bool UpdateOrder([FromBody] Order order)
        {
            if (order != null)
            {
                return OrderService.UpdateOrder(order);
            }
            else
            {
                return false;
            }
        }
        [Route("delete")]
        [HttpPost]
        public bool DeleteOrder([FromBody] Order order)
        {
            if (order != null)
            {
                return OrderService.DeleteOrder(order);
            }
            else
            {
                return false;
            }
        }
    }
}