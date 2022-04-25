﻿using LibraryAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) { }

        public DbSet<Book> Books { get; private set; }
        public DbSet<Client> Clients { get; private set; }
    }
}
