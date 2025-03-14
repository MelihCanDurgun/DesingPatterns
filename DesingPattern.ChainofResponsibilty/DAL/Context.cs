﻿using Microsoft.EntityFrameworkCore;

namespace DesingPattern.ChainofResponsibilty.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-3RLDHM4\\SQLEXPRESS; initial catalog=DesingPattern1;integrated security=true");
        }
        public DbSet<CustomerProsses> CustomerProsesses { get; set; }
    }
}
