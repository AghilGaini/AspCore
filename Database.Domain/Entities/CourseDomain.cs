using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class CourseDomain
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Title { get; set; }
    }
}
