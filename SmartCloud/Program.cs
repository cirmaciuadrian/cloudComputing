using LibraryData.Classes;
using LibraryData.DataAccess.Repository;
using LibraryData.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartCloud.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCloud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Must whitelist your IP in the Azure portal -> SQL Server instance

            if (true)
            {
                using Context db = new Context();
                Class newClass = new Class()
                {
                    ClassName = "12A",
                    MaxClassSize = 25
                };
                GeneralRepository.AddClass(newClass);

                var addedClass = db.Classes.FirstOrDefault();

                Student newStudent = new Student()
                {
                    StudentName = "Cirmaciu Adrian",
                    Age = 23,
                    StudentClass=addedClass
                };
                Student newStudent2 = new Student()
                {
                    StudentName = "Marinescu Andrei",
                    Age = 22,
                    StudentClass = addedClass
                };
                Student newStudent3 = new Student()
                {
                    StudentName = "Popa Andrei",
                    Age = 24,
                    StudentClass = addedClass
                };

                // Add new student with classes
                GeneralRepository.AddStudent(newStudent);
                GeneralRepository.AddStudent(newStudent2);
                GeneralRepository.AddStudent(newStudent3);

                //// Update student's age
                //var dbStudent = GeneralRepository.GetStudents(newStudent.StudentName).First();
                //dbStudent.Age = 88;
                //GeneralRepository.UpdateStudent(dbStudent);
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
