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
    [RoutePrefix("api/ProductSize")]
    public class ProductSizeController : ApiController
    {
        OVSEntities5 db = new OVSEntities5();

        // GET: ProductSize
        [Route("GetProductSize")]
        [HttpGet]
        public List<ProductSizeVM> GetProductSize()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Product_Size.Select(zz => new ProductSizeVM
            {
                ProductID = zz.Product_ID,
                ProductSizeID = zz.Product_Size_ID,
               
                SizeID = zz.Size_ID

            }).ToList();
        }

        // Get ProductSize by ID

        [System.Web.Http.Route("getProductSizeByID/{id:int}")]
     
        [HttpGet]
        public object getProductSizeByID(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Product_Size product = db.Product_Size.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        //Add: ProductSize
        [Route("CreateProductSize")]
        [HttpPost]
        public ViewModels.ResponseObject CreateProductSize([FromBody] ProductSizeVM product)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ViewModels.ResponseObject();
            var Newpord = new Models.Product_Size
            {
                Product_ID = product.ProductID,
                Product_Size_ID = product.ProductSizeID,
                Size_ID = product.SizeID,

             
            };

            try
            {
                db.Product_Size.Add(Newpord);
                db.SaveChanges();
                var newPrice = new Models.Price
                {
                    Product_Size_ID = Newpord.Product_Size_ID,
                    Price_Amount = (float)product.PriceAmount,
                    Price_Date = DateTime.Now.Date
                };
                db.Prices.Add(newPrice);
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

        // Update ProductSize

        [Route("UpdateProductSize")]
        [HttpPut]
        public ViewModels.ResponseObject UpdateProductSize([FromBody] ProductSizeVM product)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ViewModels.ResponseObject();

            var toUpdate = db.Product_Size.Where(zz => zz.Product_Size_ID
            == product.ProductSizeID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Product_ID = product.ProductID;
          
                toUpdate.Size_ID = product.SizeID;

                db.SaveChanges();

                var UpdatePrice = db.Prices.Where(zz => zz.Price_ID == product.PriceID && zz.Price_ID ==zz.Product_Size_ID).FirstOrDefault();
                UpdatePrice.Price_Amount = (float)product.PriceAmount;
                UpdatePrice.Price_Date = DateTime.Now.Date;
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

        //Delete ProductSize
        [System.Web.Http.Route("DeleteProductSize/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteProductSize(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Product_Size product = db.Product_Size.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            db.Product_Size.Remove(product);
            db.SaveChanges();

            return "ProductSize deleted";

        }
    }
}