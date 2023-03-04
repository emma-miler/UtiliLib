using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utili
{
    public static class UtiliConfig
    {
        public static string LogPath { get; set; } = $@"{System.IO.Directory.GetCurrentDirectory()}\logs\";
        public static string ConfigPath { get; set; } = $@"{Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)}\utili\";
    }
}
