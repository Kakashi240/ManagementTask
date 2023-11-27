using System;
using System.Collections.Generic;
using ManagementTask.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManagementTask.DataAccess
{
    public partial class TaskContext : DbContext
    {
        public TaskContext()
        {
        }

        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblTask> TblTasks { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;
        public virtual DbSet<UserTask> UserTasks { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server = KAKASHI\\SQLEXPRESS;Database = Task;User Id=sa; Password=Kakashi2403*");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblTask>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__TblTasks__7C6949B1C1E5367E");

                entity.Property(e => e.TaskId).ValueGeneratedOnAdd();

                entity.Property(e => e.TaskDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__TblUser__1788CC4C955F548B");

                entity.ToTable("TblUser");

                entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<UserTask>(entity =>
            {
                entity.HasOne(d => d.Task)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__UserTasks__TaskI__3B75D760");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserTasks__UserI__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
