using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTI.Servico.Servicos
{
    public static class ServicosConfiguracao
    {
        public static void AddServicosConfiguracao(this IServiceCollection services)
        {
            services.AddTransient<IGe_FuncionarioServico, Ge_FuncionarioServico>();
        }
    }                           
}
