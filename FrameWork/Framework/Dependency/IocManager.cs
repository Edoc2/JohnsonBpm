using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Framework.Dependency
{
    public class IocManager : BasicIocManager
    {
        public static IocManager Instance { get; private set; }
        static IocManager()
        {
            Instance = new IocManager();
        }
        private IocManager()
        {
            IocContainer = new ContainerBuilder().Build();

            UpdateContainer(builder =>
            {
                builder.RegisterInstance(this).As<IIocManager>().SingleInstance();
            });
        }

        public override ILifetimeScope Scope()
        {
            try
            {
                return IocContainer.BeginLifetimeScope(Constants.CNBLifetimeScope);
            }
            catch
            {
                return IocContainer;
            }
        }

    }
}
