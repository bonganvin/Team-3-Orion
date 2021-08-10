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
    [RoutePrefix("api/QuoteLine")]
    public class QuoteLineController : ApiController
    {

        //[RoutePrefix("api/QuoteLine")]

        OVSEntities5 db = new OVSEntities5();
        // GET: QuoteLine
        [Route("GetQuoteLine")]
        [HttpGet]
        public List<QuoteLineVM> GetQuoteLine()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Quote_Line.Select(zz => new QuoteLineVM
            {
                Quote_Line_ID = zz.Quote_Line_ID,
                Quantity = zz.Quantity,
                Product_ID = zz.Product_ID,
                Request_Quote_ID = zz.Product_ID


            }).ToList();
        }

        // Get QuoteLine by ID

        [System.Web.Http.Route("getQuoteLineByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getQuoteLine(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Quote_Line quoteline = db.Quote_Line.Find(id);
            if (quoteline == null)
            {
                return NotFound();
            }
            return quoteline;

        }

        //Add: QuoteLine
        [Route("CreateQuoteLine")]
        [HttpPost]
        public ResponseObject CreateQuoteLine([FromBody] QuoteLineVM quoteline)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();
            var Newquoteline = new Models.Quote_Line
            {
                 Quote_Line_ID= quoteline.Quote_Line_ID,
                Quantity = quoteline.Quantity,
                Product_ID = quoteline.Product_ID,
                Request_Quote_ID = quoteline.Request_Quote_ID
            };

            try
            {
                db.Quote_Line.Add(Newquoteline);
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

        // Update QuoteLine

        [Route("UpdateQuoteLine")]
        [HttpPut]
        public ResponseObject UpdateQuoteLine([FromBody] QuoteLineVM quoteline)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();

            var toUpdate = db.Quote_Line.Where(zz => zz.Quote_Line_ID == quoteline.Quote_Line_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Quantity = quoteline.Quantity;
                toUpdate.Product_ID = quoteline.Product_ID;
                toUpdate.Request_Quote_ID = quoteline.Request_Quote_ID;

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
        //Delete QuoteLine
        [System.Web.Http.Route("DeleteQuoteLine/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteQuoteLine(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Quote_Line quoteline = db.Quote_Line.Find(id);
            if (quoteline == null)
            {
                return NotFound();
            }
            db.Quote_Line.Remove(quoteline);
            db.SaveChanges();

            return "Quotation Status deleted";

        }

    }


}