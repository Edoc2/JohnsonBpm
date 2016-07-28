using Autofac;
using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Framework.Dependency
{
    public abstract class BasicIocManager : IIocManager
    {
        public IContainer IocContainer { get; protected set; }

        private readonly List<IConventionalDependencyRegistrar> _conventionalRegistrars;

        public BasicIocManager()
        {
            _conventionalRegistrars = new List<IConventionalDependencyRegistrar>();
        }

        public void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar)
        {
            _conventionalRegistrars.Add(registrar);
        }

        public void AddAssemblyByConvention(Assembly assembly)
        {
            var context = new ConventionalRegistrationContext(assembly, this);

            foreach (var registerer in _conventionalRegistrars)
            {
                registerer.RegisterAssembly(context);
            }
        }

        public void AddComponent<T>(string key = "", DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where T : class
        {
            AddComponent<T, T>(key, lifeStyle);
        }

        public void AddComponent(Type type, string key = "", DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            AddComponent(type, type, key, lifeStyle);
        }

        public void AddComponent<TType, TImpl>(string key = "", DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType
        {
            AddComponent(typeof(TType), typeof(TImpl), key, lifeStyle);
        }

        public void AddComponent(Type type, Type impl, string key = "", DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            UpdateContainer(x =>
            {
                var serviceTypes = new List<Type> { type };

                if (type.IsGenericType)
                {
                    var temp = x.RegisterGeneric(impl).As(
                        serviceTypes.ToArray()).PerLifeStyle(lifeStyle);
                    if (!string.IsNullOrEmpty(key))
                    {
                        temp.Keyed(key, impl);
                    }
                }
                else
                {
                    var temp = x.RegisterType(impl).As(
                        serviceTypes.ToArray()).PerLifeStyle(lifeStyle);
                    if (!string.IsNullOrEmpty(key))
                    {
                        temp.Keyed(key, type);
                    }
                }
            });
        }

        public void UpdateContainer(Action<ContainerBuilder> action)
        {
            var builder = new ContainerBuilder();
            action.Invoke(builder);
            builder.Update(IocContainer);
        }

        public bool IsRegistered(Type type, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                scope = Scope();
            }
            return scope.IsRegistered(type);
        }
        public bool IsRegistered<T>(ILifetimeScope scope = null)
        {
            return IsRegistered(typeof(T), scope);
        }

        public T Resolve<T>(string key = "", ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                scope = Scope();
            }
            if (string.IsNullOrEmpty(key))
            {
                return scope.Resolve<T>();
            }
            return scope.ResolveKeyed<T>(key);
        }

        public object Resolve(Type type, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                scope = Scope();
            }
            return scope.Resolve(type);
        }

        public abstract ILifetimeScope Scope();

    }

    public static class ContainerManagerExtensions
    {
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> PerLifeStyle<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder, DependencyLifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case DependencyLifeStyle.Transient:
                    return builder.InstancePerDependency();
                case DependencyLifeStyle.Singleton:
                    return builder.SingleInstance();
                default:
                    return builder.SingleInstance();
            }
        }
    }
}
