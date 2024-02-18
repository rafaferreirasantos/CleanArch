using CleanArch.Domain.Entities;
using CleanArch.Infrastruct.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastruct.Context
{
  internal class AppDBContext : DbContext
  {
    public AppDBContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Member> Members { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfiguration(new MemberConfiguration());
    }
  }
}
