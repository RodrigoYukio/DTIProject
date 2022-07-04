using DTI.Dominio.Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace DTI.Dominio.Modelos.Entidades
{
    public class ListaBaseDto<TDto> : ListDto<TDto>, IListaBaseDto<TDto>
    {
        public int QuantidadeRegistros { get; set; }
    }
}
