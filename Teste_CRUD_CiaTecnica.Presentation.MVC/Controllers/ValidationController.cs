using System;
using System.Web.Mvc;
using Teste_CRUD_CiaTecnica.Application.Interfaces;

namespace Teste_CRUD_CiaTecnica.Presentation.MVC.Controllers
{
    public class ValidationController : Controller
    {

        private readonly IPessoaFisicaAppService _pessoaFisicaService;
        private readonly IPessoaJuridicaAppService _pessoaJuridicaService;
        private readonly IPessoaAppService _clienteService;

        public ValidationController(IPessoaFisicaAppService pessoaFisicaService, IPessoaJuridicaAppService pessoaJuridicaService, IPessoaAppService clienteService)
        {
            _pessoaFisicaService = pessoaFisicaService;
            _pessoaJuridicaService = pessoaJuridicaService;
            _clienteService = clienteService;
        }

        public JsonResult ValidarCNPJ(
            [Bind(Prefix = "Pessoa.PessoaJuridica.CNPJ")] string CNPJ,
            [Bind(Prefix = "Pessoa.PessoaJuridica.PessoaId")] int PessoaId)
        {
            bool cnpjExiste = false;
            try
            {
                cnpjExiste = _pessoaJuridicaService.CNPJJaCadastrado(CNPJ, PessoaId) ? true : false;
                if (!_pessoaJuridicaService.IsCNPJ(CNPJ))
                {
                    return Json("CNPJ inválido", JsonRequestBehavior.AllowGet);
                }
                if (cnpjExiste)
                {
                    return Json("CNPJ já cadastrado", JsonRequestBehavior.AllowGet);
                }
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ValidarCPF(
            [Bind(Prefix = "Pessoa.PessoaFisica.CPF")] string CPF,
            [Bind(Prefix = "Pessoa.PessoaFisica.PessoaId")] int PessoaId
            )
        {
            bool cpfExiste = false;
            try
            {
                cpfExiste = _pessoaFisicaService.CPFJaCadastrado(CPF, PessoaId) ? true : false;
                if (!_pessoaFisicaService.IsCPF(CPF))
                {
                    return Json("CPF inválido", JsonRequestBehavior.AllowGet);
                }
                if (cpfExiste)
                {
                    return Json("CPF já cadastrado", JsonRequestBehavior.AllowGet);
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}