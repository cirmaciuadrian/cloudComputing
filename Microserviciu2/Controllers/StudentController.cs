using LibraryData.Classes;
using LibraryData.DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MicroserviceStudent.Controllers
{
   
    [ApiController]
    public class StudentController : ControllerBase
    {
        [Route("student/get")]
        [HttpGet]
        public IEnumerable<Student> Get([FromBody] int? classId)
        {
            if (classId == 0)
                classId = null;
            return GeneralRepository.GetStudents(classId).ToList();

        }


        [Route("student/add")]
        [HttpPost]
        public string AddClass(Student student)
        {
            string msg = "";

            try
            {
                GeneralRepository.AddStudent(student);
                msg = "Student was added succesfuly (message form api)";
                return msg;
            }
            catch (Exception ex)
            {
                msg = "eroare: " + ex.ToString();
                return msg;
            }
        }
    }
}
