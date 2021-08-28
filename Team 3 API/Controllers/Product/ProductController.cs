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
using static System.Net.WebRequestMethods;
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
                ProductID = zz.Product_ID,
                ProductName = zz.Product_Name,
                ProductDescription = zz.Product_Description,
                ProductImage = zz.Product_Image,
                ProductTypeID = zz.Product_Type_ID,
                Quantityonhand = zz.Quantity_on_hand

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
        public ViewModels.ResponseObject CreateProduct( )
        {
            
            db.Configuration.ProxyCreationEnabled = false;

            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

    

            var response = new ViewModels.ResponseObject();
    
            var form = HttpContext.Current.Request.Form;
            var prd = new Models.Product { };
            prd.Product_Name = form.Get("ProductName");
            prd.Product_Description = form.Get("ProductDescription");
            prd.Product_Image = new byte[postedFile.ContentLength];
            postedFile.InputStream.Read(prd.Product_Image, 0, postedFile.ContentLength);
   
            prd.Product_Type_ID =Convert.ToInt32 (form.Get("ProductTypeID"));
            prd.Quantity_on_hand = Convert.ToInt32( form.Get("Quantityonhand"));
            try
            {
                // db.Products.Add(Newpord);
                db.Products.Add(prd);
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
            == product.ProductID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Product_Name = product.ProductName;
                toUpdate.Product_Description = product.ProductDescription;
                toUpdate.Product_Image = product.ProductImage;
                toUpdate.Product_Type_ID = product.ProductTypeID;
                toUpdate.Quantity_on_hand = product.Quantityonhand;

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