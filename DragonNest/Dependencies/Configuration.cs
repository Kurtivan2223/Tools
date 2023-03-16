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
        /*
            @Initialize with default
            @Create Ini file if doesnt exists
         */

        protected struct Default
        {
            public static string Host { get; set; }

            public static int Port { get; set; }

            public static string Username { get; set; }

            public static string Password { get; set; }

            public static string DatabaseName { get; set; }
        }

        

        public static void CreateIni()
        {
            try
            {
                if(!Tools.Exists(@"Config"))
                {
                    Directory.CreateDirectory("Config");
                }

                Default.Host = "127.0.0.1";

                Default.Port = 1433;

                Default.Username = "sa";

                Default.Password = "1234";

                Default.DatabaseName = "DNMembership";


                var ini = new Ini(@"Config\\Settings.ini");

                ini.Write("HOST", Default.Host);
                ini.Write("PORT", Default.Port.ToString());
                ini.Write("USERNAME", Default.Username);
                ini.Write("PASSWORD", Default.Password);
                ini.Write("DATABASE", Default.DatabaseName);
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

                //check if Directory Exists
                if (Tools.Exists(@"Config\\Settings.ini"))
                {
                    try
                    {
                        Database.Config.Host = ini.Read("HOST");
                        Database.Config.Port = Convert.ToInt32(ini.Read("PORT"));
                        Database.Config.Username = ini.Read("USERNAME");
                        Database.Config.Password = ini.Read("PASSWORD");
                        Database.Config.DatabaseName = ini.Read("DATABASE");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Please Read Logs for more Information", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                        Logs.Write(ex.ToString(), 2);
                    }
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
