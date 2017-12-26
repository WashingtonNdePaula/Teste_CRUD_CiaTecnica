using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Teste_CRUD_CiaTecnica.Domain.Entities;

namespace Teste_CRUD_CiaTecnica.Infra.Data.EntityConfig
{
    public class PessoaFisicaConfiguration : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaConfiguration()
        {
            HasKey(pf => pf.PessoaId);
            Property(pf => pf.CPF).HasMaxLength(14).IsRequired();
            Property(pf => pf.Sobrenome).HasMaxLength(15).IsRequired();
            Property(pf => pf.CPF)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("UN_PessoaFisica_CPF") { IsUnique = true }));
        }
    }
}
