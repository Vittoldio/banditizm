using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpeakAndRead.Models;

namespace SpeakAndRead.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<CourseUser> CourseUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // create tables for Identity

            modelBuilder.Entity<CourseUser>()
                        .HasKey(t => new { t.CourseId, t.UserId });
            modelBuilder.Entity<CourseUser>()
                        .HasOne(cs => cs.Course)
                        .WithMany(p => p.CourseUsers)
                        .HasForeignKey(cs => cs.CourseId);
            modelBuilder.Entity<CourseUser>()
                        .HasOne(cs => cs.User)
                        .WithMany(s => s.CourseUsers)
                        .HasForeignKey(cs => cs.UserId);
        }
    }
}
