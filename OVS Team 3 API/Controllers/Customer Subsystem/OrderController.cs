using OVS_Team_3_API.Models;
using OVS_Team_3_API.ViewModels;
using OVS_Team_3_API.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OVS_Team_3_API.Controllers.Customer_Subsystem
{
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        OVSEntities5 db = new OVSEntities5();
        // GET: Order
        [Route("GetOrder")]
        [HttpGet]
        public List<OrderVM> GetOrders()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Orders.Select(zz => new OrderVM
            {
                Order_ID = zz.Order_ID,
                Order_Date = zz.Order_Date,
                Order_Finalizastion_Date = zz.Order_Finalizastion_Date,
                Delivery = zz.Delivery,
                Customer_ID = zz.Customer_ID,
                Order_Status_ID = zz.Order_Status_ID,
                Employee_ID = zz.Employee_ID,
                Customer = zz.Customer,
                Employee = zz.Employee

            }).ToList();
        }

        // Get Order by ID

        [System.Web.Http.Route("getOrderByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getOrder(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;

        }

        //Add: Order
        [Route("CreateOrderr")]
        [HttpPost]
        public ResponseObject CreateOrder([FromBody] OrderVM order)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();
            var Neworder = new Models.Order
            {
                Order_Date = order.Order_Date,
                Order_Finalizastion_Date = order.Order_Finalizastion_Date,
                Delivery = order.Delivery,
                Customer_ID = order.Customer_ID,
                Order_Status_ID = order.Order_Status_ID,
                Employee_ID = order.Employee_ID,
                Customer = order.Customer,
                Employee = order.Employee
            };

            try
            {
                db.Orders.Add(Neworder);
                db.SaveChanges();

                response.Success = true;
                response.ErrorMessage = null;
                return response;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
                return response;
            }
        }

        // Update Order

        [Route("UpdateOrder")]
        [HttpPut]
        public ResponseObject UpdateOrder([FromBody] OrderVM order)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();

            var toUpdate = db.Orders.Where(zz => zz.Order_ID
            == order.Order_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Order_Date = order.Order_Date;
                toUpdate.Order_Finalizastion_Date = order.Order_Finalizastion_Date;
                toUpdate.Delivery = order.Delivery;
                toUpdate.Customer_ID = order.Customer_ID;
                toUpdate.Order_Status_ID = order.Order_Status_ID;
                toUpdate.Employee_ID = order.Employee_ID;
                toUpdate.Customer = order.Customer;
                toUpdate.Employee = order.Employee;

                db.SaveChanges();

                response.Success = true;
                response.ErrorMessage = null;
                return response;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
                return response;
            }
        }
        //Delete Order
        [System.Web.Http.Route("DeleteOrder/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteOrder(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            db.Orders.Remove(order);
            db.SaveChanges();

            return "Order deleted";

        }

    }
}
