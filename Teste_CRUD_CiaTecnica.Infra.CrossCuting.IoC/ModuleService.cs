using Ninject.Modules;
using Teste_CRUD_CiaTecnica.Application;
using Teste_CRUD_CiaTecnica.Application.Interfaces;
using Teste_CRUD_CiaTecnica.Domain.Interfaces.Repositories;
using Teste_CRUD_CiaTecnica.Domain.Interfaces.Services;
using Teste_CRUD_CiaTecnica.Domain.Services;
using Teste_CRUD_CiaTecnica.Infra.Data.Repositories;

namespace Teste_CRUD_CiaTecnica.Infra.CrossCuting.IoC
{
    public class ModuleService : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<IPessoaRepository>().To<PessoaRepository>();
            Bind<IPessoaFisicaRepository>().To<PessoaFisicaRepository>();
            Bind<IPessoaJuridicaRepository>().To<PessoaJuridicaRepository>();

            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IPessoaService>().To<PessoaService>();
            Bind<IPessoaFisicaService>().To<PessoaFisicaService>();
            Bind<IPessoaJuridicaService>().To<PessoaJuridicaService>();

            Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            Bind<IPessoaAppService>().To<PessoaAppService>();
            Bind<IPessoaFisicaAppService>().To<PessoaFisicaAppService>();
            Bind<IPessoaJuridicaAppService>().To<PessoaJuridicaAppService>();

        }
    }
}
