using LibraryData.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryData.DataAccess.Repository
{
    public static class GeneralRepository
    {
        // Must whitelist your IP in the Azure portal -> SQL Server instance

        public static bool AddStudent(Student student)
        {
            using Context myContext = new Context();

            if (student != null)
            {
                myContext.Students.Add(student);
            }

            //if (classTobeInserted != null)
            //{
            //    myContext.Classes.Add(classTobeInserted);
            //}

                return myContext.SaveChanges() != 0;
        }

        public static void AddClass(Class newClass)
        {
            using Context myContext = new Context();
            if(newClass != null)
            {
                myContext.Classes.Add(newClass);
            }
            myContext.SaveChanges();
        }

        public static List<Class> GetAllClasses()
        {
            using Context myContext = new Context();

            var classes = myContext.Classes.ToList();

            return classes;
        }

        public static List<Student> GetStudents(int? classId = null)
        {
            using Context myContext = new Context();
            List<Student> students = null;
            if (classId!=null)
                students = myContext.Students.Where(s => s.ClassId == classId.Value).ToList();
            else
                students = myContext.Students.ToList();

            return students;
        }

    


        //public static bool UpdateStudent(Student student)
        //{
        //    using Context myContext = new Context();

        //    Student dbStudent = myContext.Students.Where(s => s.StudentID == student.StudentID).FirstOrDefault();

        //    if (dbStudent != null)
        //    {
        //        dbStudent.StudentName = student.StudentName;
        //        dbStudent.Age = student.Age;
        //        dbStudent.StudentClasses = student.StudentClasses;
        //    }

        //    return myContext.SaveChanges() != 0;
        //}
    }
}
