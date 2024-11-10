using Microsoft.EntityFrameworkCore;
using BlogPlatform.Models;
using System.Xml.Linq;


namespace BlogPlatform.Context
{


    public class BlogPlatformContext : DbContext
    {
        public BlogPlatformContext(DbContextOptions<BlogPlatformContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Blogger> Bloggers { get; set; }

        public DbSet<Reader> Readers { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Comment> BlogComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //       modelBuilder.Entity<User>()
            //         .HasOne<Blogger>()

            //         .WithOne()
            //         .HasForeignKey<Blogger>(c => c.userId)
            //         .OnDelete(DeleteBehavior.Cascade);
            ////        .HasForeignKey<Blogger>(b => b.userId);

            //        modelBuilder.Entity<Blogger>()
            //          .HasOne<User>()
            //          .WithOne()
            //          .HasForeignKey<BlogPost>(r => r.PostId)
            //          .OnDelete(DeleteBehavior .Cascade);
            //        modelBuilder.Entity<BlogPost>()
            //           .HasOne<User>()
            //           .WithMany()
            //           .HasForeignKey(r => r.PostId)
            //           .OnDelete(DeleteBehavior.Cascade);



            //   .HasForeignKey(bp => bp.AuthorId);
            //    modelBuilder.Entity<Comment>()
            //        .HasOne<User>()
            //        .WithMany()
            //        .HasForeignKey(c => c.AuthorId);

            modelBuilder.Entity<Blogger>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bloggers)
                .HasForeignKey(b => b.userId);
                

            modelBuilder.Entity<Reader>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.userId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BlogPost>()
                .HasOne<Blogger>()
                .WithMany()
                .HasForeignKey(bp => bp.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne<BlogPost>()
                .WithMany()
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne<Reader>()
                .WithMany()
                .HasForeignKey(c =>c.PostId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}



