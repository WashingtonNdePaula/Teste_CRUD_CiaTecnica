namespace Teste_CRUD_CiaTecnica.Domain.Entities
{
    public class PessoaJuridica
    {
        public int PessoaId { get; set; }
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public virtual Pessoa Pessoa { get; set; }

    }
}
