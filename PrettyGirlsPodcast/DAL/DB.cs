using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrettyGirlsPodcast.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PrettyGirlsPodcast.DAL
{
    public class DB : DbContext
    {
        public DB() : base("DB")
        {
        }

        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<Host> Hosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}