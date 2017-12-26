using System.Linq;
using Teste_CRUD_CiaTecnica.Domain.Entities;
using Teste_CRUD_CiaTecnica.Domain.Interfaces.Repositories;
using Teste_CRUD_CiaTecnica.Domain.Interfaces.Services;

namespace Teste_CRUD_CiaTecnica.Domain.Services
{
    public class PessoaFisicaService : ServiceBase<PessoaFisica>, IPessoaFisicaService
    {
        private IPessoaFisicaRepository _repository;

        public PessoaFisicaService(IPessoaFisicaRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public bool CPFJaExiste(string cpf)
        {
            if (_repository.GetAll().Where(c => c.CPF == cpf).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
