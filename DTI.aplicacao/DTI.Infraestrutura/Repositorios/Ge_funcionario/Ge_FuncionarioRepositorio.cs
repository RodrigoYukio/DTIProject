using DTI.Dominio.Entidades;
using DTI.Dominio.Entidades.Repositorio;
using DTI.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace DTI.Infraestrutura.Repositorios
{
    public class Ge_FuncionarioRepositorio : EfCoreRepositoryBase<DTIContexto,GE_FUNCIONARIO>, IGeFuncionarioRepositorio
    {
        public Ge_FuncionarioRepositorio(IDbContextProvider<DTIContexto> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
