using OVS_Team_3_API.Models;
using OVS_Team_3_API.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OVS_Team_3_API.Controllers.Order
{
    [RoutePrefix("api/returnorder")]
    public class ReturnOrderRequestController : ApiController
    {

        OVSEntities5 db = new OVSEntities5();
        // GET: ReturnOrder
        [Route("Getreturnorder")]
        [HttpGet]
        public List<ReturnOrderRequestVM> GetUserAccess()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Return_Order_Request.Select(zz => new ReturnOrderRequestVM
            {
                ReturnOrderRequest_ID = zz.Return_Order_Request_ID,
                RequestOrderDate = zz.Request_Order_Date,
                CustomerID = zz.Customer_ID,
                Customer=zz.Customer,
                OrderID=zz.Order_ID,
                Order=zz.Order,

            }).ToList();
        }


        // Get Return Order by ID

        [System.Web.Http.Route("getReturnOrderByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getReturnOrder(int id)

        {

            db.Configuration.ProxyCreationEnabled = false;

            Return_Order_Request req = db.Return_Order_Request.Find(id);
            if (req == null)
            {
                return NotFound();
            }
            return req;

        }
    }
}
