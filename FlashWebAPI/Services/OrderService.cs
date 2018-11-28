using FlashWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashWebAPI.Services
{
    public class OrderService
    {
        public static List<Order> GetAll()
        {
            DB.DBContext dBContext = new DB.DBContext();
            return dBContext.Orders.ToList();
        }
        public static List<Order> GetActive()
        {
            DB.DBContext dBContext = new DB.DBContext();
            return dBContext.Orders.Where(x=>x.Status.Equals("Active")).ToList();
        }
        public static List<Order> GetPending()
        {
            DB.DBContext dBContext = new DB.DBContext();
            return dBContext.Orders.Where(x => x.Status.Equals("Pending")).ToList();
        }
        public static bool AddOrder(Order order)
        {
            DB.DBContext dBContext = new DB.DBContext();

            if (dBContext.Orders.Where(x => x.OrderNumber.Equals(order.OrderNumber)).ToList().Count < 1)
            {
                order.StartingDate = DateTime.Now;
                dBContext.Orders.Add(order);
                dBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool UpdateOrder(Order order)
        {
            DB.DBContext dBContext = new DB.DBContext();
            Order _order= dBContext.Orders.Where(x => x.OrderNumber.Equals(order.OrderNumber)).ToList().FirstOrDefault();
            if (_order != null)
            {
                DeleteOrder(_order);
                AddOrder(order);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DeleteOrder(Order order)
        {
            DB.DBContext dBContext = new DB.DBContext();
            Order _order = dBContext.Orders.Where(x => x.OrderNumber.Equals(order.OrderNumber)).ToList().FirstOrDefault();
            if (_order != null)
            {
                dBContext.Orders.Remove(_order);
                dBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
