using LibraryData.Classes;
using LibraryData.Enums;
using SmartCloud.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace SmartCloud.Repository
{
    public static class GeneralRepository
    {
        // Must whitelist your IP in the Azure portal -> SQL Server instance

        public static bool AddStuff(Student student, Class classTobeInserted)
        {
            using Context myContext = new Context();

            if (student != null)
            {
                myContext.Students.Add(student);
            }

            if (classTobeInserted != null)
            {
                myContext.Classes.Add(classTobeInserted);
            }

            return myContext.SaveChanges() != 0;
        }

        public static List<Class> GetClasses()
        {
            using Context myContext = new Context();

            var classes = myContext.Classes.ToList();

            return classes;
        }

        public static List<Student> GetStudents(string studentName)
        {
            using Context myContext = new Context();

            var students = myContext.Students.Where(s => s.StudentName == studentName).ToList();

            return students;
        }


        public static bool UpdateStudent (Student student)
        {
            using Context myContext = new Context();

            Student dbStudent =  myContext.Students.Where(s => s.StudentID == student.StudentID).FirstOrDefault();

            if (dbStudent != null)
            {
                dbStudent.StudentName = student.StudentName;
                dbStudent.Age = student.Age;
                dbStudent.StudentClasses = student.StudentClasses;
            }

            return myContext.SaveChanges() != 0;
        }
    }
}
