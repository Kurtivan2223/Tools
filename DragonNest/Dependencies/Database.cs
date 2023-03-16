using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DragonNest.Dependencies
{
    class Database
    {
        public struct Config
        {
            public static string Host { get; set; }

            public static int Port { get; set; }

            public static string Username { get; set; }

            public static string Password { get; set; }

            public static string DatabaseName { get; set; }
        }

        protected static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        public static void Build()
        {
            Configuration.ReadIni();

            try
            {
                builder.DataSource = Config.Host + "," + Config.Port;
                builder.InitialCatalog = Config.DatabaseName;
                builder.UserID = Config.Username;
                builder.Password = Config.Password;
                builder.Pooling = true;

                Logs.Write("Building Connection String", 1);
                Logs.Write(builder.ConnectionString, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Read Logs for more Information", "Notice!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Logs.Write(ex.ToString(), 2);
            }
        }

        public static void init()
        {
            
        }
    }
}
