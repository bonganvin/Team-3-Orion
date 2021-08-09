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
                Product_ID = zz.Product_ID,
                Product_Size_ID = zz.Product_Size_ID,
                Price_ID = zz.Price_ID,
                Size_ID = zz.Size_ID

            }).ToList();
        }

        // Get ProductSize by ID

        [System.Web.Http.Route("getProductSizeByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
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
                Product_ID = product.Product_ID,
                Product_Size_ID = product.Product_Size_ID,
                Size_ID = product.Size_ID,
                Price_ID = product.Price_ID
            };

            try
            {
                db.Product_Size.Add(Newpord);
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
            == product.Product_Size_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Product_ID = product.Product_ID;
                toUpdate.Price_ID = product.Price_ID;
                toUpdate.Size_ID = product.Size_ID;

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