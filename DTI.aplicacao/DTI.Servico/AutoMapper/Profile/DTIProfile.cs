using AutoMapper;
using DTI.Dominio.DTO;
using DTI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTI.Servico.AutoMapper
{
    public class DTIProfile : Profile
    {
        public DTIProfile()
        {

            // GE Funcionario
            #region Domínio para Dto
            CreateMap<GE_FUNCIONARIO, Ge_FuncionarioDTO>();
            CreateMap<GE_FUNCIONARIO, AdicionarGe_FuncionarioDTO>();
            CreateMap<GE_FUNCIONARIO, BuscarTodosGe_FuncionarioDTO>();
            CreateMap<GE_FUNCIONARIO, AlterarGe_FuncionarioDTO>();
            #endregion

            #region Dto para Domínio
            CreateMap<Ge_FuncionarioDTO, GE_FUNCIONARIO>();
            CreateMap<BuscarTodosGe_FuncionarioDTO, GE_FUNCIONARIO>();
            CreateMap<AdicionarGe_FuncionarioDTO, GE_FUNCIONARIO>();
            CreateMap<AlterarGe_FuncionarioDTO, GE_FUNCIONARIO>();
            #endregion
        }
    }
}

