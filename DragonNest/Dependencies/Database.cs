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
using System.Diagnostics;

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

        public static SqlConnection Connection = new SqlConnection(builder.ConnectionString);

        public static void Build()
        {
            Configuration.ReadIni();
            Tools.sw = Stopwatch.StartNew();

            try
            {
                builder.DataSource = Config.Host + "," + Config.Port;
                builder.InitialCatalog = Config.DatabaseName;
                builder.UserID = Config.Username;
                builder.Password = Config.Password;
                builder.Pooling = true;

                Logs.Write("Building Connection String", 1);
                Logs.Write(builder.ConnectionString, 1);

                Tools.sw.Stop();

                Logs.Write("Done Constructing Connection String at " + Tools.sw.ElapsedMilliseconds + "ms", 1);
            }
            catch (Exception ex)
            {
                Logs.Write(ex.Message.ToString(), 2);
                Environment.Exit(-1);
            }
        }

        public static void Connect()
        {
            Logs.Write("Connecting to Database...", 1);

            Tools.sw = Stopwatch.StartNew();

            try
            {
                if(Connection.State == ConnectionState.Open)
                    Connection.Open();
                Logs.Write("Starting Pooling.....", 1);
                Logs.Write("Connected to the Database at " + Tools.sw.ElapsedMilliseconds + "ms", 1);
            }
            catch(Exception ex)
            {
                Logs.Write(ex.Message.ToString(), 2);
                Environment.Exit(-1);
            }

            Tools.sw.Stop();
        }

        public static void CloseConnection()
        {
            Tools.sw = Stopwatch.StartNew();
            Tools.sw.Stop();

            try
            {
                Connection.Close();
                Logs.Write("Closing Connection...", 1);
                Logs.Write("Successfully Closed Pools and Connection at " + Tools.sw.ElapsedMilliseconds + "ms", 1);
            }
            catch (Exception ex)
            {
                Logs.Write(ex.Message.ToString(), 2);
            }
        }
    }
}
