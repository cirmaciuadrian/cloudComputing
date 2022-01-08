using System.Collections.Generic;

namespace SmartCloud.DataModels
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set;}
        public int Age { get; set;}

        public List<Class> StudentClasses { get; set; }

    }
}
