using AutoMapper;
using Teste_CRUD_CiaTecnica.Domain.Entities;
using Teste_CRUD_CiaTecnica.Presentation.MVC.ViewModels;

namespace Teste_CRUD_CiaTecnica.Presentation.MVC.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Pessoa, PessoaViewModel>();
                x.CreateMap<PessoaFisica, PessoaFisicaViewModel>();
                x.CreateMap<PessoaJuridica, PessoaJuridicaViewModel>();

                x.CreateMap<PessoaViewModel, Pessoa>();
                x.CreateMap<PessoaFisica, PessoaFisicaViewModel>();
                x.CreateMap<PessoaJuridicaViewModel, PessoaJuridica>();
            });
        }
    }
}