using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class StudentCourseDomain
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public long StudentId { get; set; }
        [Required]
        public long CourseId { get; set; }

    }
}
