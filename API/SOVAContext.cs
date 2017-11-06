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
        // Public variables
        public DbSet<Commentsbody> Commentsbody { get; set; }
        public DbSet<CommentUser> CommentUser { get; set; }
        public DbSet<Marked> Marked { get; set; }
        public DbSet<PersonalNotes> PersonalNotes { get; set; }
        public DbSet<PostsIndhold> PostsIndhold { get; set; }
        public DbSet<PostsLinkpostId> PostsLinkpostId { get; set; }
        public DbSet<PostsOwner> PostsOwner { get; set; }
        public DbSet<PostsTag> PostsTag { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }

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

            modelBuilder.Entity<Commentsbody>()
            .Property(x => x.Id).HasColumnName("Id");

            modelBuilder.Entity<CommentUser>()
            .Property(x => x.Id).HasColumnName("Id");

            modelBuilder.Entity<Marked>()
            .Property(x => x.Mid).HasColumnName("Markedid");

            modelBuilder.Entity<PersonalNotes>()
            .Property(x => x.Nid).HasColumnName("NoteId");

            modelBuilder.Entity<PostsIndhold>()
            .Property(x => x.Id).HasColumnName("Id");

            modelBuilder.Entity<PostsLinkpostId>()
            .HasKey(c => new { c.Id, c.LinkpostId });

            modelBuilder.Entity<PostsOwner>()
            .Property(x => x.Oid).HasColumnName("OwnerUserId");

            modelBuilder.Entity<PostsTag>()
            .Property(x => x.Id).HasColumnName("Id");

            modelBuilder.Entity<SearchHistory>()
            .Property(x => x.Id).HasColumnName("SearchNumberId");
        }
    }
}