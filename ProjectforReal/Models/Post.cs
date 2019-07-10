using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectforReal.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<Tag> Tags { get; set; }

    }
}
