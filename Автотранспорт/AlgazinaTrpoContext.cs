using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Автотранспорт;

public partial class AlgazinaTrpoContext : DbContext
{
    public AlgazinaTrpoContext()
    {
    }

    public AlgazinaTrpoContext(DbContextOptions<AlgazinaTrpoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Work> Works { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-ST0U4SSV\\SQLEXPRESS;Initial Catalog=Algazina_TRPO;trustservercertificate=true;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Drvers");

            entity.Property(e => e.Fio).HasColumnName("FIO");
        });

        modelBuilder.Entity<Work>(entity =>
        {
            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Cars).WithMany(p => p.Works)
                .HasForeignKey(d => d.CarsId)
                .HasConstraintName("FK_Works_Cars");

            entity.HasOne(d => d.Drivers).WithMany(p => p.Works)
                .HasForeignKey(d => d.DriversId)
                .HasConstraintName("FK_Works_Drivers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
