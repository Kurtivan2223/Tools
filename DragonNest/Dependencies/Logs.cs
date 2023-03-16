using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DragonNest.Dependencies
{
    public class Logs
    {
        private static string GetTimeStamp(DateTime value)
        {
            return value.ToString("yyyy MM dd HH:mm:ss ffff");
        }

        public static void Write(string Text, int code)
        {
            string timestamp = GetTimeStamp(DateTime.Now);

            switch (code)
            {
                case 1:
                    File.AppendAllText(@"Logs\\Logs.txt", "[INFO] " + timestamp + " " + Text + Environment.NewLine);
                    break;
                case 2:
                    File.AppendAllText(@"Logs\\Logs.txt", "[ERROR] " + timestamp + " " + Text + Environment.NewLine);
                    break;
                case 3:
                    File.AppendAllText(@"Logs\\Logs.txt", "[WARNING] " + timestamp + " " + Text + Environment.NewLine);
                    break;
            }
        }
    }
}
