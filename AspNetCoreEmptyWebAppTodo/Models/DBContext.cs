using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using FirstWebApp.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestProject.DataDB

{

    public partial class DBContext : DbContext

    {

        public DBContext()

        {

        } 

        public DBContext(DbContextOptions<DBContext> options)            : base(options)

        {

        } 

        public virtual DbSet<Todo> Todo { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            if (!optionsBuilder.IsConfigured)

            {

                optionsBuilder.UseSqlServer("data source=localhost,5001; Initial Catalog=Aamio;Integrated Security=True;");

            }

        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS"); 

            modelBuilder.Entity<Todo>(entity =>

            {

                entity.ToTable("Todo");

                entity.Property(e => e.Description)

                    .HasMaxLength(1000)

                    .IsUnicode(false); 

                entity.Property(e => e.Title)

                    .HasMaxLength(50)

                    .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

   