using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API
{
    // Hint: Use Nugget package Pomelo.EntityFramework.MySql
    public class SOVAContext : DbContext
    {
        // Private variables
        private string _connectionName;
        private string _dbName;
        private string _uid;
        private string _pwd;

        // Constructor with reading of inputs so the connection is modular
        public SOVAContext()
        {
            List<string> dbParams = new List<string>();
            StreamReader file = new StreamReader("db.conf");
            string line;

            // Read the file and display it line by line.  
            while ((line = file.ReadLine()) != null)
            {
                dbParams.Add(line.Split('=')[1]); 
            }
            file.Close();

            this._connectionName = dbParams[0];
            this._dbName = dbParams[1];
            this._uid = dbParams[2];
            this._pwd = dbParams[3];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(
                "server=" + this._connectionName +
                ";database=" + this._dbName +
                ";uid=" + this._uid +
                ";pwd=" + this._pwd
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}