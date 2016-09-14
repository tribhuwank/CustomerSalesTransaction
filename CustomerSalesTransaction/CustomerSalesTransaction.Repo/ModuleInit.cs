using System.ComponentModel.Composition;
using Microsoft.Practices.Unity;
using CustomerSalesTransaction.Common;

namespace CustomerSalesTransaction.Repo
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar, IUnityContainer container)
        {

            registrar.RegisterType<SalesDBContext>(new PerResolveLifetimeManager());          
            registrar.RegisterType<IUnitOfWork, UnitOfWork>(new InjectionFactory((c => new UnitOfWork(container.Resolve<SalesDBContext>()))));     
        }
    }

}
