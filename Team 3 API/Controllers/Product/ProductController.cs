using OVS_Team_3_API.Models;
using OVS_Team_3_API.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        OVSEntities5 db = new OVSEntities5();
        // GET: Product
        [Route("GetProduct")]
        [HttpGet]
        public List<ProductVM> GetProduct()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Products.Select(zz => new ProductVM
            {
                Product_ID = zz.Product_ID,
                Product_Name = zz.Product_Name,
                Product_Description = zz.Product_Description,
                Product_Image = zz.Product_Image,
                Product_Type_ID = zz.Product_Type_ID,
                Quantity_on_hand = zz.Quantity_on_hand

            }).ToList();
        }

        // Get Product by ID

        [System.Web.Http.Route("getProductByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getProduct(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        //Add: Product
        [Route("CreateProduct")]
        [HttpPost]
        public ViewModels.ResponseObject CreateProduct([FromBody] ProductVM product)
        {
            
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ViewModels.ResponseObject();
            var Newpord = new Models.Product
            {
              
                Product_Name = product.Product_Name,
                Product_Description = product.Product_Description,
                Product_Image = product.Product_Image,
                //System.Text.Encoding.UTF8.GetBytes( WriteImage(product.Product_Image)),
                Product_Type_ID = product.Product_Type_ID,
                Quantity_on_hand = product.Quantity_on_hand,
            };

            try
            {
                db.Products.Add(Newpord);
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

        // Update Product

        [Route("UpdateProduct")]
        [HttpPut]
        public ViewModels.ResponseObject UpdateProduct([FromBody] ProductVM product)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ViewModels.ResponseObject();

            var toUpdate = db.Products.Where(zz => zz.Product_ID
            == product.Product_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Product_Name = product.Product_Name;
                toUpdate.Product_Description = product.Product_Description;
                toUpdate.Product_Image = product.Product_Image;
                toUpdate.Product_Type_ID = product.Product_Type_ID;
                toUpdate.Quantity_on_hand = product.Quantity_on_hand;

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



        //Delete Product
        [System.Web.Http.Route("DeleteProduct/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteProduct(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            db.Products.Remove(product);
            db.SaveChanges();

            return "Product deleted";

        }

       



    }
}