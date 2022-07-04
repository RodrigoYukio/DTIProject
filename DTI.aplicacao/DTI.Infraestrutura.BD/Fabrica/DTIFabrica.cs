using DTI.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tnf.Drivers.DevartPostgreSQL;
using Tnf.Runtime.Session;

namespace DTI.Infraestrutura.BD.Fabrica
{
    public class DTIFabrica : IDesignTimeDbContextFactory<DTIContexto>
    {
         public DTIContexto CreateDbContext(string[] args)
          {
                var builder = new DbContextOptionsBuilder<DTIContexto>();

                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = config.GetConnectionString("DefaultConnection");
                builder.UseNpgsql(connectionString);
                PostgreSqlLicense.Validate(connectionString);

                return new DTIContexto(builder.Options, NullTnfSession.Instance);
          }
    }
}
