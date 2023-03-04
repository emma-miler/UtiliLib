using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utili
{
    public class Utili
    {
        public static void Initialize()
        {
            if (!Directory.Exists(UtiliConfig.ConfigPath))
            {
                Directory.CreateDirectory(UtiliConfig.ConfigPath);
            }
        }
    }
}
