using OVS_Team_3_API.Models;
using OVS_Team_3_API.ViewModels;
using OVS_Team_3_API.ViewModels.Job_Subsystem;
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

namespace OVS_Team_3_API.Controllers.Job_Subsystem
{
    [RoutePrefix("api/Job_Task")]
    public class Job_TaskController : ApiController
    {
        OVSEntities5 db = new OVSEntities5();

        // GET: Job_Task
        [Route("GetJob_Task")]
        [HttpGet]
        public List<Job_TaskVM> GetJob_Task()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Job_task.Select(zz => new Job_TaskVM
            {
                Job_task_ID = zz.Job_task_ID,
                Job_ID = zz.Job_ID,
                Task_ID = zz.Task_ID,
                Job_Task_Status_ID = zz.Job_Task_Status_ID,
                Job_Task_Type_ID = zz.Job_Task_Type_ID

            }).ToList();
        }



        // Get Job_Task by ID

        [System.Web.Http.Route("getJob_TaskByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getJob_Task(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Job_task jobtask = db.Job_task.Find(id);
            if (jobtask == null)
            {
                return NotFound();
            }
            return jobtask;

        }



        //Add: Job_Task
        [Route("CreateJob_Task")]
        [HttpPost]
        public ResponseObject CreateJob_Task([FromBody] Job_TaskVM jobtask)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();
            var Newjobtask = new Job_task
            {
                Job_task_ID = jobtask.Job_task_ID,
                Job_ID = jobtask.Job_ID,
                Task_ID = jobtask.Task_ID,
                Job_Task_Status_ID = jobtask.Job_Task_Status_ID,
                Job_Task_Type_ID = jobtask.Job_Task_Type_ID
            };

            try
            {
                db.Job_task.Add(Newjobtask);
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



        // Update Job_Task

        [Route("UpdateJob_Task")]
        [HttpPut]
        public ResponseObject UpdateJob_Task([FromBody] Job_TaskVM jobtask)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();

            var toUpdate = db.Job_task.Where(zz => zz.Job_task_ID
            == jobtask.Job_task_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Job_task_ID = jobtask.Job_task_ID;
                toUpdate.Job_ID = jobtask.Job_ID;
                toUpdate.Task_ID = jobtask.Task_ID;
                toUpdate.Job_Task_Status_ID = jobtask.Job_Task_Status_ID;
                toUpdate.Job_Task_Type_ID = jobtask.Job_Task_Type_ID;

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


        //Delete Job_Task
        [System.Web.Http.Route("DeleteJob_Task/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteJob_Task(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Job_task jobtask = db.Job_task.Find(id);
            if (jobtask == null)
            {
                return NotFound();
            }
            db.Job_task.Remove(jobtask);
            db.SaveChanges();

            return "Job Task deleted";

        }


    }
}