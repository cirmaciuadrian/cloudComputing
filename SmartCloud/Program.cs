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
            using Context myContext = new Context();
            var myClasses = myContext.Classes.Where(c => c.ClassLanguage == Enums.Language.English).ToList();

            if (myClasses != null && myClasses.Count == 0 )
            {
                myContext.Students.Add(new Student()
                {
                    StudentName = "Andrei ABC",
                    StudentClasses = new List<Class>()
                    {
                        new Class()
                        {
                            ClassLanguage = Enums.Language.English,
                            ClassName = "myFirstClass",
                            MaxClassSize = 25
                        },
                        new Class()
                        {
                            ClassLanguage = Enums.Language.French,
                            ClassName = "mySecondClass",
                            MaxClassSize = 12
                        }
                    }
                });
                myContext.SaveChanges();
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
