namespace SINCOABR_CONTEXT.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SINCOABR_CONTEXT.Entities;

    public partial class SincoABRContext : DbContext
    {
        public SincoABRContext()
            : base("name=SincoABRContext")
        {
        }

        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Periods> Periods { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Teachers_Subjects> Teachers_Subjects { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notes>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<Periods>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Periods>()
                .HasMany(e => e.Notes)
                .WithRequired(e => e.Periods)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Roles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.attending)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.attendingNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.Notes)
                .WithRequired(e => e.Students)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subjects>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Subjects>()
                .HasMany(e => e.Notes)
                .WithRequired(e => e.Subjects)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subjects>()
                .HasMany(e => e.Teachers_Subjects)
                .WithRequired(e => e.Subjects)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teachers>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<Teachers>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Teachers>()
                .Property(e => e.specialization)
                .IsUnicode(false);

            modelBuilder.Entity<Teachers>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Teachers>()
                .HasMany(e => e.Teachers_Subjects)
                .WithRequired(e => e.Teachers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teachers_Subjects>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.latName)
                .IsUnicode(false);
        }
    }
}
