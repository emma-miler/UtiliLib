using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Utili;

namespace Utili.Config
{
    public static class ConfigurationManager
    {

        public static Dictionary<string, ConfigSection> Sections { get; set; } = new Dictionary<string, ConfigSection>();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Load(object obj)
        {
            StackFrame frame = new StackFrame(1);
            var method = frame.GetMethod();
            var type = method.DeclaringType;
            List<PropertyInfo> props = type.GetProperties().Where(x => Attribute.IsDefined(x, typeof(ConfigItem))).ToList();

            ConfigSection? currentSection = null;
            if (!ConfigurationManager.Sections.TryGetValue(type.Name, out currentSection))
            {
                currentSection = new ConfigSection(type.Name);
                Sections.Add(type.Name, currentSection);
            }
            
            foreach (PropertyInfo prop in props)
            {
                Log.Info(prop);
            }
            
            IniParser.ParseFile($@"{UtiliConfig.ConfigPath}\test.ini");

            foreach (PropertyInfo prop in props)
            {
                if (currentSection.Items.ContainsKey(prop.Name) && currentSection.Items[prop.Name] != null) 
                {
                    ConfigItem attr = prop.GetCustomAttribute<ConfigItem>();
                    object value = attr.DeserializeValue(currentSection.Items[prop.Name].Value, prop.PropertyType);
                    var args = new List<object>() { value }.ToArray();
                    var setMethod = prop.GetSetMethod();
                    setMethod.Invoke(obj, args );
                }
            }
        }
    }
}
