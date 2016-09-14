using System;

namespace CustomerSalesTransaction.Common
{
    public interface IModuleRegistrar
    {
        void RegisterType<TFrom,TTo>() where TTo:TFrom;
        void RegisterType(Type type1, Type type2);

        void RegisterType<T1>();

        void RegisterType<T1>(Microsoft.Practices.Unity.PerResolveLifetimeManager perResolveLifetimeManager);

        void RegisterType<T1, T2>(Microsoft.Practices.Unity.PerResolveLifetimeManager perResolveLifetimeManager);

        void RegisterType<T1, T2>(Microsoft.Practices.Unity.InjectionFactory injectionFactory);
    }
}
