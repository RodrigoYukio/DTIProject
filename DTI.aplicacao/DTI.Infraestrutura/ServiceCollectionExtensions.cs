using DTI.Dominio.DTO.Interfaces;
using DTI.Dominio.Entidades.Repositorio;
using DTI.Infraestrutura.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTI.Infraestrutura
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services)
        {
            services.AddTransient<IGeFuncionarioRepositorio, Ge_FuncionarioRepositorio>();
            services.AddTransient<IGeFuncionarioLeituraRepositorio, Ge_FuncionarioLeituraRepositorio>();
            return services;
        }
    }
}
