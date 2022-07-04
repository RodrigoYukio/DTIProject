using DTI.Dominio.DTO;
using DTI.Dominio.Modelos.DTO;
using System.Threading.Tasks;

namespace DTI.Servico.Servicos
{
   public interface IGe_FuncionarioServico
    {
        Task<IListaBaseDto<Ge_FuncionarioDTO>> BuscarTodos(BuscarTodosGe_FuncionarioDTO buscarTodos);
        Task<AdicionarGe_FuncionarioDTO> Adicionar(AdicionarGe_FuncionarioDTO exemplo);
        Task<AlterarGe_FuncionarioDTO> Atualizar(int seqFuncionario, Ge_FuncionarioDTO exemploAtualizado);
    }
}
