using Database.Models;
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
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
       



        string DbConnectionString = new Configuration().DbConnectionString;
        public CollectiveContext()
        {

        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer(DbConnectionString)
                 .UseLazyLoadingProxies();
        }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
               .HasMany(p => p.Posts)                                                //one - to - many,  ---check user to posts/comments
               .WithOne(p => p.Author)                                               //one - to - one,   -- check comment to user
               .OnDelete(DeleteBehavior.NoAction);                                   //many - to - many   -- check posts to tags                                       

            modelBuilder.Entity<User>()
               .HasMany(p => p.Comments)
               .WithOne(p => p.Author)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(p => p.Author)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
              .HasMany(p => p.Tags)
              .WithMany(t => t.Posts);



        }



    }
}
// 7.Quick cheat sheet
// Relationship	Fluent API
// One-to-One	  HasOne().WithOne()
// One-to-Many	  HasMany().WithOne()
// Many-to-Many	  HasMany().WithMany()