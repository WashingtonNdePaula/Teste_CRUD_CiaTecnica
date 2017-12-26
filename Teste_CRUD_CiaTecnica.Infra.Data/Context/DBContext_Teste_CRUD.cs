using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using Teste_CRUD_CiaTecnica.Domain.Entities;
using Teste_CRUD_CiaTecnica.Infra.Data.EntityConfig;

namespace Teste_CRUD_CiaTecnica.Infra.Data.Context
{
    public class DBContext_Teste_CRUD : DbContext, IDisposable
    {
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }

        public DBContext_Teste_CRUD()
            :base("OracleDbContext") //DB_Teste_CRUD
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SYSTEM");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new PessoaConfiguration());
            modelBuilder.Configurations.Add(new PessoaFisicaConfiguration());
            modelBuilder.Configurations.Add(new PessoaJuridicaConfiguration());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar2"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var erro = "Entidade do tipo {0} em estado de {1} possui os seguintes erros de validação: ";
                foreach (var eve in e.EntityValidationErrors)
                {
                    erro = String.Format(erro, eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        erro += String.Format("Propriedade: {0} - Erro: {1}", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(erro);
            }
        }
    }
}
