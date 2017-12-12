using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API
{
    // Use Nugget package Pomelo.EntityFramework.MySql
    public class SOVAContext : DbContext
    {
        // Public variables
        public DbSet<Commentsbody> commentsbody { get; set; }
        public DbSet<CommentUser> commentuser { get; set; }
        public DbSet<Marked> marked { get; set; }
        public DbSet<PersonalNotes> personalnotes { get; set; }
        public DbSet<PostsIndhold> postsindhold { get; set; }
        public DbSet<PostsLinkpostId> postslinkpostid { get; set; }
        public DbSet<PostsOwner> postsowner { get; set; }
        public DbSet<PostsTag> poststag { get; set; }
        public DbSet<SearchHistory> searchhistory { get; set; }

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
            if (dbParams[0] == "local"){
                this._connectionName = dbParams[1];
                this._dbName = dbParams[2];
                this._uid = dbParams[3];
                this._pwd = dbParams[4];
            }else{
                this._connectionName = dbParams[5];
                this._dbName = dbParams[6];
                this._uid = dbParams[7];
                this._pwd = dbParams[8];
            }
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
            .Property(x => x.Id).HasColumnName("Commentid");

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