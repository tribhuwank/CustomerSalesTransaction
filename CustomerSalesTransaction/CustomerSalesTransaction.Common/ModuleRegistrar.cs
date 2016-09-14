using Microsoft.Practices.Unity;
using System;

namespace CustomerSalesTransaction.Common
{
    public class ModuleRegistrar:IModuleRegistrar
    {
        private readonly IUnityContainer _container;

        public  ModuleRegistrar(IUnityContainer container)
        {
            this._container = container; //Register interception behaviour if any
        }

        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            this._container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }


        public void RegisterType(Type type1, Type type2)
        {
            this._container.RegisterType(type1, type2, new ContainerControlledLifetimeManager());
        }


        public void RegisterType<T1>()
        {
            this._container.RegisterType(typeof(T1));
        }

        public void RegisterType<T1>(PerResolveLifetimeManager perResolveLifetimeManager)
        {
            this._container.RegisterType(typeof(T1), perResolveLifetimeManager);
        }

        public void RegisterType<T1, T2>(PerResolveLifetimeManager perResolveLifetimeManager)
        {
            this._container.RegisterType(typeof(T1),typeof(T2) ,perResolveLifetimeManager);
        }


        public void RegisterType<T1, T2>(InjectionFactory injectionFactory)
        {
            this._container.RegisterType(typeof(T1), typeof(T2), injectionFactory);
        }
    }
}
