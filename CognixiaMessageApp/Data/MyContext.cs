using Microsoft.EntityFrameworkCore;
using CognixiaMessageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognixiaMessageApp.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Message { get; set; }
    }

}
