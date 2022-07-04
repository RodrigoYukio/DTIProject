using DTI.Dominio.DTO;
using DTI.Dominio.DTO.Interfaces;
using DTI.Dominio.Entidades;
using DTI.Dominio.Modelos.DTO;
using DTI.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace DTI.Infraestrutura.Repositorios
{
    public class Ge_FuncionarioLeituraRepositorio : EfCoreRepositoryBase<DTIContexto, GE_FUNCIONARIO>, IGeFuncionarioLeituraRepositorio
    {
        public Ge_FuncionarioLeituraRepositorio(IDbContextProvider<DTIContexto> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Ge_FuncionarioDTO> BuscarPorNome(string nome)
        {
            var retorno = await GetAll((e) => e.Nome == nome).FirstOrDefaultAsync();
            return retorno.MapTo<Ge_FuncionarioDTO>();
        }

        public async Task<Ge_FuncionarioDTO> BuscarPorSeqFuncionario(int seqFuncionario)
        {
            var retorno = await GetAll((e) => e.SeqFuncionario == seqFuncionario).FirstOrDefaultAsync();
            return retorno.MapTo<Ge_FuncionarioDTO>();
        }

        public async Task<IListaBaseDto<Ge_FuncionarioDTO>> BuscarTodos(BuscarTodosGe_FuncionarioDTO buscarTodos)
        {
            var query = Table
                .OrderByDescending(x => x.SeqFuncionario)
                .AsQueryable();

            var teste = query.ToList();

            //Se houver filtro na pesquisa
            if (!buscarTodos.Filter.IsNullOrEmpty())
            {
                query = query.Where(e =>
                    (EF.Functions.Like(e.SeqFuncionario.ToString(), $"%{buscarTodos.SeqFuncionario}%") ||
                    EF.Functions.Like(e.Nome.ToUpper(), $"%{buscarTodos.Nome.ToUpper()}%") ||
                    EF.Functions.Like(e.Email.ToUpper(), $"%{buscarTodos.Email.ToUpper()}")) ||
                    EF.Functions.Like(e.Telefone.ToUpper(), $"%{buscarTodos.Telefone}") ||
                    EF.Functions.Like(e.DtaNascimento.ToString(), $"%{buscarTodos.DtaNascimento}") ||
                    EF.Functions.Like(e.Cpf, $"%{buscarTodos.Cpf}") ||
                    EF.Functions.Like(e.Setor.ToUpper(), $"%{buscarTodos.Setor.ToUpper()}") ||
                    EF.Functions.Like(e.Endereco.ToUpper(), $"%{buscarTodos.Endereco.ToUpper()}")
                );
            }
            else
            {
                if (buscarTodos.SeqFuncionario != null)
                {
                    query = query.Where(e => buscarTodos.SeqFuncionario.Any((emp) => e.SeqFuncionario == emp));
                }
                if (!buscarTodos.Nome.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Nome.ToUpper(), $"%{buscarTodos.Nome.ToUpper()}%"));
                }
                if (!buscarTodos.Email.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Email.ToUpper(), $"%{buscarTodos.Email.ToUpper()}%"));
                }
                if (!buscarTodos.Telefone.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Telefone.ToUpper(), $"%{buscarTodos.Telefone.ToUpper()}%"));
                }
                if (buscarTodos.DtaNascimento.ToString() != "01/01/0001 00:00:00")
                {
                    query = query.Where(e => EF.Functions.Like(e.DtaNascimento.ToString(), $"%{buscarTodos.DtaNascimento.ToString()}%"));
                }
                if (!buscarTodos.Endereco.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Endereco.ToUpper(), $"%{buscarTodos.Endereco.ToUpper()}%"));
                }
                if (!buscarTodos.Cpf.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Cpf.ToUpper(), $"%{buscarTodos.Cpf.ToUpper()}%"));
                }
                if (!buscarTodos.Setor.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Setor.ToUpper(), $"%{buscarTodos.Setor.ToUpper()}%"));
                }
            }

            return await query.RealizarConsultaAsync<GE_FUNCIONARIO, Ge_FuncionarioDTO>(buscarTodos);
        }
    }
}

