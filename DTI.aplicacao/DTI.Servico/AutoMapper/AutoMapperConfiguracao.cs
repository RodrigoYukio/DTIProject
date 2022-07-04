using DTI.Servico.AutoMapper.SystemLinq;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTI.Servico.AutoMapper
{
    public static class AutoMapperConfiguracao
    {
        public static void AddAutoMapperTnf(this IServiceCollection services)
        {
            services.AddTnfAutoMapper(config =>
            {
                config.AddProfile<DTIProfile>();
                config.AddProfile<SystemLinqProfile>();

            });
        }
    }
}
