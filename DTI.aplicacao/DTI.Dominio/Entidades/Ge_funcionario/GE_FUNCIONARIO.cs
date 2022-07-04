using DTI.Dominio.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTI.Dominio.Entidades
{
    public class GE_FUNCIONARIO : Entidade<GE_FUNCIONARIO>
    {
        #region VARIAVEIS
        public int SeqFuncionario { get; private set; }
        public string Nome { get; private set; }
        public DateTime DtaNascimento { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Setor { get; private set; }

        public string Endereco { get; private set; }

        public GE_FUNCIONARIO() { }

        public GE_FUNCIONARIO(int seqFuncionario, string nome, DateTime dtaNascimento, string telefone, string email, string cpf, string setor, string endereco)
        {
            SeqFuncionario = seqFuncionario;
            Nome = nome;
            DtaNascimento = dtaNascimento;
            Telefone = telefone;
            Email = email;
            Cpf = cpf;
            Setor = setor;
            Endereco = endereco;


            Validar(this);
        }

        public override bool EstaValido()
        {
            return ResultadoValidacao.IsValid;
        }
        #endregion


    }
}
