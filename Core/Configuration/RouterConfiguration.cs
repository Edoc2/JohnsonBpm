using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configuration
{
    public class RouterConfiguration
    {
        public RouterConfiguration(string name, string path, string controller, string action)
        {
            Name = name;
            Path = path;
            Controller = controller;
            Action = action;
        }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
