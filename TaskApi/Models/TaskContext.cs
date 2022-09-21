using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TaskApi.Models
{
    public partial class TaskContext : DbContext
    {
        public TaskContext()
            : base("name=TaskContext")
        {
        }

        public virtual DbSet<Personnel> Personnels { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<QuoteType> QuoteTypes { get; set; }
        public virtual DbSet<TaskType> TaskTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personnel>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .HasMany(e => e.Quotes)
                .WithRequired(e => e.Personnel)
                .HasForeignKey(e => e.ContactId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.Id)
                .IsFixedLength();

            modelBuilder.Entity<Quote>()
                .Property(e => e.TaskDescription)
                .IsUnicode(false);

            modelBuilder.Entity<QuoteType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<QuoteType>()
                .HasMany(e => e.Quotes)
                .WithRequired(e => e.QuoteType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaskType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TaskType>()
                .HasMany(e => e.Quotes)
                .WithRequired(e => e.TaskType)
                .WillCascadeOnDelete(false);
        }
    }
}
