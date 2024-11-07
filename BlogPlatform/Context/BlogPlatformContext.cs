using Microsoft.EntityFrameworkCore;
using BlogPlatform.Models;


namespace BlogPlatform.Context
{


    public class BlogPlatformContext : DbContext
    {
        public BlogPlatformContext(DbContextOptions<BlogPlatformContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Blogger> Blogs { get; set; }

        public DbSet<Reader> Readers { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Comment> BlogComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blogger>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Blogger>(b => b.userId);

            modelBuilder.Entity<Reader>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Reader>(r => r.userId);
            modelBuilder.Entity<BlogPost>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(bp => bp.AuthorId);
            modelBuilder.Entity<Comment>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.AuthorId);


        }
    }
}



