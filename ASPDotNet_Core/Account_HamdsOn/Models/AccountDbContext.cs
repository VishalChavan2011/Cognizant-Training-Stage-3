using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Account_HamdsOn.Models
{
    public class AccountDbContext:DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
