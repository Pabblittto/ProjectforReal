using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectforReal.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfComment { get; set; }

        [MaxLength(400)]
        public string Content { get; set; }

        [Required]
        public BlogUserIdentity Owner { get; set; }

        public int PostId { get; set; }
        public Post Post{get;set;}

        public ICollection<Comment> Answers { get; set; }//list of comments which ansewred to this comment
    }
}
