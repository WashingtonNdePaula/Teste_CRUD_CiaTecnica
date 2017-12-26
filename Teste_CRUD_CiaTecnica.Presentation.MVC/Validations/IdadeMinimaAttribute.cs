using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Teste_CRUD_CiaTecnica.Presentation.MVC.Validations
{
    public class IdadeMinimaAttribute : ValidationAttribute, IClientValidatable
    {
        public int Idade { get; set; }
        public IdadeMinimaAttribute()
        {
            this.ErrorMessage = "Idade mínima.";
            this.Idade = 9999;
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            // Verifica se valor é nulo
            if (value == null)
            {
                value = "";
            }

            // Tenta converter o valor para DateTime, caso não seja possível retorna com erro.
            try
            {
                DateTime new_value = Convert.ToDateTime(value.ToString());
                TimeSpan tempoCalculado = DateTime.Now.Subtract(new_value);
                DateTime dataCalculada = new DateTime(tempoCalculado.Ticks);
                if (dataCalculada.Year < Idade)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
            }
            catch
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            // Retorna com sucesso após a conversão;
            return ValidationResult.Success;
        }

        // Diretivas para validação do lado do Cliente, implementação com jquery.validate
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata,
            ControllerContext context)
        {
            var Rule = new ModelClientValidationRule
            {
                ValidationType = "idademinima",
                ErrorMessage = this.FormatErrorMessage(metadata.PropertyName)

            };

            Rule.ValidationParameters["idade"] = Idade;
            yield return Rule;
        }
    }
}