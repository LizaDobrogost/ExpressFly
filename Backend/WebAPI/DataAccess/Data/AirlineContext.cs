using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class AirlineContext : DbContext
    {
        public DbSet<AccountEntity> Accounts { get; set; }
        public AirlineContext(DbContextOptions<AirlineContext> options) :
            base(options)
        {
        }
    }
}