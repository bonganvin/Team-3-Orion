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
    [RoutePrefix("api/SalePayment")]
    public class SalePaymentController : ApiController
    {

        //[RoutePrefix("api/SalePayment")]

        OVSEntities5 db = new OVSEntities5();
        // GET: SalePayment
        [Route("GetSalePayment")]
        [HttpGet]
        public List<SalePaymentVM> GetSalePayment()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Sale_Payment.Select(zz => new SalePaymentVM
            {
                Sale_Payment_ID = zz.Sale_Payment_ID,
                Sale_Payment_Amount = zz.Sale_Payment_Amount,
                Sale_Payment_Date = zz.Sale_Payment_Date,
                Sale_ID = zz.Sale_ID,
                Sale_Payment_Status_ID = zz.Sale_Payment_Status_ID,
                Payment_Type_ID = zz.Payment_Type_ID,
                Register_ID = zz.Register_ID

            }).ToList();
        }

        // Get SalePayment by ID

        [System.Web.Http.Route("getSalePaymentByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getSalePayment(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Sale_Payment salepay = db.Sale_Payment.Find(id);
            if (salepay == null)
            {
                return NotFound();
            }
            return salepay;

        }

        //Add: SalePayment
        [Route("CreateSalePayment")]
        [HttpPost]
        public ResponseObject CreateSalePayment([FromBody] SalePaymentVM salepay)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();
            var NewSalepay = new Models.Sale_Payment
            {
                Sale_Payment_ID = salepay.Sale_Payment_ID,
                Sale_Payment_Amount = salepay.Sale_Payment_Amount,
                Sale_Payment_Date = salepay.Sale_Payment_Date,
                Sale_ID = salepay.Sale_ID,
                Sale_Payment_Status_ID = salepay.Sale_Payment_Status_ID,
                Payment_Type_ID = salepay.Payment_Type_ID

            };

            try
            {
                db.Sale_Payment.Add(NewSalepay);
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

        // Update SalePayment

        [Route("UpdateSalePayment")]
        [HttpPut]
        public ResponseObject UpdateSalePayment([FromBody] SalePaymentVM salepay)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();

            var toUpdate = db.Sale_Payment.Where(zz => zz.Sale_Payment_ID == salepay.Sale_Payment_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Sale_Payment_Amount = salepay.Sale_Payment_Amount;
                toUpdate.Sale_Payment_Date = salepay.Sale_Payment_Date;
                toUpdate.Sale_ID = salepay.Sale_ID;
                toUpdate.Sale_Payment_Status_ID = salepay.Sale_Payment_Status_ID;
                toUpdate.Payment_Type_ID = salepay.Sale_Payment_Status_ID;
                toUpdate.Register_ID = salepay.Register_ID;

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
        //Delete SalePayment
        [System.Web.Http.Route("DeleteSalePayment/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteSalePayment(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Sale_Payment salepay = db.Sale_Payment.Find(id);
            if (salepay == null)
            {
                return NotFound();
            }
            db.Sale_Payment.Remove(salepay);
            db.SaveChanges();

            return "Deleted";

        }

    }


}