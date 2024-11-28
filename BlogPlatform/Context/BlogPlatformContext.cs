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

       // public DbSet<Comment> BlogComments { get; set; }

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
                .WithOne(u => u.Blogger)
                .HasForeignKey<Blogger>(b => b.userId);
                

            modelBuilder.Entity<Reader>()
                .HasOne(r=>r.user)
                .WithOne(u=>u.Reader)
                .HasForeignKey<Reader>(r => r.userId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BlogPost>()
                .HasOne(bp => bp.Blogger)
                .WithMany(b => b.blogPosts)
                .HasForeignKey(bp => bp.BloggerID);


            //modelBuilder.Entity<Comment>()
            //    .HasOne(c => c.blogPost)
            //    .WithMany(b => b.Comments)
            //    .HasForeignKey(c => c.PostId);


           // modelBuilder.Entity<Comment>()
             //   .HasOne(c => c.Reader)
               // .WithMany(r => r.Comments)
                //.HasForeignKey(c => c.CommentId)
                //.HasConstraintName("FK_Comment_Reader");
               


        }
    }
}



