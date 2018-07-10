using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FileInformationEngine
{
    public class FileInfoContext : DbContext
    {
        public DbSet<FileInformation> FileInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WAKINGFORREST\SLEEPINGFOREST;Initial Catalog=CompareFileInformation;Integrated Security=True;");
        }
    }
}