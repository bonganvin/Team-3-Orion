using OVS_Team_3_API.Models;
using OVS_Team_3_API.ViewModels;
using OVS_Team_3_API.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace OVS_Team_3_API.Controllers
{
    [RoutePrefix("api/OrderPayment")]
    public class OrderPaymentController : ApiController
    {

        //[RoutePrefix("api/OrderPayment")]

        OVSEntities5 db = new OVSEntities5();
        // GET:OrderPayment
        [Route("GetOrderPayment")]
        [HttpGet]
        public List<OrderPaymentVM> GetOrderPayment()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Order_Payment.Select(zz => new OrderPaymentVM
            {
                Order_Payment_ID = zz.Order_Payment_ID,
                Order_Payment_Amount = zz.Order_Payment_Amount,
                Order_Payment_Date = zz.Order_Payment_Date,
                Payment_Type_ID = zz.Payment_Type_ID,
                Order_Payment_Status_ID = zz.Order_Payment_Status_ID,
                Order_ID = zz.Order_ID

            }).ToList();
        }

        // GetOrderPayment by ID

        [System.Web.Http.Route("getOrderPaymentByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getOrderPayment(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Order_Payment OrderPay = db.Order_Payment.Find(id);
            if (OrderPay == null)
            {
                return NotFound();
            }
            return OrderPay;

        }

        //Add:OrderPayment
        [Route("CreateOrderPayment")]
        [HttpPost]
        public ResponseObject CreateOrderPayment([FromBody]OrderPaymentVM OrderPay)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();
            var NewOrderPay = new Models.Order_Payment
            {
                Order_Payment_ID = OrderPay.Order_Payment_ID,
                Order_Payment_Amount = OrderPay.Order_Payment_Amount,
                Order_Payment_Date = OrderPay.Order_Payment_Date,
                Payment_Type_ID = OrderPay.Payment_Type_ID,
                Order_Payment_Status_ID = OrderPay.Order_Payment_Status_ID,
                Order_ID = OrderPay.Order_ID
            };

            try
            {
                db.Order_Payment.Add(NewOrderPay);
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

        // UpdateOrderPayment

        [Route("UpdateOrderPayment")]
        [HttpPut]
        public ResponseObject UpdateOrderPayment([FromBody]OrderPaymentVM OrderPay)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();

            var toUpdate = db.Order_Payment.Where(zz => zz.Order_Payment_ID == OrderPay.Order_Payment_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }
        
            try
            {
                toUpdate.Order_Payment_Amount = OrderPay.Order_Payment_Amount;
                toUpdate.Order_Payment_Date = OrderPay.Order_Payment_Date;
                toUpdate.Payment_Type_ID = OrderPay.Payment_Type_ID;
                toUpdate.Order_Payment_Status_ID = OrderPay.Order_Payment_Status_ID;
                toUpdate.Order_ID = OrderPay.Order_ID;

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
        //DeleteOrderPayment
        [System.Web.Http.Route("DeleteOrderPayment/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteOrderPayment(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Order_Payment OrderPay = db.Order_Payment.Find(id);
            if (OrderPay == null)
            {
                return NotFound();
            }
            db.Order_Payment.Remove(OrderPay);
            db.SaveChanges();

            return "Deleted";

        }

    }


}