using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudMVC8.Models;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    
    public virtual DbSet<Student> Students { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LAPTOP-KRUVNM2M\\SQLEXPRESS01;Database=StudentDB;Trusted_Connection=True;Encrypt=False;");

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
    
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07B2B478E5");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
