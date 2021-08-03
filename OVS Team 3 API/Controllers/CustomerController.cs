using OVS_Team_3_API.Models;
using OVS_Team_3_API.ViewModels;
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
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        OVSEntities5 db = new OVSEntities5();
        // GET: Customer
        [Route("GetCustomer")]
        [HttpGet]
        public List<CustomerVM> GetCustomer()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Customers.Select(zz => new CustomerVM
            {
                Customer_ID = zz.Customer_ID,
                Customer_Name = zz.Customer_Name,
                Customer_Surname = zz.Customer_Surname,
                Customer_Cellphone_Number = zz.Customer_Cellphone_Number,
                Customer_Date_Of_Birth = zz.Customer_Date_Of_Birth,
                Customer_Email_Address = zz.Customer_Email_Address,
                Customer_Physical_Address = zz.Customer_Physical_Address,
                Customer_Type_ID = zz.Customer_Type_ID,
                User_ID = zz.User_ID

            }).ToList();
        }

        // Get Customer by ID

        [System.Web.Http.Route("getCustomerByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getCustomer(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Customer cust = db.Customers.Find(id);
            if (cust == null)
            {
                return NotFound();
            }
            return cust;

        }

        //Add: Customer
        [Route("CreateCustomer")]
        [HttpPost]
        public ResponseObject CreateCustomer([FromBody] CustomerVM cust)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();
            var NewCust = new Customer
            {
                Customer_Name = cust.Customer_Name,
                Customer_Surname = cust.Customer_Surname,
                Customer_Cellphone_Number = cust.Customer_Cellphone_Number,
                Customer_Date_Of_Birth = cust.Customer_Date_Of_Birth,
                Customer_Email_Address = cust.Customer_Email_Address,
                Customer_Physical_Address = cust.Customer_Physical_Address,
                Customer_Type_ID = cust.Customer_Type_ID,
                User_ID = cust.User_ID
            };

            try
            {
                db.Customers.Add(NewCust);
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

        // Update Customer

        [Route("UpdateCustomer")]
        [HttpPut]
        public ResponseObject UpdateCustomer([FromBody] CustomerVM cust)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();

            var toUpdate = db.Customers.Where(zz => zz.Customer_ID
            == cust.Customer_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Customer_Name = cust.Customer_Name;
                toUpdate.Customer_Surname = cust.Customer_Surname;
                toUpdate.Customer_Cellphone_Number = cust.Customer_Cellphone_Number;
                toUpdate.Customer_Date_Of_Birth = cust.Customer_Date_Of_Birth;
                toUpdate.Customer_Email_Address = cust.Customer_Email_Address;
                toUpdate.Customer_Physical_Address = cust.Customer_Physical_Address;
                toUpdate.Customer_Type_ID = cust.Customer_Type_ID;
                toUpdate.User_ID = cust.User_ID;

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

        //Delete Customer
        [System.Web.Http.Route("DeleteCustomer/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteCustomer(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Customer cust = db.Customers.Find(id);
            if (cust == null)
            {
                return NotFound();
            }
            db.Customers.Remove(cust);
            db.SaveChanges();

            return "deleted";

        }
    }
}