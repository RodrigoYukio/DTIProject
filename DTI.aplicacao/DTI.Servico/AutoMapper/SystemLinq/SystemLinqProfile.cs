using AutoMapper;
using DTI.Dominio.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace DTI.Servico.AutoMapper.SystemLinq
{
    public class SystemLinqProfile : Profile
    {
        public SystemLinqProfile()
        {
            CreateMap(typeof(ListDto<>), typeof(ListaBaseDto<>)).ForMember("QuantidadeRegistros", opt => opt.Ignore());//.ForAllMembers(opt => opt.Ignore());
        }
    }
}
