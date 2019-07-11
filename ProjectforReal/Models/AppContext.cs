using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectforReal.Models
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PostTag>().HasKey(ob =>new { ob.PostId, ob.TagId });

            builder.Entity<PostTag>()
                .HasOne<Post>(ob => ob.Post)
                .WithMany(ob => ob.PostTags)
                .HasForeignKey(Posttagobj => Posttagobj.PostId);

            builder.Entity<PostTag>()
                .HasOne<Tag>(ob => ob.Tag)// tu mówimy że obiekt PostTag ma połączenie z jednym Tagiem
                .WithMany(ob => ob.PostTags)// tu że ten wspomniany tag ma wiele połączeń 
                .HasForeignKey(PostTagobj => PostTagobj.TagId);// i łączy się z PostTagiem za pomocą pola w PostTagu

        }



        public DbSet<Tag> Tags { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostTag> PostTags { get; set; }


    }
}
