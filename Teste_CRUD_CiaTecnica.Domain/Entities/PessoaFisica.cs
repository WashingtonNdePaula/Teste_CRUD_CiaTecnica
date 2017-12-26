using System;

namespace Teste_CRUD_CiaTecnica.Domain.Entities
{
    public class PessoaFisica
    {
        public int PessoaId { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sobrenome { get; set; }
        public virtual Pessoa Pessoa { get; set; }

    }
}
