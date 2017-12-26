using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Teste_CRUD_CiaTecnica.Domain.Entities;

namespace Teste_CRUD_CiaTecnica.Infra.Data.EntityConfig
{
    class PessoaJuridicaConfiguration : EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaConfiguration()
        {
            HasKey(pj => pj.PessoaId);
            Property(pj => pj.NomeFantasia).IsRequired();
            Property(pj => pj.CNPJ).HasMaxLength(18).IsRequired();
            Property(pj => pj.CNPJ)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("UN_PessoaJuridica_CNPJ") { IsUnique = true }));
        }
    }
}
