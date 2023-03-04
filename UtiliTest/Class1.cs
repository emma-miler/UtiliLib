using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utili;
using Utili.Config;
using UtiliTest.Config;

namespace UtiliTest
{
    public class Test
    {
        public static void Main()
        {
            Utili.Utili.Initialize();
            var test = new ConfigTest();
        }
    }
}
