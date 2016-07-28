using FrameWork.Framework.DI.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Framework.DI
{
    public interface IEngine
    {
        ContainerManager ContainerManager
        {
            get;
        }

        void Initialize();

        T Resolve<T>() where T : class;

        object Resolve(Type type);

        T[] ResolveAll<T>();
    }
}
