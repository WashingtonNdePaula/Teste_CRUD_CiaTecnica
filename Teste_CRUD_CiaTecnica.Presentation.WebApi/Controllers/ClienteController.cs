using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teste_CRUD_CiaTecnica.Application.Interfaces;
using Teste_CRUD_CiaTecnica.Domain.Entities;

namespace Teste_CRUD_CiaTecnica.Presentation.WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly IPessoaAppService _pessoaService;
        private readonly IPessoaFisicaAppService _pessoaFisicaService;
        private readonly IPessoaJuridicaAppService _pessoaJuridicaService;
        public ClienteController(IPessoaAppService pessoaService, IPessoaFisicaAppService pessoaFisicaService, IPessoaJuridicaAppService pessoaJuridicaService)
        {
            _pessoaService = pessoaService;
            _pessoaFisicaService = pessoaFisicaService;
            _pessoaJuridicaService = pessoaJuridicaService;
        }

        // GET: api/Cliente
        public IEnumerable<string> Get()
        {
            IEnumerable<PessoaFisica> listaPF = _pessoaFisicaService.GetAll();
            IEnumerable<PessoaJuridica> listaPJ = _pessoaJuridicaService.GetAll();
            var pf = JsonConvert.SerializeObject(listaPF);
            var pj = JsonConvert.SerializeObject(listaPJ);
            var json = new string[] { "value1", "value2" };
            return json;
        }

        // GET: api/Cliente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cliente
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
