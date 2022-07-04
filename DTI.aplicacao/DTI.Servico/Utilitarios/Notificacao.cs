using DTI.Dominio.Localizacao;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Notifications;

namespace DTI.Servico.Utilitarios
{
    public static class Notificacao
    {
        public static void AdicionarNotificacao(INotificationHandler controleNotificacao, string identificadorNotificacao)
        {
            controleNotificacao.Raise(
                controleNotificacao.DefaultBuilder
                    .WithCode("400")
                    .WithBadRequestStatus()
                    .WithMessage(LocalizacaoCaminho.MensagensErro, (LocalizacaoChaves.MensagensErro)Enum.Parse(typeof(LocalizacaoChaves.MensagensErro), identificadorNotificacao))
                    .WithDetailedMessage(LocalizacaoCaminho.MensagensErro, (LocalizacaoChaves.MensagensErro)Enum.Parse(typeof(LocalizacaoChaves.MensagensErro), identificadorNotificacao))
                    .AsError()
                    .Build());
        }
    }
}
