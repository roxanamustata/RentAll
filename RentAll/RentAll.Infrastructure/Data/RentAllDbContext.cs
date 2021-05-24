
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAll.Domain;
using RentAll.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Infrastructure.Data
{
    public class RentAllDbContext:DbContext
    {
        private readonly string _connectionString ="Data Source=RALU\\SQLEXPRESS;Initial Catalog=RentAllDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public RentAllDbContext():base()
        {
           
        }

        public RentAllDbContext(DbContextOptions<RentAllDbContext> options):base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }



        public void Configure(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new LeaseConfig());
            modelBuilder.ApplyConfiguration(new CenterConfig());

            modelBuilder
              .Entity<Lease>()
              .HasMany(l => l.Units)
              .WithMany(u => u.Leases)
              .UsingEntity(j => j.ToTable("LeaseUnit"));


        }


    }
}
