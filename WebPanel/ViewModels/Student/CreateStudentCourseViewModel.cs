using System.Collections.Generic;

namespace WebPanel.ViewModels.Student
{
    public class CreateStudentCourseViewModel
    {
        public CreateStudentCourseViewModel()
        {
            CourseInfos = new List<CourseInfo>();
        }
        public long StudentId { get; set; }
        public List<CourseInfo> CourseInfos { get; set; }
    }
    public class CourseInfo
    {
        public long CourseId { get; set; }
        public string Title { get; set; }
        public bool IsSelected { get; set; }
    }
}
