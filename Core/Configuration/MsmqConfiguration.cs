using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configuration
{
    public class MsmqConfiguration
    {
        public MsmqConfiguration(string path, string name)
        {
            Name = name;
            Path = path;
        }
        public string Path { get; set; }
        public string Name { get; set; }
    }
}
