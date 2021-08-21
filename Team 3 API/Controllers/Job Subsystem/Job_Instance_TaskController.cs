using Microsoft.Exchange.WebServices.Data;
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
    [RoutePrefix("api/Job_Instance_Task")]
    public class Job_Instance_TaskController : ApiController
    {
        OVSEntities5 db = new OVSEntities5();

        // GET: Job_Instance_Task
        [Route("GetJob_Instance_Task")]
        [HttpGet]
        public List<Job_Instance_TaskVM> GetJob_Instance_Task()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Job_Instance_Task.Select(zz => new Job_Instance_TaskVM
            {
                Job_Instance_Task_ID = zz.Job_Instance_Task_ID,
                Job_task_ID = zz.Job_task_ID,
                Job_Instance_ID = zz.Job_Instance_ID,
                Start_Date = zz.Start_Date,
                End_Date = zz.End_Date

            }).ToList();
        }


        // Get Job_Instance_Task by ID

        [System.Web.Http.Route("getJob_Instance_TaskByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getJob_Instance_Task(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Job_Instance_Task jonbinsttask = db.Job_Instance_Task.Find(id);
            if (jonbinsttask == null)
            {
                return NotFound();
            }
            return jonbinsttask;

        }


        //Add: Job_Instance_Task
        [Route("CreateJob_Instance_Task")]
        [HttpPost]
        public ResponseObject CreateJob_Instance_Task([FromBody] Job_Instance_TaskVM jonbinsttask)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();
            var Newjonbinsttask = new Job_Instance_Task
            {
                Job_Instance_Task_ID = jonbinsttask.Job_Instance_Task_ID,
                Job_task_ID = jonbinsttask.Job_task_ID,
                Job_Instance_ID = jonbinsttask.Job_Instance_ID,
                Start_Date = jonbinsttask.Start_Date,
                End_Date = jonbinsttask.End_Date
            };

            try
            {
                db.Job_Instance_Task.Add(Newjonbinsttask);
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


        // Update Job_Instance_Task

        [Route("UpdateJob_Instance_Task")]
        [HttpPut]
        public ResponseObject UpdateJob_Instance_Task([FromBody] Job_Instance_TaskVM jonbinsttask)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();

            var toUpdate = db.Job_Instance_Task.Where(zz => zz.Job_Instance_Task_ID
            == jonbinsttask.Job_Instance_Task_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Job_Instance_Task_ID = jonbinsttask.Job_Instance_Task_ID;
                toUpdate.Job_task_ID = jonbinsttask.Job_task_ID;
                toUpdate.Job_Instance_ID = jonbinsttask.Job_Instance_ID;
                toUpdate.Start_Date = jonbinsttask.Start_Date;
                toUpdate.End_Date = jonbinsttask.End_Date;

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


        //Delete Job_Instance_Task
        [System.Web.Http.Route("DeleteJob_Instance_Task/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteJob_Instance_Task(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Job_Instance_Task jonbinsttask = db.Job_Instance_Task.Find(id);
            if (jonbinsttask == null)
            {
                return NotFound();
            }
            db.Job_Instance_Task.Remove(jonbinsttask);
            db.SaveChanges();

            return "Job Instance Task deleted";

        }




    }
}