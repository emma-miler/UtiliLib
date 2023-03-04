using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Utili.Config
{
    public static class IniParser
    {
        private static Regex SectionRegex = new Regex(@"\[(.*)\]");
        private static Regex ValueRegex = new Regex(@"([^\s]*)\s*=\s*(.*)");
        public static void ParseFile(string filename)
        {
            try
            {
                ConfigSection? currentSection = null;
                int i = 0;
                foreach (string line in File.ReadAllLines(filename))
                {
                    i++;
                    if (line == "" || line.StartsWith("#")) continue;

                    if (line.StartsWith("["))
                    {
                        // Section name
                        string sectionName = SectionRegex.Match(line).Groups.Values.ToList()[1].Value;
                        if (!ConfigurationManager.Sections.TryGetValue(sectionName, out currentSection))
                        {
                            currentSection = new ConfigSection(sectionName);
                            ConfigurationManager.Sections.Add(sectionName, currentSection);
                        }
                    }
                    else 
                    {
                        List<Group> values = ValueRegex.Match(line).Groups.Values.ToList();
                        if (values.Count < 3)
                            throw new FormatException($"Failed to parse value '{line}' on line {i}");
                        string name = values[1].Value;
                        string value = values[2].Value;
                        if (!currentSection.Items.ContainsKey(name))
                            currentSection.Items.Add(name, new ConfigValue(value, name));
                        else
                            Log.Warning($"Found existing value '{name}'. Not overwriting it!");
                            //currentSection.Items[name].Value = value;
                    }
                }
            }
            catch(FormatException e) 
            {
                throw new FormatException($"Failed to parse configuration file '{filename}. See error below for more information:\n{e}'");
            }
        }
    }
}
