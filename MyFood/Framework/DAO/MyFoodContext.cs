﻿using Microsoft.EntityFrameworkCore;
using MyFood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MyFood.Framework.DAO
{
    public class MyFoodContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public MyFoodContext(DbContextOptions<MyFoodContext> options) : base(options)
        {

        }
    }
}
