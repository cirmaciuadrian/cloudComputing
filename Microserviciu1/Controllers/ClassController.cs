using LibraryData.Classes;
using LibraryData.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservice_Class.Controllers
{
    [ApiController]
   
    public class ClassController : ControllerBase
    {
        [Route("class/get")]
        [HttpGet]
        public IEnumerable<LibraryData.Classes.Class> GetClasses(string orice)
        {

            return GeneralRepository.GetAllClasses().ToList();

        }
        //// GET: api/<ClassController>
        //[HttpGet]
        //public IEnumerable<Class> Get()
        //{

        //    return LibraryData.DataAccess.Repository.GeneralRepository.GetAllClasses().ToList();

        //}

        // GET api/<ClassController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ClassController>
        [Route("class/addclass")]
        [HttpPost]
        public string AddClass(Class newCLass)
        {
            string msg = "";
          
            try
            {
                GeneralRepository.AddClass(newCLass);
                msg = "Class was added succesfuly (message form api)";
                return msg;
            }
            catch (Exception ex)
            {
                msg = "eroare: " + ex.ToString();
                return msg;
            }
        }

        // PUT api/<ClassController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClassController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
