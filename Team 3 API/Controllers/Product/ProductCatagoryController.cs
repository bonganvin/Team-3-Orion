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
    [RoutePrefix("api/ProductCatagory")]
    public class ProductCatagoryController : ApiController
    {
        OVSEntities5 db = new OVSEntities5();
        // GET: ProductCatagory
        [Route("GetProductCatagory")]
        [HttpGet]
        public List<ProductCatagoryVM> GetProductCatagory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Product_Category.Select(zz => new ProductCatagoryVM
            {
                Product_Category_ID = zz.Product_Category_ID,
                Product_Category_Name = zz.Product_Category_Name,

            }).ToList();
        }

        // Get ProductCatagory by ID

        [System.Web.Http.Route("getProductCatagoryByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getProductCatagoryByID(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Product_Category product = db.Product_Category.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        //Add: ProductCatagory
        [Route("CreateProductCatagory")]
        [HttpPost]
        public ViewModels.ResponseObject CreateProductCatagory([FromBody] ProductCatagoryVM product)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ViewModels.ResponseObject();
            var Newpord = new Models.Product_Category
            {
                Product_Category_Name = product.Product_Category_Name,
            };

            try
            {
                db.Product_Category.Add(Newpord);
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

        // Update ProductCatagory

        [Route("UpdateProductCatagory")]
        [HttpPut]
        public ViewModels.ResponseObject UpdateProductCatagory([FromBody] ProductCatagoryVM product)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ViewModels.ResponseObject();

            var toUpdate = db.Product_Category.Where(zz => zz.Product_Category_ID
            == product.Product_Category_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Product_Category_Name = product.Product_Category_Name;

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

        //Delete ProductCatagory
        [System.Web.Http.Route("DeleteProductCatagory/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteProductCatagory(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Product_Category product = db.Product_Category.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            db.Product_Category.Remove(product);
            db.SaveChanges();

            return "DeleteProductCatagory deleted";

        }
    }
}