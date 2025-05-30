﻿using Microsoft.EntityFrameworkCore;
using EShop.Domain.Models;
using System.Collections.Generic;

namespace EShop.Domain.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
