using CustomerService.Utils.Helpers;
using System.Web.Http;
using Teste_CRUD_CiaTecnica.Application;
using Teste_CRUD_CiaTecnica.Application.Interfaces;
using Teste_CRUD_CiaTecnica.Domain.Interfaces.Repositories;
using Teste_CRUD_CiaTecnica.Domain.Interfaces.Services;
using Teste_CRUD_CiaTecnica.Domain.Services;
using Teste_CRUD_CiaTecnica.Infra.Data.Repositories;
using Unity;
using Unity.Lifetime;

namespace Teste_CRUD_CiaTecnica.Presentation.MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // DI
            var container = new UnityContainer();
            container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaRepository, PessoaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaFisicaRepository, PessoaFisicaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaJuridicaRepository, PessoaJuridicaRepository>(new HierarchicalLifetimeManager());

            container.RegisterType(typeof(IServiceBase<>), typeof(ServiceBase<>), new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaService, PessoaService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaFisicaService, PessoaFisicaService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaJuridicaService, PessoaJuridicaService>(new HierarchicalLifetimeManager());

            container.RegisterType(typeof(IAppServiceBase<>), typeof(AppServiceBase<>), new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaAppService, PessoaAppService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaFisicaAppService, PessoaFisicaAppService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaJuridicaAppService, PessoaJuridicaAppService>(new HierarchicalLifetimeManager());

            
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}