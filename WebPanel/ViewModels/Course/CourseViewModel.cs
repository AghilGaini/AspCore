using Database.Domain.Entities;
using System.Collections.Generic;

namespace WebPanel.ViewModels.Course
{
    public class CourseViewModel
    {

        public CourseViewModel()
        {
            Courses = new List<CourseDomain>();
            Actions = new List<ActionItem>()
            {
                 new ActionItem()
                 {
                      Title = "Select"
                 }
            };
        }
        public List<CourseDomain> Courses { get; set; }
        public List<ActionItem> Actions { get; set; }
    }
}
