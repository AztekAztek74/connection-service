using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.UsersData
{
    public class UsersDataContext: DbContext
    {
        public UsersDataContext(DbContextOptions<UsersDataContext> options) : base(options)
        {
        }
        public DbSet<UsersData> UsersDatas { get; set; }
    }
}
