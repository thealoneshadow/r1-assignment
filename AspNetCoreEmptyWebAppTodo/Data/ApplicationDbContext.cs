using FirstWebApp.Models;
using Microsoft.EntityFrameworkCore;
using FirstWebApp.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }
        public DbSet<Todo> Todo { get; set; }
        

       
    }
}
