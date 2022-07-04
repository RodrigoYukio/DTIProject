using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Dominio.Entidades.Repositorio
{
    public interface IGeFuncionarioRepositorio
    {
        Task<GE_FUNCIONARIO> InsertAsync(GE_FUNCIONARIO exemplo);
        Task<GE_FUNCIONARIO> UpdateAsync(GE_FUNCIONARIO exemplo);
    }
}
