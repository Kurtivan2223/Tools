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
        public static bool Exists(string Path)
        {
            return Directory.Exists(Path) ? true : false;
        }
    }
}
