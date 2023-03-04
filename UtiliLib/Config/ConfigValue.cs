using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utili.Config
{
    public class ConfigValue
    {
        public string Value { get; set; }
        public string Name { get; set; }

        public ConfigValue(string value, string name) 
        {
            Value = value;
            Name = name;
        }
    }
}
