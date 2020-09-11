using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApiExample.Models;

namespace WebApiExample.Models
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DbConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
    }

}