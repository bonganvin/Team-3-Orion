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
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        OVSEntities5 db = new OVSEntities5();
        // GET: User
        [Route("GetUser")]
        [HttpGet]
        public List<UserVM> GetUser()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Users.Select(zz => new UserVM
            {
                User_ID = zz.User_ID,
                User_Name = zz.User_Name,
                User_Password = zz.User_Password,
                User_Access_Permission_ID = zz.User_Access_Permission_ID

            }).ToList();
        }

        // Get User by ID

        [System.Web.Http.Route("getUserByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getUserByID(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;

        }

        //Add: User
        [Route("CreateUser")]
        [HttpPost]
        public ResponseObject CreateUser([FromBody] UserVM user)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();
            var Newuser = new User
            {
                User_Name = user.User_Name,
                User_Password = user.User_Password

            };

            try
            {
                db.Users.Add(Newuser);
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

        // Update User

        [Route("UpdateUser")]
        [HttpPut]
        public ResponseObject UpdateUser([FromBody] UserVM user)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();

            var toUpdate = db.Users.Where(zz => zz.User_ID
            == user.User_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.User_Name = user.User_Name;
                toUpdate.User_Password = user.User_Password;
                toUpdate.User_Access_Permission_ID = user.User_Access_Permission_ID;

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

        //Delete User
        [System.Web.Http.Route("DeleteUser/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteUser(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            User users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }
            db.Users.Remove(users);
            db.SaveChanges();

            return "deleted";

        }

    }
}