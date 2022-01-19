using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using RadzenDh5.Models.Mark10Sqlexpress04;

namespace RadzenDh5.DHData
{
    public partial class DHDBContext : DbContext
    {
        //partial void OnModelBuilding(ModelBuilder builder)
             partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<SYNC_SRC>().HasNoKey();
            modelBuilder.Entity<SYNC_NAME_CNT>().HasKey(x=>x.NAME);
        }


        public DbSet<SYNC_SRC> SYNC_SRC
        {
            get;
            set;
        }
        public DbSet<SYNC_NAME_CNT> SYNC_NAME_CNT
        {
            get;
            set;
        }

    }

}
