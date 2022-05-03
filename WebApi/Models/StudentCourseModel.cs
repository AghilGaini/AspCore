using Database.Domain.Entities;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class StudentCourseModel
    {
        public long StudentId { get; set; }
        public List<long> CourseIds { get; set; }
    }
}
