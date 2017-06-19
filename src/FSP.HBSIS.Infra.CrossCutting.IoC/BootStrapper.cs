using FSP.HBSIS.Application;
using FSP.HBSIS.Application.Interfaces;
using FSP.HBSIS.Domain.Interfaces.Repository;
using FSP.HBSIS.Domain.Interfaces.Services;
using FSP.HBSIS.Domain.Services;
using FSP.HBSIS.Infra.Data.Context;
using FSP.HBSIS.Infra.Data.Repository;
using FSP.HBSIS.Infra.Data.UoW;
using SimpleInjector;

namespace FSP.HBSIS.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // APP
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            // Data
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<HBSISContext>(Lifestyle.Scoped);
        }
    }
}