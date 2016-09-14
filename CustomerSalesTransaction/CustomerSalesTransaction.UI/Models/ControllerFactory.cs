using CustomerSalesTransaction.Common;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomerSalesTransaction.UI.Models
{
    public class ControllerFactory:DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                if (controllerType == null)
                    throw new ArgumentNullException("controllerType");

                if (!typeof(IController).IsAssignableFrom(controllerType))
                    throw new ArgumentException(string.Format(
                        "Type requested is not a controller: {0}",
                        controllerType.Name),
                        "controllerType");
                var rsUnit = MvcUnityContainer.Container.Resolve<IUnitOfWork>();
               return MvcUnityContainer.Container.Resolve(controllerType) as IController;
            }
            catch( Exception ex)
            {
                return null;
            }

        }
        public static class MvcUnityContainer
        {
            public static IUnityContainer Container { get; set; }
        }
    }
}