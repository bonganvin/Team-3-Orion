﻿using OVS_Team_3_API.Models;
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
    [RoutePrefix("api/Recipe_Line")]
    public class Recipe_LineController : ApiController
    {
        OVSEntities5 db = new OVSEntities5();

        // GET: Recipe_Line
        [Route("GetRecipe_Line")]
        [HttpGet]
        public List<Recipe_LineVM> GetRecipe_Line()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Reciple_Line.Select(zz => new Recipe_LineVM
            {
                Reciple_Line_ID = zz.Reciple_Line_ID,
                Quantity = zz.Quantity,
                Recipe_ID = zz.Recipe_ID,
                Raw_Material_ID = zz.Raw_Material_ID,
                Recipe_Line_unit_ID = zz.Recipe_Line_unit_ID

            }).ToList();
        }



        // Get Recipe_Line by ID

        [System.Web.Http.Route("getRecipe_LineByID/{id:int}")]
        [System.Web.Mvc.HttpPost]
        [HttpPost]
        public object getRecipe_Line(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Reciple_Line recipeline = db.Reciple_Line.Find(id);
            if (recipeline == null)
            {
                return NotFound();
            }
            return recipeline;

        }



        //Add: Recipe_Line
        [Route("CreateRecipe_Line")]
        [HttpPost]
        public ResponseObject CreateRecipe_Line([FromBody] Recipe_LineVM recipeline)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();
            var Newrecipeline = new Reciple_Line
            {
                Reciple_Line_ID = recipeline.Reciple_Line_ID,
                Quantity = recipeline.Quantity,
                Recipe_ID = recipeline.Recipe_ID,
                Raw_Material_ID = recipeline.Raw_Material_ID,
                Recipe_Line_unit_ID = recipeline.Recipe_Line_unit_ID
            };

            try
            {
                db.Reciple_Line.Add(Newrecipeline);
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



        // Update Recipe_Line

        [Route("UpdateRecipe_Line")]
        [HttpPut]
        public ResponseObject UpdateRecipe_Line([FromBody] Recipe_LineVM recipeline)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var response = new ResponseObject();

            var toUpdate = db.Reciple_Line.Where(zz => zz.Reciple_Line_ID
            == recipeline.Reciple_Line_ID).FirstOrDefault();

            if (toUpdate == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found";
                return response;
            }

            try
            {
                toUpdate.Reciple_Line_ID = recipeline.Reciple_Line_ID;
                toUpdate.Quantity = recipeline.Quantity;
                toUpdate.Recipe_ID = recipeline.Recipe_ID;
                toUpdate.Raw_Material_ID = recipeline.Raw_Material_ID;
                toUpdate.Recipe_Line_unit_ID = recipeline.Reciple_Line_ID;

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


        //Delete Recipe_Line
        [System.Web.Http.Route("DeleteRecipe_Line/{id:int}")]
        [System.Web.Mvc.HttpDelete]
        [HttpDelete]
        public object DeleteRecipe_Line(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Reciple_Line recipeline = db.Reciple_Line.Find(id);
            if (recipeline == null)
            {
                return NotFound();
            }
            db.Reciple_Line.Remove(recipeline);
            db.SaveChanges();

            return "Recipe Line deleted";

        }


    }
}