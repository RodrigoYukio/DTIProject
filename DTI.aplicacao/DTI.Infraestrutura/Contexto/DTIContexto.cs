using DTI.Dominio.Entidades;
using DTI.Infraestrutura.Mapeamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.EntityFrameworkCore;
using Tnf.Runtime.Session;

namespace DTI.Infraestrutura.Contexto
{
    public class DTIContexto : TnfDbContext
    {
        #region DbSet
        public DbSet<GE_FUNCIONARIO> GE_FUNCIONARIO { get; set; }
        #endregion

        public DTIContexto(DbContextOptions<DTIContexto> options, ITnfSession session) : base(options, session)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new GE_FUNCIONARIO_MAP());


            base.OnModelCreating(modelBuilder);
        }

        public async Task<object> ExecutarFuncao(string nomeFuncao)
        {
            using var comando = Database.GetDbConnection().CreateCommand();
            comando.CommandText = "SELECT " + nomeFuncao + " FROM DUAL";
            Database.OpenConnection();
            return await comando.ExecuteScalarAsync();
        }

        public class SequenceValueGenerator : ValueGenerator<int>
        {
            private readonly string _sequenceName;

            public SequenceValueGenerator(string sequenceName)
            {
                _sequenceName = sequenceName;
            }

            public override bool GeneratesTemporaryValues => false;

            public override int Next(EntityEntry entry)
            {
                using (var command = entry.Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = $"SELECT NEXTVAL('{_sequenceName}')";
                    entry.Context.Database.OpenConnection();
                    var reader = command.ExecuteScalar();
                    return Convert.ToInt32(reader);
                }
            }
        }
    }
}
