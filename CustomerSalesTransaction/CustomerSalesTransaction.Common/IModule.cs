using Microsoft.Practices.Unity;

namespace CustomerSalesTransaction.Common
{
    public interface IModule
    {
        void Initialize(IModuleRegistrar registrar, IUnityContainer container);
    }
}
