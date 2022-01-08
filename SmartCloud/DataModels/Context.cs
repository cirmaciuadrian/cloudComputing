﻿using Microsoft.EntityFrameworkCore;

namespace SmartCloud.DataModels
{
    public class Context: DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=tcp:tripleadbserver.database.windows.net,1433;Initial Catalog=main_db;Persist Security Info=False;User ID=devadmin;Password=devpassword123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        


    }
}