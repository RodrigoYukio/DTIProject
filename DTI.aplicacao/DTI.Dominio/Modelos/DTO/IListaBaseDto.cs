using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace DTI.Dominio.Modelos.DTO
{
    public interface IListaBaseDto<TDto> : IListDto<TDto>
    {
        public int QuantidadeRegistros { get; set; }
    }
}
