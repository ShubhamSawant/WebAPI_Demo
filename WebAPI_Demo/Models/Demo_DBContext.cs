
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI_Demo.Models
{
    public partial class Demo_DBContext : DbContext
    {
        public Demo_DBContext()
        {
        }

        public Demo_DBContext(DbContextOptions<Demo_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=INPU-1A902-LT-R;Database=Demo_DB;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Department).IsUnicode(false);

                entity.Property(e => e.EmployeeLocation)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Location");

                entity.Property(e => e.EmployeeName)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
