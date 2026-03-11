

using DataBase.DataBaseProvider;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DataContext
{
    public class CollectiveContext : DbContext
    {   
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        
        
       
       


       
        public CollectiveContext() 
        {
           

        }
        public CollectiveContext(DbContextOptions<CollectiveContext> options) : base(options)
        {
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.DbConnectionString,
                        sqlOptions => sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(10),
                            errorNumbersToAdd: null
                        )
                    )
                    .UseLazyLoadingProxies();
            }

        }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            //one - to - many,  ---check user to posts/comments
            //one - to - one,   -- check comment to user
            //many - to - many   -- check posts to tags                                       

            modelBuilder.Entity<User>()
              .HasMany(u => u.Posts)
              .WithOne(p => p.Author)
              .HasForeignKey(p => p.AuthorId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Category>()
             .HasMany(c => c.Posts)
             .WithOne()
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
            .HasMany(c => c.Categories)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
            .HasMany(c => c.Tags)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Post>
                ().Navigation(p => p.Categories)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
            modelBuilder.Entity<Post>
               ().Navigation(p => p.Tags)
               .UsePropertyAccessMode(PropertyAccessMode.Property);


        }



    }
}
// 7.Quick cheat sheet
// Relationship	Fluent API
// One-to-One	  HasOne().WithOne()
// One-to-Many	  HasMany().WithOne()
// Many-to-Many	  HasMany().WithMany()