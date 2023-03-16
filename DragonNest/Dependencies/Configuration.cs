using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace DragonNest.Dependencies
{
    class Configuration
    {
        public static void CreateIni()
        {
            try
            {
                var ini = new Ini(@"Config\\Settings.ini");

                ini.Write("HOST", "127.0.0.1");
                ini.Write("PORT", "1433");
                ini.Write("USERNAME", "sa");
                ini.Write("PASSWORD", "1234");
                ini.Write("DATABASE", "DNMembership");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please Read Logs for more Information", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                Logs.Write(ex.ToString(), 2);
            }

            Logs.Write("Successfully Created Configuration Settings", 1);
        }

        public static void ReadIni()
        {
            try
            {
                var ini = new Ini(@"Config\\Settings.ini");

                if (Tools.FExists(@"Config\\Settings.ini"))
                {
                    Database.Config.Host = ini.Read("HOST");
                    Database.Config.Port = Convert.ToInt32(ini.Read("PORT"));
                    Database.Config.Username = ini.Read("USERNAME");
                    Database.Config.Password = ini.Read("PASSWORD");
                    Database.Config.DatabaseName = ini.Read("DATABASE");
                }
                else
                {
                    MessageBox.Show("Please Read Logs for more Information", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Logs.Write("Directory doesn't Exists!", 2);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please Read Logs for more Information", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                Logs.Write(ex.ToString(), 2);
            }
        }
    }
}
