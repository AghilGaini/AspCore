using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class PermisionDomain
    {
        public long ID { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(70)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(70)]
        public string Value { get; set; }
    }
}
