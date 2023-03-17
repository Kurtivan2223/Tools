using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Diagnostics;

namespace DragonNest.Dependencies
{
    class Configuration
    {
        public static void CreateIni()
        {
            try
            {
                var ini = new Ini(@"Config\\Settings.ini");

                ini.Write("HOST", "127.0.0.1", "DATABASE");
                ini.Write("PORT", "1433", "DATABASE");
                ini.Write("USERNAME", "sa", "DATABASE");
                ini.Write("PASSWORD", "1234", "DATABASE");
                ini.Write("DBName", "DNMembership", "DATABASE");
            }
            catch (Exception ex)
            {
                Logs.Write(ex.Message.ToString(), 2);
                Environment.Exit(-1);
            }
            Logs.Write("Successfully Created Configuration Settings", 1);
        }

        public static void ReadIni()
        {
            try
            {
                Tools.sw = Stopwatch.StartNew();

                var ini = new Ini(@"Config\\Settings.ini");

                Logs.Write("Loading up Configuration", 1);

                if (Tools.FExists(@"Config\\Settings.ini"))
                {
                    Database.Config.Host = ini.Read("HOST", "DATABASE");
                    Database.Config.Port = Convert.ToInt32(ini.Read("PORT", "DATABASE"));
                    Database.Config.Username = ini.Read("USERNAME", "DATABASE");
                    Database.Config.Password = ini.Read("PASSWORD", "DATABASE");
                    Database.Config.DatabaseName = ini.Read("DBName", "DATABASE");
                }
                else
                {
                    Logs.Write("Directory doesn't Exists!", 2);
                    Environment.Exit(-1);
                }
                Tools.sw.Stop();
                Logs.Write("Configuration Loaded at " + Tools.sw.ElapsedMilliseconds + "ms", 1);
            }
            catch(Exception ex)
            {
                Logs.Write(ex.Message.ToString(), 2);
                Environment.Exit(-1);
            }
        }
    }
}