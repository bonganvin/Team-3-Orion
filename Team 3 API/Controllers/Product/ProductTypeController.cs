﻿using OVS_Team_3_API.Models;
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
    [RoutePrefix("api/ProductType")]
    public class ProductTypeController : ApiController
    {
        OVSEntities5 db = new OVSEntities5();
        // GET: ProductType
        [Route("GetProductType")]
        [HttpGet]
        public List<ProductTypeVM> GetProductType()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Product_Type.Select(zz => new ProductTypeVM
            {
                ProductTypeID = zz.Product_Type_ID,
                ProductTypeName = zz.Product_Type_Name,
                ProductCategoryID = zz.Product_Category_ID,

            }).ToList();
        }

        // Get ProductType by ID

        [System.Web.Http.Route("getProductTypeByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getProductTypeByID(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Product_Type product = db.Product_Type.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        //Add: ProductType
        [Route("CreateProductType")]
        [HttpPost]
        public ViewModels.ResponseObject CreateProductType([FromBody] ProductTypeVM product)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ViewModels.ResponseObject();
            var Newpord = new Models.Product_Type
            {
                Product_Type_ID = product.ProductTypeID,
                Product_Type_Name = product.ProductTypeName,
                Product_Category_ID = product.ProductCategoryID,
            };

            try
            {
                db.Product_Type.Add(Newpord);
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

        // Update ProductType

        [Route("UpdateProductType")]
        [HttpPut]
        public ViewModels.ResponseObject UpdateProductType([FromBody] ProductTypeVM product)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ViewModels.ResponseObject();

            var toUpdate = db.Product_Type.Where(zz => zz.Product_Type_ID
            == product.ProductTypeID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Product_Type_Name = product.ProductTypeName;
                toUpdate.Product_Category_ID = product.ProductCategoryID;

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

        //Delete ProductType
        [System.Web.Http.Route("DeleteProductType/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteProductType(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Product_Type product = db.Product_Type.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            db.Product_Type.Remove(product);
            db.SaveChanges();

            return "ProductType deleted";

        }

    }
}
