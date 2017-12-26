using Teste_CRUD_CiaTecnica.Application.Interfaces;
using Teste_CRUD_CiaTecnica.Domain.Entities;
using Teste_CRUD_CiaTecnica.Domain.Interfaces.Services;

namespace Teste_CRUD_CiaTecnica.Application
{
    public class PessoaAppService : AppServiceBase<Pessoa>, IPessoaAppService
    {
        private readonly IPessoaService _service;
        public PessoaAppService(IPessoaService service) : base(service)
        {
            _service = service;
        }
        public Pessoa LocalizarCEP(Pessoa pessoa)
        {
            var service = new br.com.correios.apps.AtendeClienteService();
            var endereco = service.consultaCEP(pessoa.CEP);
            pessoa.Logradouro = endereco.end;
            pessoa.Bairro = endereco.bairro;
            pessoa.Cidade = endereco.cidade;
            pessoa.UF = endereco.uf;
            return pessoa;
        }
    }
}
