using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace FileInformationEngine
{
    public class FileInformationContext : DbContext
    {
        public DbSet<FileInformation> FileInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WAKINGFORREST\SLEEPINGFOREST;Initial Catalog=CompareFileInformation;Integrated Security=True;");
        }
    }
}