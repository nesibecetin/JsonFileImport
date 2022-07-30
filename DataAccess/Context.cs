using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Mobiroller;Trusted_Connection=true");
        }

        public DbSet<Language> Language { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<StringResources> StringResources { get; set; }


        //   public DbSet<JsonTr> JsonTr { get; set; }
        //  public DbSet<JsonIt> JsonIt { get; set; }
        public DbSet<JsonFile> JsonFile { get; set; }
    }
}