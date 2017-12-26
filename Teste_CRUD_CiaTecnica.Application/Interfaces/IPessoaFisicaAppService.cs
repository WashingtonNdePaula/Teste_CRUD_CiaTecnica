using Teste_CRUD_CiaTecnica.Domain.Entities;

namespace Teste_CRUD_CiaTecnica.Application.Interfaces
{
    public interface IPessoaFisicaAppService : IAppServiceBase<PessoaFisica>
    {
        bool CPFJaCadastrado(string cpf, int id);

        bool IsCPF(string cpf);
    }
}
