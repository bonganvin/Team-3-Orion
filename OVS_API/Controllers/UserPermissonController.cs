using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OVS_API.EF;
using OVS_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OVS_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserPermissonController : ControllerBase
    {

        private OVSContext _db;

        public UserPermissonController(OVSContext db)
        {
            _db = db;
        }

        [Route("CreateUserAccess")]
        [HttpPost]
        public IActionResult Create(UserPermissonClass model)
        {
            if (string.IsNullOrEmpty(model.UserAccessPermisson))
                return BadRequest("No access permisson exist");

            UserAccessPermission userAccess = new UserAccessPermission();

            userAccess.UserRoleName = model.UserAccessPermisson;
            userAccess.UserRoleDescription = model.UserAccessPermisson;

            _db.UserAccessPermissions.Add(userAccess);
            _db.SaveChanges();

            return Ok(userAccess);
        }

        [Route("ViewAllUserAccess")]
        [HttpGet]
        public IActionResult ViewAll()
        {
            var userAccess = _db.UserAccessPermissions.ToList();

            if (userAccess is null)
                return BadRequest("There exists none");

            return Ok(userAccess);

        }

        [Route("ViewUserAccess/{id}")]
        [HttpGet]
        public IActionResult View(int id)
        {
            var userAccess = _db.UserAccessPermissions.Find(id);

            if (userAccess is null)
                return BadRequest("This userAccess does not exist");

            return Ok(userAccess);
        }

        [Route("UpdateUserAccess")]
        [HttpPost]
        public IActionResult Update(UserPermissonClass model)
        {
            if (string.IsNullOrEmpty(model.UserAccessPermisson))
                return BadRequest("No access permisson exist");

            if (model.UserAccessID == 0)
                return BadRequest("No access permisson exist");

            var userAccess = _db.UserAccessPermissions.Find(model.UserAccessID);

            if (userAccess is null)
                return BadRequest("Access permisson is null");

            userAccess.UserRoleName = model.UserAccessPermisson;
            userAccess.UserRoleDescription = model.UserAccessPermisson;

            _db.UserAccessPermissions.Attach(userAccess);
            _db.SaveChanges();

            return Ok(userAccess);
        }

        [Route("DeleteUserAccess/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var userAccess = _db.UserAccessPermissions.Find(id);

            if (userAccess is null)
                return BadRequest("Access permisson is null");

            _db.UserAccessPermissions.Remove(userAccess);
            _db.SaveChanges();

            return Ok(userAccess);
        }
    }
}