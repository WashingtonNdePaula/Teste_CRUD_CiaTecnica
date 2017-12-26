using System.Linq;
using Teste_CRUD_CiaTecnica.Application.Interfaces;
using Teste_CRUD_CiaTecnica.Domain.Entities;
using Teste_CRUD_CiaTecnica.Domain.Interfaces.Services;

namespace Teste_CRUD_CiaTecnica.Application
{
    public class PessoaJuridicaAppService : AppServiceBase<PessoaJuridica>, IPessoaJuridicaAppService
    {
        private readonly IPessoaJuridicaService _service;
        public PessoaJuridicaAppService(IPessoaJuridicaService service) : base(service)
        {
            _service = service;
        }
        public bool CNPJJaCadastrado(string cnpj, int id)
        {
            if (id > 0)
            {
                return _service.GetAll().Any(c => c.CNPJ == cnpj && c.PessoaId != id);
            }
            else
            {
                return _service.GetAll().Any(c => c.CNPJ == cnpj);
            }
        }

        public bool IsCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
