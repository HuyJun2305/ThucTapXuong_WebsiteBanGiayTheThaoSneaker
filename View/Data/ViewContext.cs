using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataProcessing.Models;

namespace View.Data
{
    public class ViewContext : DbContext
    {
        public ViewContext (DbContextOptions<ViewContext> options)
            : base(options)
        {
        }

        public DbSet<DataProcessing.Models.Sole> Sole { get; set; } = default!;
    }
}
