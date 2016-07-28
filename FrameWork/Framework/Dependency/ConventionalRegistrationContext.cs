using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Framework.Dependency
{
    internal class ConventionalRegistrationContext : IConventionalRegistrationContext
    {
        public Assembly Assembly { get; private set; }

        public IIocManager IocManager { get; private set; }

        internal ConventionalRegistrationContext(Assembly assembly, IIocManager iocManager)
        {
            Assembly = assembly;
            IocManager = iocManager;
        }
    }
}
