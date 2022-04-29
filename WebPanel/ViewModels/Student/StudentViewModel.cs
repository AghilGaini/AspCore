using Database.Domain.Entities;
using System.Collections.Generic;
using Utilities;

namespace WebPanel.ViewModels.Student
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            Students = new List<StudentDomain>();
            Actions = new List<ActionItem>()
            {
                 new ActionItem()
                 {
                      Title = "Select"
                 }
            };
        }
        public PaginatedList<StudentDomain> PaginatedStudents { get; set; }
        public List<StudentDomain> Students { get; set; }
        public List<ActionItem> Actions { get; set; }
    }
}
