using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Tnf.Notifications;

namespace DTI.Servico.Servicos.Ge_CadastroFuncionario.Validacoes
{
    public class ValidacaoGe_Funcionario
    {
        private readonly INotificationHandler _controleNotificacao;
        public ValidacaoGe_Funcionario(INotificationHandler controleNotificacao)
        {
            _controleNotificacao = controleNotificacao;
        }

        public bool ValidaEmail(string email)
        {
            if (email.Length > 30)
            {
                return true;
            }

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!rg.IsMatch(email))
            {
                return true;
            }

            return false;
        }
    }
}
