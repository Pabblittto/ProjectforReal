using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectforReal.Models
{
    public class Post
    {

        [Key]
        public int PostId { get; set; }

        [Column(TypeName ="Date")]
        public DateTime DateOfPost { get; set; }

        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public string ContentOne { get; set; }

        public string ContentTwo { get; set; }

        public ICollection<PostTag> PostTags { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
