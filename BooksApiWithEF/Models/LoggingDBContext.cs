using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BooksApiWithEF.Models
{
    public partial class LoggingDBContext : DbContext
    {
        public LoggingDBContext()
        {
        }

        public LoggingDBContext(DbContextOptions<LoggingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Logging> Loggings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LoggingDB;Integrated Security=True;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Logging>(entity =>
            {
                entity.ToTable("Logging");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Controller)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.SourceIp)
                    .HasMaxLength(50)
                    .HasColumnName("SourceIP")
                    .IsFixedLength(true);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
