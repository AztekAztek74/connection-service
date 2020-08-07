using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.EarlyCompletion
{
    public class EarlyCompletionContext: DbContext
    {
        public EarlyCompletionContext(DbContextOptions<EarlyCompletionContext> options) : base(options)
        {
        }
        public DbSet<EarlyCompletion> EarlyCompletions { get; set; }
    }
}
