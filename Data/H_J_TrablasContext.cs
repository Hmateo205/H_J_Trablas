using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using H_J_Trablas.Models;

namespace H_J_Trablas.Data
{
    public class H_J_TrablasContext : DbContext
    {
        public H_J_TrablasContext (DbContextOptions<H_J_TrablasContext> options)
            : base(options)
        {
        }

        public DbSet<H_J_Trablas.Models.Cedulas> Cedulas { get; set; } = default!;
    }
}
