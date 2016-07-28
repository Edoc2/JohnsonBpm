using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Framework.Dependency
{
    public interface IIocManager
    {
        IContainer IocContainer { get; }

        void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar);

        void AddAssemblyByConvention(Assembly assembly);

        void AddComponent<T>(string key = "", DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where T : class;

        void AddComponent(Type type, string key = "", DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        void AddComponent<TType, TImpl>(string key = "", DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType;

        void AddComponent(Type type, Type impl, string key = "", DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        T Resolve<T>(string key = "", ILifetimeScope scope = null);

        object Resolve(Type type, ILifetimeScope scope = null);

        bool IsRegistered(Type type, ILifetimeScope scope = null);

        bool IsRegistered<T>(ILifetimeScope scope = null);

        void UpdateContainer(Action<ContainerBuilder> action);
    }
}
