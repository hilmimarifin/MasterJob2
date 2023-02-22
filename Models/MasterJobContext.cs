using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MasterJob.Models;

public partial class MasterJobContext : DbContext
{
    public MasterJobContext()
    {
    }

    public MasterJobContext(DbContextOptions<MasterJobContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<JobPosition> JobPositions { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5433;Database=master-job;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_pk");

            entity.ToTable("employee");

            entity.Property(e => e.Id)
                .HasColumnType("character varying")
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.JobPositionId)
                .HasColumnType("character varying")
                .HasColumnName("job_position_id");
            entity.Property(e => e.JobTitleId)
                .HasColumnType("character varying")
                .HasColumnName("job_title_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Nik)
                .HasColumnType("character varying")
                .HasColumnName("nik");

            entity.HasOne(d => d.JobPosition).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobPositionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_fk");
        });

        modelBuilder.Entity<JobPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("job_position_pk");

            entity.ToTable("job_position");

            entity.Property(e => e.Id)
                .HasColumnType("character varying")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.TitleId)
                .HasColumnType("character varying")
                .HasColumnName("title_id");

            entity.HasOne(d => d.Title).WithMany(p => p.JobPositions)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("job_position_fk");
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("job_title_pk");

            entity.ToTable("job_title");

            entity.Property(e => e.Id)
                .HasColumnType("character varying")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
