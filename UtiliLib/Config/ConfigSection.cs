using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utili.Config
{
    public class ConfigSection
    {
        public string Name { get; set; }
        public Dictionary<string, ConfigValue> Items { get; set; }

        public ConfigSection(string name, Dictionary<string, ConfigValue> items = null!) 
        {
            Name = name;
            Items = items ?? new Dictionary<string, ConfigValue>();
        }
    }
}
