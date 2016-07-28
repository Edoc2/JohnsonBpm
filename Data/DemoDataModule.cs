using FrameWork.Framework.Infrastructure.Repository;
using FrameWork.Framework.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Data
{
    class DemoDataModule:DemoModule
    {
        public override void Initialize()
        {
            IocManager.AddAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.UpdateContainer(builder =>
            {
                builder.RegisterType<DemoDBEntities>();
                builder.RegisterGeneric(typeof(DemoRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            });
        }
    }
}
