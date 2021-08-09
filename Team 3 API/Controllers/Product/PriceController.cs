using OVS_Team_3_API.Models;
using OVS_Team_3_API.ViewModels.Product;
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

namespace OVS_Team_3_API.Controllers.Product
{
    [RoutePrefix("api/Price")]
    public class PriceController : ApiController
    {
        OVSEntities5 db = new OVSEntities5();

        // GET: Price
        [Route("GetPrice")]
        [HttpGet]
        public List<PriceVM> GetPrice()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Prices.Select(zz => new PriceVM
            {
                Price_ID = zz.Price_ID,
                Price_Amount = zz.Price_Amount,
                Price_Date = zz.Price_Date,

            }).ToList();
        }

        // Get Price by ID

        [System.Web.Http.Route("getPriceByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getPriceByID(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Price price = db.Prices.Find(id);
            if (price == null)
            {
                return NotFound();
            }
            return price;
        }

        //Add: Price
        [Route("CreatePrice")]
        [HttpPost]
        public ViewModels.ResponseObject CreatePrice([FromBody] PriceVM price)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ViewModels.ResponseObject();
            var NewPrice = new Models.Price
            {
                Price_Amount = price.Price_Amount,
                Price_Date = price.Price_Date,
            };

            try
            {
                db.Prices.Add(NewPrice);
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

        // Update Price

        [Route("UpdatePrice")]
        [HttpPut]
        public ViewModels.ResponseObject UpdatePrice([FromBody] Price price)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ViewModels.ResponseObject();

            var toUpdate = db.Prices.Where(zz => zz.Price_ID
            == price.Price_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Price_Amount = price.Price_Amount;
                toUpdate.Price_Date = price.Price_Date;

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

        //Delete Price
        [System.Web.Http.Route("DeletePrice/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeletePrice(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Price price = db.Prices.Find(id);
            if (price == null)
            {
                return NotFound();
            }
            db.Prices.Remove(price);
            db.SaveChanges();

            return "price deleted";

        }
    }
}