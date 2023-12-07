using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Unieja.Api.Models
{
    public partial class UniejaContext : DbContext
    {
        public UniejaContext()
        {
        }

        public UniejaContext(DbContextOptions<UniejaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Faleconosco> Faleconoscos { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=177.11.50.178;database=unieja_api;uid=unieja_api;pwd=kE@laqJLl#1DM", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.20-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Faleconosco>(entity =>
            {
                entity.ToTable("faleconosco");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Assunto)
                    .HasMaxLength(200)
                    .HasColumnName("assunto");

                entity.Property(e => e.Celular)
                    .HasMaxLength(30)
                    .HasColumnName("celular");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(200)
                    .HasColumnName("cidade");

                entity.Property(e => e.Datacadastro)
                    .HasColumnType("timestamp")
                    .HasColumnName("datacadastro")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .HasColumnName("email");

                entity.Property(e => e.Estado)
                    .HasMaxLength(200)
                    .HasColumnName("estado");

                entity.Property(e => e.Mensagem).HasColumnName("mensagem");

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .HasColumnName("nome");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(30)
                    .HasColumnName("telefone");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.ToTable("matriculas");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Agenciadorpolo)
                    .HasMaxLength(200)
                    .HasColumnName("agenciadorpolo");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(200)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cep)
                    .HasMaxLength(30)
                    .HasColumnName("cep");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(200)
                    .HasColumnName("cidade");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(200)
                    .HasColumnName("complemento");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(30)
                    .HasColumnName("cpf");

                entity.Property(e => e.Cpfresponsavel)
                    .HasMaxLength(30)
                    .HasColumnName("cpfresponsavel");

                entity.Property(e => e.Curso)
                    .HasMaxLength(200)
                    .HasColumnName("curso");

                entity.Property(e => e.Datacadastro)
                    .HasColumnType("timestamp")
                    .HasColumnName("datacadastro")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Datanascimento)
                    .HasMaxLength(30)
                    .HasColumnName("datanascimento");

                entity.Property(e => e.Datapagamento)
                    .HasMaxLength(30)
                    .HasColumnName("datapagamento");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .HasColumnName("email");

                entity.Property(e => e.Emailresponsavel)
                    .HasMaxLength(200)
                    .HasColumnName("emailresponsavel");

                entity.Property(e => e.Estado)
                    .HasMaxLength(200)
                    .HasColumnName("estado");

                entity.Property(e => e.Formainvestimento)
                    .HasMaxLength(200)
                    .HasColumnName("formainvestimento");

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(200)
                    .HasColumnName("logradouro");

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .HasColumnName("nome");

                entity.Property(e => e.Nomemae)
                    .HasMaxLength(200)
                    .HasColumnName("nomemae");

                entity.Property(e => e.Nomeresponsavel)
                    .HasMaxLength(200)
                    .HasColumnName("nomeresponsavel");

                entity.Property(e => e.Rg)
                    .HasMaxLength(30)
                    .HasColumnName("rg");

                entity.Property(e => e.Telefoneresponsavel)
                    .HasMaxLength(30)
                    .HasColumnName("telefoneresponsavel");

                entity.Property(e => e.Whatsapp)
                    .HasMaxLength(30)
                    .HasColumnName("whatsapp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
