using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectforReal.Models
{
    public class Tag// tags wchich help 
    {
        [Key]
        public int TagId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        //public int OwnerId { get; set; }// admin's Tags can not be deleted
        public BlogUserIdentity Owner { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
    }
}
