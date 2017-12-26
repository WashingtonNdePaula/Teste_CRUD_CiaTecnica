using System.ComponentModel.DataAnnotations;
using Teste_CRUD_CiaTecnica.Presentation.MVC.Validations;

namespace Teste_CRUD_CiaTecnica.Presentation.MVC.ViewModels
{
    public class PessoaViewModel
    {
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [Display(Name = "Nome: ")]
        [MaxLength(80, ErrorMessage = "Nome deve conter no máximo 80 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Logradouro")]
        [Display(Name = "Logradouro: ")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o Número")]
        [Range(1,999999999,ErrorMessage = "Número deverá ser maior que zero")]
        [Display(Name = "Número: ")]
        public int Numero { get; set; }

        [Display(Name = "Complemento: ")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        [Display(Name = "Bairro: ")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a Cidade")]
        [Display(Name = "Cidade: ")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [Display(Name = "CEP: ")]
        [StringLength(9, ErrorMessage = "O CEP deve conter 8 dígitos", MinimumLength = 9)]
        public string CEP { get; set; }

        [Display(Name = "UF: ")]
        [Required(ErrorMessage = "Informe a UF")]
        [StringLength(2, ErrorMessage = "A UF deve conter 2 letras", MinimumLength = 2)]
        public string UF { get; set; }

        [Required]
        [Display(Name = "Tipo Pessoa: ")]
        public string TipoPessoa { get; set; }

        public PessoaJuridicaViewModel PessoaJuridica { get; set; }
        public PessoaFisicaViewModel PessoaFisica { get; set; }
        public PessoaViewModel()
        {
            PessoaFisica = new PessoaFisicaViewModel();
            PessoaJuridica = new PessoaJuridicaViewModel();
        }
    }
}