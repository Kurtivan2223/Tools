using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DragonNest.Dependencies
{
    class Tools
    {
        public static bool DExists(string Path)
        {
            return Directory.Exists(Path) ? true : false;
        }

        public static bool FExists(string file)
        {
            return File.Exists(file) ? true : false;
        }
    }
}
