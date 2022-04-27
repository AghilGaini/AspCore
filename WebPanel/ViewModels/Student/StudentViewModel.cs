using Database.Domain.Entities;
using System.Collections.Generic;

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

        public List<StudentDomain> Students { get; set; }
        public List<ActionItem> Actions { get; set; }
    }
}
