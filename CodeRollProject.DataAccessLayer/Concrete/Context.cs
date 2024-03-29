﻿using CodeRollProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.DataAccessLayer.Concrete
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-J0UOEGM\\SQLEXPRESS; database=CodeRollDb2; integrated security=true; TrustServerCertificate = True;");
		}
        // dizüstü   DESKTOP-OHHVBJO\\SQLEXPRESS
        // masaüstü  DESKTOP-J0UOEGM\\SQLEXPRESS

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasMany(x => x.Events)
        //}


        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteOption> VoteOptions { get; set; }
    }
}
