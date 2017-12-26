using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Teste_CRUD_CiaTecnica.Presentation.MVC.Validations;

namespace Teste_CRUD_CiaTecnica.Presentation.MVC.ViewModels
{
    public class PessoaFisicaViewModel
    {
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Informe o CPF")]
        [Remote("ValidarCPF", "Validation", AdditionalFields = "PessoaId")]
        [Display(Name = "CPF: ")]
        public string CPF { get; set; }

        [Display(Name = "Data de Nascimento: ")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataBrasil(DataRequerida = true, ErrorMessage = "Data Inválida")]
        [IdadeMinima(Idade = 19, ErrorMessage = "Idade mínima de 19 anos")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o Sobrenome")]
        [Display(Name = "Sobrenome: ")]
        [MaxLength(15, ErrorMessage = "Sobrenome deve conter no máximo 15 caracteres")]
        public string Sobrenome { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
    }
}