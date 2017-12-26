using System.Linq;
using Teste_CRUD_CiaTecnica.Domain.Entities;
using Teste_CRUD_CiaTecnica.Domain.Interfaces.Repositories;
using Teste_CRUD_CiaTecnica.Domain.Interfaces.Services;

namespace Teste_CRUD_CiaTecnica.Domain.Services
{
    public class PessoaJuridicaService : ServiceBase<PessoaJuridica>, IPessoaJuridicaService
    {
        private IPessoaJuridicaRepository _repository;

        public PessoaJuridicaService(IPessoaJuridicaRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public bool CNPJJaExiste(string cnpj)
        {
            if (_repository.GetAll().Where(c => c.CNPJ == cnpj).FirstOrDefault() != null)
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
