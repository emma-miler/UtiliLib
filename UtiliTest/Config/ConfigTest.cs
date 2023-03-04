using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utili;
using Utili.Config;

namespace UtiliTest.Config
{
    public class ConfigTest
    {
        [ConfigItem]
        public string test { get; set; } = "abc";

        [EncryptedConfigItem]
        public string Password { get; set; } = "abc";

        public ConfigTest() 
        {
            ConfigurationManager.Load(this);
            Log.Info(test);
        }
    }
}
