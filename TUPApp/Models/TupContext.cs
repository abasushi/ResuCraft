using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TUPApp.Models;

public partial class TupContext : DbContext
{
    public TupContext()
    {
    }

    public TupContext(DbContextOptions<TupContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EducationalBackground> EducationalBackgrounds { get; set; }

    public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TrainingsAttended> TrainingsAttendeds { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //=> optionsBuilder.UseSqlServer("Server=IA-LPT-0022\\SQLEXPRESS01;Database=TUP;ConnectRetryCount=0;user=sa;password=sean123;Persist Security Info=true;trustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EducationalBackground>(entity =>
        {
            entity.ToTable("EducationalBackground");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EducationalAttainment)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.School)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.YearGraduated)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.YearStarted)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.EducationalBackgrounds)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_EducationalBackground_Student");
        });

        modelBuilder.Entity<EmergencyContact>(entity =>
        {
            entity.ToTable("EmergencyContact");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmergencyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Relationship)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Student).WithMany(p => p.EmergencyContacts)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_EmergencyContact_Student");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.ToTable("Experience");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Experience1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Experience");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.YearEnded)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.YearStarted)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Experience_Student");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Skill1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Skill");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Student).WithMany(p => p.Skills)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Skills_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CareerObjective).IsUnicode(false);
            entity.Property(e => e.Contact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TrainingsAttended>(entity =>
        {
            entity.ToTable("TrainingsAttended");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Training)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.YearAttended)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.TrainingsAttendeds)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_TrainingsAttended_Student");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
