using FrameWork.Framework.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Framework.Modules
{
   public abstract  class DemoModule
    {
        protected internal IIocManager IocManager { get; internal set; }

        public virtual void PreInitialize()
        {

        }

        public virtual void Initialize()
        {

        }


        public virtual void PostInitialize()
        {

        }

        public virtual void Shutdown()
        {

        }

        public static bool IsDemoModule(Type type)
        {
            return
                type.IsClass &&
                !type.IsAbstract &&
                typeof(DemoModule).IsAssignableFrom(type);
        }


        
    }
}
