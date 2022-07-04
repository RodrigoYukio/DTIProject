using DTI.Dominio.DTO;
using DTI.Dominio.DTO.Interfaces;
using DTI.Dominio.Entidades;
using DTI.Dominio.Entidades.Repositorio;
using DTI.Dominio.Modelos.DTO;
using DTI.Servico.Modelo;
using DTI.Servico.Servicos.Ge_CadastroFuncionario.Validacoes;
using DTI.Servico.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Notifications;
using Tnf.Repositories.Uow;

namespace DTI.Servico.Servicos
{
    public class Ge_FuncionarioServico : ServicoBase<GE_FUNCIONARIO>, IGe_FuncionarioServico
    {
        private readonly INotificationHandler _controleNotificacao;
        private readonly IUnitOfWorkManager _controleTransacao;
        private readonly IGeFuncionarioRepositorio _Repositorio;
        private readonly IGeFuncionarioLeituraRepositorio _LeituraRepositorio;

        public Ge_FuncionarioServico(
           INotificationHandler controleNotificacao,
           IUnitOfWorkManager controleTransacao,
           IGeFuncionarioRepositorio repositorio,
           IGeFuncionarioLeituraRepositorio leituraRepositorio
       ) : base(controleNotificacao, controleTransacao)
        {
            _controleTransacao = controleTransacao;
            _controleNotificacao = controleNotificacao;
            _Repositorio = repositorio;
            _LeituraRepositorio = leituraRepositorio;
        }

        public async Task<AdicionarGe_FuncionarioDTO> Adicionar(AdicionarGe_FuncionarioDTO exemplo)
        {
            try
            {
                if (!ValidateDto<AdicionarGe_FuncionarioDTO>(exemplo)) return null;

                var novoObj = exemplo.MapTo<GE_FUNCIONARIO>();

                var existeInconsitencia = await VerificaInconsistencias(novoObj);
                var novoExemplo = exemplo.MapTo<GE_FUNCIONARIO>();

                if (!existeInconsitencia && EstaValido(novoExemplo))
                {
                    novoExemplo = await _Repositorio.InsertAsync(novoExemplo);
                    if (await Commit())
                    {
                        return novoExemplo.MapTo<AdicionarGe_FuncionarioDTO>();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                return null;
            }
        }

        public async Task<AlterarGe_FuncionarioDTO> Atualizar(int seqFuncionario, Ge_FuncionarioDTO model)
        {
            try
            {
                if (!ValidateDto(model)) return null;
                var obj = await _LeituraRepositorio.BuscarPorSeqFuncionario(seqFuncionario);

                if (obj == null)
                {
                    RegistraLog.Log("Usuário não encontrado");
                    return null;
                }

                var novoModel = new AlterarGe_FuncionarioDTO()
                {
                    SeqFuncionario = obj.SeqFuncionario,
                    Nome = model.Nome.IsNullOrEmpty() ? obj.Nome : model.Nome,
                    Email = model.Email.IsNullOrEmpty() ? obj.Email : model.Email,
                    Telefone = model.Telefone.IsNullOrEmpty () ? obj.Telefone : model.Telefone,
                    Cpf = model.Cpf.IsNullOrEmpty() ? obj.Cpf : model.Cpf,
                    DtaNascimento = model.DtaNascimento.Equals(null) ? obj.DtaNascimento : model.DtaNascimento,
                    Endereco = model.Endereco.IsNullOrEmpty() ? obj.Endereco : model.Endereco,
                    Setor = model.Setor.IsNullOrEmpty() ? obj.Setor : model.Setor,

                };

                var novo = novoModel.MapTo<GE_FUNCIONARIO>();
                var existeInconsitencia = await VerificaInconsistencias(novo);

                if (!existeInconsitencia && EstaValido(novo))
                {
                    novo = await _Repositorio.UpdateAsync(novo);

                    return novo.MapTo<AlterarGe_FuncionarioDTO>();
                }

                return null;

            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                return null;
            }
        }

        public async Task<IListaBaseDto<Ge_FuncionarioDTO>> BuscarTodos(BuscarTodosGe_FuncionarioDTO buscarTodos)
        {
            try
            {
                return await _LeituraRepositorio.BuscarTodos(buscarTodos);
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                return null;
            }
        }

        protected override async Task<bool> VerificaInconsistencias(GE_FUNCIONARIO obj)
        {
            ValidacaoGe_Funcionario _validacao = new ValidacaoGe_Funcionario(_controleNotificacao);

            var email = _validacao.ValidaEmail(obj.Email);

            return email;
        }
    }
}
