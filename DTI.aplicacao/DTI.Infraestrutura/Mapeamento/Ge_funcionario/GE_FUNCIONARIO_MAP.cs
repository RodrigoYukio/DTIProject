using DTI.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using static DTI.Infraestrutura.Contexto.DTIContexto;

namespace DTI.Infraestrutura.Mapeamento
{
    public class GE_FUNCIONARIO_MAP : IEntityTypeConfiguration<GE_FUNCIONARIO>
    {
        public void Configure(EntityTypeBuilder<GE_FUNCIONARIO> builder)
        {
            builder.HasKey(e => new { e.SeqFuncionario });

            builder.Property(e => e.SeqFuncionario)
                .HasColumnName("seq_funcionario")
                .ValueGeneratedOnAdd()
                .HasValueGenerator((x, y) => new SequenceValueGenerator("seq_Funcionario"));

            builder.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");

            builder.Property(e => e.DtaNascimento)
                .HasColumnName("dtanasc");

            builder.Property(e => e.Endereco)
                .HasMaxLength(20)
                .HasColumnName("endereco");

            builder.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");

            builder.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");

            builder.Property(e => e.Cpf)
                .HasMaxLength(15)
                .HasColumnName("cpf");

            builder.Property(e => e.Setor)
                .HasMaxLength(1)
                .HasColumnName("setor");


            builder.Ignore(e => e.ResultadoValidacao);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("ge_funcionario");
        }
    }
}

