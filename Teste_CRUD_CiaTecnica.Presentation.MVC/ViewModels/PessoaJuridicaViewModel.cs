using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Teste_CRUD_CiaTecnica.Presentation.MVC.ViewModels
{
    public class PessoaJuridicaViewModel
    {
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ")]
        [Remote("ValidarCNPJ", "Validation", AdditionalFields = "PessoaId")]
        [Display(Name = "CNPJ: ")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Infome o Nome Fantasia")]
        [Display(Name = "Nome Fantasia: ")]
        [MaxLength(50, ErrorMessage = "Nome Fantasia deve conter no máximo 50 caracteres")]
        public string NomeFantasia { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }

    }
}