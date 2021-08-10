using OVS_Team_3_API.Models;
using OVS_Team_3_API.ViewModels;
using OVS_Team_3_API.ViewModels.Customer_Subsystem;
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
    [RoutePrefix("api/QuoteStatus")]
    public class QuoteStatusController : ApiController
    {

        //[RoutePrefix("api/RequestQuote")]

        OVSEntities5 db = new OVSEntities5();
        // GET: RequestQuote
        [Route("GetRequestQuote")]
        [HttpGet]
        public List<QuoteStatusVM> GetQuoteStatus()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Quote_Status.Select(zz => new QuoteStatusVM
            {
                Quote_Status_ID = zz.Quote_Status_ID,
                Quote_Status_Description = zz.Quote_Status_Description

            }).ToList();
        }

        // Get RequestQuote by ID

        [System.Web.Http.Route("getQuoteStatusByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getQuoteStatus(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Quote_Status quote = db.Quote_Status.Find(id);
            if (quote == null)
            {
                return NotFound();
            }
            return quote;

        }

        //Add: QuoteStatus
        [Route("CreateQuoteStatus")]
        [HttpPost]
        public ResponseObject CreateQuoteStatus([FromBody] QuoteStatusVM quotestat)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();
            var NewQuoteStatus = new Models.Quote_Status
            {
                Quote_Status_ID = quotestat.Quote_Status_ID,
                Quote_Status_Description = quotestat.Quote_Status_Description
            };

            try
            {
                db.Quote_Status.Add(NewQuoteStatus);
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

        // Update RequestQuote

        [Route("UpdateRequestQuote")]
        [HttpPut]
        public ResponseObject UpdateRequestQuote([FromBody] QuoteStatusVM quote)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();

            var toUpdate = db.Quote_Status.Where(zz => zz.Quote_Status_ID == quote.Quote_Status_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Quote_Status_Description = quote.Quote_Status_Description;

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
        //Delete QuoteStatus
        [System.Web.Http.Route("DeleteQuoteStatus/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteQuoteStatus(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Quote_Status quotestatus = db.Quote_Status.Find(id);
            if (quotestatus == null)
            {
                return NotFound();
            }
            db.Quote_Status.Remove(quotestatus);
            db.SaveChanges();

            return "Quote Status deleted";

        }

    }


}