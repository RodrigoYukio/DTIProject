using DTI.Dominio.DTO;
using DTI.Dominio.DTO.Interfaces;
using DTI.Dominio.Modelos.DTO;
using DTI.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tnf.AspNetCore.Mvc.Response;

namespace DTI.Aplicacao.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class CadastroFuncionarioController : TnfController
    {
        private readonly IGeFuncionarioLeituraRepositorio _leituraRepositorio;
        private readonly IGe_FuncionarioServico _Servico;

        public CadastroFuncionarioController(IGeFuncionarioLeituraRepositorio leituraRepositorio,
            IGe_FuncionarioServico servico)
        {
            _leituraRepositorio = leituraRepositorio;
            _Servico = servico;
        }

        //Traz todos os Funcionários
        [HttpGet]
        [ProducesResponseType(typeof(IListaBaseDto<Ge_FuncionarioDTO>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> BuscarTodos([FromQuery] BuscarTodosGe_FuncionarioDTO buscarTodos)
        {
            return CreateResponseOnGetAll(await _Servico.BuscarTodos(buscarTodos));
        }

        //Insere novo Funcionários
        [HttpPost]
        [ProducesResponseType(typeof(Ge_FuncionarioDTO), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Post([FromBody] AdicionarGe_FuncionarioDTO exemploDto)
        {

            var exemplo = await _Servico.Adicionar(exemploDto);
            if (exemplo == null)
            {
                return BadRequest("Erro ao inserir o Funcionario");
            }
            else
            {
                return CreateResponseOnPost(exemplo);
            }
        }

        //Altera um Funcionário
        [HttpPut]
        //[Authorize("Bearer")]
        [ProducesResponseType(typeof(Ge_FuncionarioDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Atualizar([FromQuery] int seqFuncionario, [FromBody] Ge_FuncionarioDTO exemploDto)
        {

            var exemplo = await _Servico.Atualizar(seqFuncionario, exemploDto);
            if (exemplo == null)
            {
                return BadRequest("Erro ao alterar o Funcionario");
            }
            else
            {
                return CreateResponseOnPut(exemplo);
            }
        }

        //Retorna um unico funcionário pelo nome
        [HttpGet("funcionario")]
        //[Authorize("Bearer")]
        [ProducesResponseType(typeof(BuscarUmGe_FuncionarioDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> BuscarFuncionario(int seqFuncionario)
        {
            var retorno = await _leituraRepositorio.BuscarPorSeqFuncionario(seqFuncionario);
            if (retorno == null)
            {
                BuscarUmGe_FuncionarioDTO retornoErro = new BuscarUmGe_FuncionarioDTO()
                {
                    MensagemErro = "Não foram encontrados usuários com esse título"
                };
                return CreateResponseOnGet(retornoErro);
            }
            else
            {
                return CreateResponseOnGet(retorno);
            }
        }
    }
}
