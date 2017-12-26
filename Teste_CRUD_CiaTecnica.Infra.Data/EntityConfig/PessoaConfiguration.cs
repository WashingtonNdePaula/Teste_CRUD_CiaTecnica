using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Teste_CRUD_CiaTecnica.Domain.Entities;

namespace Teste_CRUD_CiaTecnica.Infra.Data.EntityConfig
{
    public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguration()
        {
            HasKey(c => c.PessoaId);
            Property(c => c.PessoaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasOptional(c => c.PessoaFisica)
                .WithRequired(pf => pf.Pessoa);
            HasOptional(pj => pj.PessoaJuridica)
                .WithRequired(pj => pj.Pessoa);
            Property(pf => pf.Nome).IsRequired();
            Property(c => c.Logradouro).IsRequired();
            Property(c => c.Cidade).IsRequired();
            Property(c => c.Complemento).HasMaxLength(50).IsOptional();
            Property(c => c.Bairro).IsRequired();
            Property(c => c.UF).HasMaxLength(2).IsRequired();
            Property(c => c.TipoPessoa).HasMaxLength(8).IsRequired();
            Property(c => c.CEP).HasMaxLength(8).IsRequired();
        }
    }
}
