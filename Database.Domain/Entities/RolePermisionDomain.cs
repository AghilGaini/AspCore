using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class RolePermisionDomain
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string RoleId { get; set; }
        [Required]
        public long PermisionId { get; set; }
    }
}
