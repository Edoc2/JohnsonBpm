using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core.Configuration
{
    public class DemoConfiguration : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            var config = new DemoConfiguration();

            var cache = section.SelectSingleNode("Cache");
            if (cache != null && cache.Attributes != null)
            {
                config.CacheType = "REDIS";
                var attributeHost = cache.Attributes["Host"];
                if (attributeHost != null)
                    config.Host = attributeHost.Value;
                var attributePort = cache.Attributes["Port"];
                if (attributePort != null)
                    config.Port = attributePort.Value;
                var attributePassword = cache.Attributes["Password"];
                if (attributePassword != null)
                    config.Password = attributePassword.Value;
            }

            var dIEngine = section.SelectSingleNode("DIEngine");
            if (dIEngine != null && dIEngine.Attributes != null)
            {
                var attributeType = dIEngine.Attributes["Type"];
                if (attributeType != null)
                    config.DIEngineType = attributeType.Value;
            }

            var msmqs = section.SelectSingleNode("Msmqs");
            if (msmqs != null)
            {
                Dictionary<string, MsmqConfiguration> msmqDic = new Dictionary<string, MsmqConfiguration>();
                foreach (XmlNode childNode in msmqs.ChildNodes)
                {
                    if (childNode.Attributes["Name"] != null)
                    {
                        var key = childNode.Attributes["Name"].Value;
                        var path = childNode.Attributes["Path"];
                        if (path != null)
                        {
                            msmqDic.Add(key, new MsmqConfiguration(path.Value, key));
                        }
                    }
                }
                config.Msmqs = msmqDic;
            }

            var routers = section.SelectSingleNode("Routers");
            if (routers != null)
            {
                IList<RouterConfiguration> routerList = new List<RouterConfiguration>();
                foreach (XmlNode childNode in routers.ChildNodes)
                {
                    if (childNode.Attributes["Name"] != null &&
                        childNode.Attributes["Path"] != null &&
                        childNode.Attributes["Controller"] != null &&
                        childNode.Attributes["Action"] != null)
                    {
                        var name = childNode.Attributes["Name"].Value;
                        var path = childNode.Attributes["Path"].Value;
                        var controller = childNode.Attributes["Controller"].Value;
                        var action = childNode.Attributes["Action"].Value;
                        routerList.Add(new RouterConfiguration(name, path, controller, action));
                    }
                }
                config.Routers = routerList;
            }

            return config;
        }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Password { get; set; }
        public string CacheType { get; set; }
        public string DIEngineType { get; set; }
        public IDictionary<string, MsmqConfiguration> Msmqs { get; set; }
        public IList<RouterConfiguration> Routers { get; set; }
    }
}
