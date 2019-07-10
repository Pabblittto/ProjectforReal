using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectforReal.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        [MaxLength(200)]
        public string BlogName { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public BlogUserIdentity Owner { get; set; }
    }
}
