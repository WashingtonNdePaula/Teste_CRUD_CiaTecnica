using Teste_CRUD_CiaTecnica.Domain.Entities;

namespace Teste_CRUD_CiaTecnica.Application.Interfaces
{
    public interface IPessoaJuridicaAppService : IAppServiceBase<PessoaJuridica>
    {
        bool CNPJJaCadastrado(string cnpj, int id);
        bool IsCNPJ(string cnpj);
    }
}
