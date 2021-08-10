﻿using OVS_Team_3_API.Models;
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
    [RoutePrefix("api/PaymentType")]
    public class PaymentTypeController : ApiController
    {

        //[RoutePrefix("api/SalePaymentStatus")]

        OVSEntities5 db = new OVSEntities5();
        // GET: PaymentType
        [Route("GetPaymentType")]
        [HttpGet]
        public List<PaymentTypeVM> GetPaymentType()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Payment_Type.Select(zz => new PaymentTypeVM
            {
                Payment_Type_ID = zz.Payment_Type_ID,
                Payment_Type_Description = zz.Payment_Type_Description,
                Payment_Type_Name = zz.Payment_Type_Name

            }).ToList();
        }

        // Get PaymentType by ID

        [System.Web.Http.Route("getPaymentTypeByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getPaymentType(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Payment_Type PayType = db.Payment_Type.Find(id);
            if (PayType == null)
            {
                return NotFound();
            }
            return PayType;

        }

        //Add: PaymentType
        [Route("CreatePaymentType")]
        [HttpPost]
        public ResponseObject CreatePaymentType([FromBody] PaymentTypeVM PayType)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();
            var NewPayType = new Models.Payment_Type
            {
                Payment_Type_ID = PayType.Payment_Type_ID,
                Payment_Type_Description = PayType.Payment_Type_Description,
                Payment_Type_Name = PayType.Payment_Type_Name
            };

            try
            {
                db.Payment_Type.Add(NewPayType);
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

        // Update PaymentType

        [Route("UpdatePaymentType")]
        [HttpPut]
        public ResponseObject UpdatePaymentType([FromBody] PaymentTypeVM PayType)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();

            var toUpdate = db.Payment_Type.Where(zz => zz.Payment_Type_ID == PayType.Payment_Type_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Payment_Type_Name = PayType.Payment_Type_Name;
                toUpdate.Payment_Type_Description = PayType.Payment_Type_Description;

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
        //Delete PaymentType
        [System.Web.Http.Route("DeletePaymentType/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeletePaymentType(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Models.Payment_Type PayType = db.Payment_Type.Find(id);
            if (PayType == null)
            {
                return NotFound();
            }
            db.Payment_Type.Remove(PayType);
            db.SaveChanges();

            return "Deleted";

        }

    }


}