using LibraryData.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartCloud.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartCloud.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public async Task<ActionResult> IndexAsync(int? classId)
        {
            HttpClient httpClient = new HttpClient();
            var url = "http://MicroserviceStudent/student/get";
            var httpResponse = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(classId.HasValue ? classId.Value : 0), Encoding.UTF8, "application/json")
            });
            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();

                var students = JsonConvert.DeserializeObject<List<Student>>(response);
                var model = new StudentViewModel();
                model.StudentList = students;
                if (classId != null)
                {
                    model.hasClass = true;
                    model.ClassId = classId.Value;
                }
                httpClient.Dispose();
                return View(model);
            }
            else
            {
                throw new Exception("Erore la call api pentru get students");
            }
        }

       [HttpPost]
        public async Task<ActionResult> AddStudent(string name, int age, int classId)
        {
            HttpClient httpClient = new HttpClient();
            Student student = new Student { ClassId = classId, Age = age, StudentName = name };

            var url = "http://MicroserviceStudent/student/add";

            var httpResponse = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json")
            });

            var response = await httpResponse.Content.ReadAsStringAsync();


            httpClient.Dispose();
            return Json(new
            {
                msg = response
            });

        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
