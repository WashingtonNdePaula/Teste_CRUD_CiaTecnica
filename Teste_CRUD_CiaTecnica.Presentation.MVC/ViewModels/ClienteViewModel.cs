using System.ComponentModel.DataAnnotations;

namespace Teste_CRUD_CiaTecnica.Presentation.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Required]
        [Display(Name = "Tipo Pessoa: ")]
        public string ClienteTipoPessoa { get; set; }

        public PessoaViewModel Pessoa { get; set; }
        public ClienteViewModel()
        {
            Pessoa = new PessoaViewModel();
        }
    }
}