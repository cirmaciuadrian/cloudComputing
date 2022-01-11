using LibraryData.Classes;
using System.Collections.Generic;

namespace SmartCloud.ViewModels
{
    public class StudentViewModel
    {
        public List<Student> StudentList { get; set; }
        public bool? hasClass { get; set; }
        public int? ClassId { get; set; }
    }
}
