using System;
using System.Collections.Generic;
using System.Text;

namespace DTI.Dominio.Localizacao
{
    public class LocalizacaoCaminho
    {
        public static string MensagensErro { get; } = "MensagensErro";
        public static string ErroAoBuscarFuncionario { get; set; } = "ErroAoBuscarFuncionario";
        public static string ErroAoCadastrar { get; set; } = "ErroAoCadastrar";
        public static string ErroAoAtualizar { get; set; } = "ErroAoAtualizar";
    }
}
