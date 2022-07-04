using DTI.Infraestrutura.BD.Contexto;
using DTI.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTI.Infraestrutura.BD
{
        public static class ServiceCollectionExtensions
        {
            public static IServiceCollection AddEfCorePostgrees(this IServiceCollection services)
            {
                services.AddEfCore();

                services.AddTnfDbContext<DTIContexto, PostgreesContexto>(config =>
                {
                    config.DbContextOptions.UseNpgsql(config.ConnectionString);
                });

                return services;
            }
        }
}
