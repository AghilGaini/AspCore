using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class StudentDomain
    {
        [Required]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        [Column(TypeName = "VARCHAR")]
        public string NationalCode { get; set; }
        [Required]
        public int Age { get; set; }

    }
}
