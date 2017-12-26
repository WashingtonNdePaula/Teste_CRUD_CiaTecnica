using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Teste_CRUD_CiaTecnica.Application.Interfaces;
using Teste_CRUD_CiaTecnica.Domain.Entities;
using Teste_CRUD_CiaTecnica.Presentation.MVC.ViewModels;

namespace Teste_CRUD_CiaTecnica.Presentation.MVC.Controllers
{
    public class ClienteController : Controller
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
        public ClienteController()
        {

        }

        // GET: Cliente
        public ActionResult Index()
        {
            var model = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(_pessoaService.GetAll());
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new ClienteViewModel();
            model.ClienteTipoPessoa = "Física";
            return View(model);
        }

        public ActionResult Create1()
        {
            var model = new ClienteViewModel();
            model.ClienteTipoPessoa = "Física";
            return View(model);
        }

        public ActionResult CreatePF()
        {
            var model = new ClienteViewModel();
            model.ClienteTipoPessoa = "Física";
            return View("Create", model);
            //return PartialView("_PessoaFisica", model);
        }

        public ActionResult CreatePJ()
        {
            var model = new ClienteViewModel();
            model.ClienteTipoPessoa = "Jurídica";
            return View("Create", model);
            //return PartialView("_PessoaJuridica",model);
        }

        public ActionResult Edit(int id)
        {
            var model = new ClienteViewModel();
            model.Pessoa = Mapper.Map<Pessoa, PessoaViewModel>(_pessoaService.GetById(id));
            model.ClienteTipoPessoa = model.Pessoa.TipoPessoa;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel model)
        {
            var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(model.Pessoa);
            pessoa.CEP = pessoa.CEP.Replace("-", "");
            if (ModelState.IsValid)
            {
                try
                {
                    if (pessoa.TipoPessoa == "Física")
                    {
                        pessoa.PessoaJuridica = null;
                        var pessoaF = Mapper.Map<PessoaFisicaViewModel, PessoaFisica>(model.Pessoa.PessoaFisica);
                        _pessoaFisicaService.Update(pessoaF);
                    }
                    if (pessoa.TipoPessoa == "Jurídica")
                    {
                        pessoa.PessoaFisica = null;
                        var pessoaJ = Mapper.Map<PessoaJuridicaViewModel, PessoaJuridica>(model.Pessoa.PessoaJuridica);
                        _pessoaJuridicaService.Update(pessoaJ);
                    }
                    _pessoaService.Update(pessoa);
                    return RedirectToAction("Index").Mensagem("Cliente alterado com sucesso!", "Editar Cliente");
                }
                catch(Exception e)
                {
                    return View(model).Mensagem(e.Message, "ERRO:");
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel model)
        {
            var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(model.Pessoa);
            pessoa.CEP = pessoa.CEP.Replace("-", "");
            if (pessoa.TipoPessoa == "Física")
            {
                pessoa.PessoaJuridica = null;
            }
            if (pessoa.TipoPessoa == "Jurídica")
            {
                pessoa.PessoaFisica = null;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _pessoaService.Add(pessoa);
                    return RedirectToAction("Index").Mensagem("Cliente criado com sucesso!", "Criar Cliente");
                }
                catch (Exception e)
                {
                    return View(model).Mensagem(e.Message, "ERRO:");
                }
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Details(int id)
        {
            var pessoa = _pessoaService.GetById(id);
            if (pessoa.TipoPessoa == "Física")
            {
                var model = Mapper.Map<PessoaFisica, PessoaFisicaViewModel>(_pessoaFisicaService.GetById(id));
                return View("DetailsPF", model);
            }
            else
            {
                var model = Mapper.Map<PessoaJuridica, PessoaJuridicaViewModel>(_pessoaJuridicaService.GetById(id));
                return View("DetailsPJ", model);
            }
        }

        public ActionResult Delete(int id)
        {
            var pessoa = _pessoaService.GetById(id);
            if (pessoa.TipoPessoa == "Física")
            {
                var model = Mapper.Map<PessoaFisica, PessoaFisicaViewModel>(_pessoaFisicaService.GetById(id));
                return View("DeletePF", model);
            }
            else
            {
                var model = Mapper.Map<PessoaJuridica, PessoaJuridicaViewModel>(_pessoaJuridicaService.GetById(id));
                return View("DeletePJ", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection form)
        {
            int id = int.Parse(form["PessoaId"].ToString());
            string tipo = form["Pessoa.TipoPessoa"].ToString();
            var pessoa = _pessoaService.GetById(id);
            try
            {
                if (tipo == "Física")
                {
                    var pessoaPF = _pessoaFisicaService.GetById(id);
                    _pessoaFisicaService.Remove(pessoaPF);
                }
                else
                {
                    var pessoaPJ = _pessoaJuridicaService.GetById(id);
                    _pessoaJuridicaService.Remove(pessoaPJ);
                }
                _pessoaService.Remove(pessoa);
                return RedirectToAction("Index").Mensagem("Cliente excluído com sucesso!", "Excluir Cliente");
            }
            catch (Exception e)
            {
                return RedirectToAction("Delete",routeValues: new { id = id.ToString()}).Mensagem(e.Message, "ERRO:");
            }
        }

        public ActionResult ConsultaCEP(string cep)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.CEP = cep;
            try
            {
                pessoa = _pessoaService.LocalizarCEP(pessoa);
            }
            catch
            {
                ModelState.AddModelError("CEP", "CEP Não Encontrado");
                return Json(pessoa, JsonRequestBehavior.AllowGet);
            }
            return Json(pessoa, JsonRequestBehavior.AllowGet);
        }
    }
}