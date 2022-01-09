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

            if (!GeneralRepository.GetClasses().Any())
            {
                Student newStudent = new Student() {
                    StudentName = "Andrei ABC",
                    StudentClasses = new List<Class>()
                    {
                        new Class()
                        {
                            ClassLanguage = Language.English,
                            ClassName = "myFirstClass",
                            MaxClassSize = 25
                        },
                        new Class()
                        {
                            ClassLanguage = Language.French,
                            ClassName = "mySecondClass",
                            MaxClassSize = 12
                        }
                    }
                };

                // Add new student with classes
                GeneralRepository.AddStuff(newStudent, null);

                // Update student's age
                var dbStudent = GeneralRepository.GetStudents(newStudent.StudentName).First();
                dbStudent.Age = 88;
                GeneralRepository.UpdateStudent(dbStudent);
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
