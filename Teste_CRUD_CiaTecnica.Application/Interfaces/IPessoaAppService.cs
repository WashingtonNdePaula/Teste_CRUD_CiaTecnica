using Teste_CRUD_CiaTecnica.Domain.Entities;

namespace Teste_CRUD_CiaTecnica.Application.Interfaces
{
    public interface IPessoaAppService : IAppServiceBase<Pessoa>
    {
        Pessoa LocalizarCEP(Pessoa pessoa);
    }
}
