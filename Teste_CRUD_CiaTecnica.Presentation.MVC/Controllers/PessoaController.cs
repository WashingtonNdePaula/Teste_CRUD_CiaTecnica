using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using Teste_CRUD_CiaTecnica.Application.Interfaces;
using Teste_CRUD_CiaTecnica.Domain.Entities;

namespace Teste_CRUD_CiaTecnica.Presentation.MVC.Controllers
{
    public class PessoaController : ApiController
    {
        private readonly IPessoaAppService _pessoaService;
        public PessoaController(IPessoaAppService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public string Get()
        {
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            IEnumerable<Pessoa> lista= _pessoaService.GetAll();
            return JsonConvert.SerializeObject(lista, jss).Normalize();
        }

    }
}
