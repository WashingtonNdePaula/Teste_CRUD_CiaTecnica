using Teste_CRUD_CiaTecnica.Domain.Entities;

namespace Teste_CRUD_CiaTecnica.Domain.Interfaces.Services
{
    public interface IPessoaFisicaService : IServiceBase<PessoaFisica>
    {
        bool CPFJaExiste(string cpf);
    }
}
