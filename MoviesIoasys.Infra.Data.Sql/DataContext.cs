﻿using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.Infra.Data.Sql
{
    public class DataContext : DbContext
    {
        public DataContext()
        { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Ioasys;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Notification>();

            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<Person>().HasKey(x => x.Id);
            builder.Entity<Movie>().HasKey(x => x.Id);
            builder.Entity<Category>().HasKey(x => x.Id);
        }
    }
}