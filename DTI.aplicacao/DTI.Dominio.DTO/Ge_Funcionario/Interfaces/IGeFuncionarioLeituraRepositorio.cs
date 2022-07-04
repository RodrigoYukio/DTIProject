using DTI.Dominio.Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Repositories;

namespace DTI.Dominio.DTO.Interfaces
{
    public interface IGeFuncionarioLeituraRepositorio : IRepository
    {
        Task<IListaBaseDto<Ge_FuncionarioDTO>> BuscarTodos(BuscarTodosGe_FuncionarioDTO buscarTodos);
        Task<Ge_FuncionarioDTO> BuscarPorNome(string nome);
        Task<Ge_FuncionarioDTO> BuscarPorSeqFuncionario(int seqFuncionario);
    }
}
