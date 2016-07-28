using Core.Configuration;
using FrameWork.Framework.DI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DemoDIEngineContext
    {
        protected static IEngine CreateEngineInstance()
        {
            var config = ConfigurationManager.GetSection("demoConfig") as DemoConfiguration;
            var engineType = Type.GetType(config.DIEngineType);
            if (engineType == null)
                throw new ConfigurationErrorsException("无法找到 '" + engineType + "'，请检查配置项CNBConfig。");
            if (!typeof(IEngine).IsAssignableFrom(engineType))
                throw new ConfigurationErrorsException("配置项没有实现IEngine接口。");
            return Activator.CreateInstance(engineType) as IEngine;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize()
        {
            if (Singleton<IEngine>.Instance == null)
            {
                Singleton<IEngine>.Instance = CreateEngineInstance();
                Singleton<IEngine>.Instance.Initialize();
            }
            return Singleton<IEngine>.Instance;
        }

        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Initialize();
                }
                return Singleton<IEngine>.Instance;
            }
        }
    }
}
