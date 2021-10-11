using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccessLayer.Models;

#nullable disable

namespace DataAccessLayer.DataContext
{
    public partial class EmployeeManagementDBContext : DbContext
    {
        public EmployeeManagementDBContext()
        {
        }

        public EmployeeManagementDBContext(DbContextOptions<EmployeeManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Break> Breaks { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(" Server=TRAINEE-09; Database=EmployeeManagementDB; User ID=sa; Password=412417105083Vj;Trusted_Connection=false;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<Break>(entity =>
            {
                entity.Property(e => e.TotalBreakTime).HasComputedColumnSql("(CONVERT([decimal](5,1),datediff(minute,[BreakIn],[BreakOut])/(60.0)))", false);

                entity.HasOne(d => d.Entry)
                    .WithMany(p => p.Breaks)
                    .HasForeignKey(d => d.EntryId)
                    .HasConstraintName("FK__Break__EntryID__0B91BA14");
            });

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.Property(e => e.TotalWorkingTime).HasComputedColumnSql("(CONVERT([decimal](5,1),datediff(minute,[InTime],[OutTime])/(60.0)))", false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Entry__EmployeeI__08B54D69");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
