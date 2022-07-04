using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace DTI.Dominio.DTO
{
   public  class BuscarTodosGe_FuncionarioDTO : RequestAllDto
    {
        public int[] SeqFuncionario { get; set; }
        public string Nome { get; set; }
        public DateTime DtaNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Setor { get; set; }
        public string Endereco { get; set; }

        public string Filter { get; set; }
    }
}
