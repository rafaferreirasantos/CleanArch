using CleanArch.Domain.Abstractions;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.CrossCutting.AppDependencies
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(
      this IServiceCollection services, IConfiguration configuration)
    {
      var connectionString = configuration.GetConnectionString("DefaultConnection");
      services.AddDbContext<AppDBContext>(options =>
      options.UseMySql(
        connectionString, ServerVersion.AutoDetect(connectionString)));

      services.AddScoped<IMemberRepository, MemberRepository>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();

      return services;
    }
  }
}
