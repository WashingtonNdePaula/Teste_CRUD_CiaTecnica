using Teste_CRUD_CiaTecnica.Domain.Entities;

namespace Teste_CRUD_CiaTecnica.Domain.Interfaces.Services
{
    public interface IPessoaJuridicaService : IServiceBase<PessoaJuridica>
    {
        bool CNPJJaExiste(string cnpj);
    }
}
