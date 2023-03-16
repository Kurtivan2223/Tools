using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using DragonNest.Dependencies;

namespace DragonNest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            if(!File.Exists(@"Config\\Settings.ini"))
            {
                Logs.Write("Setting Up Configs!", 1);
                Configuration.CreateIni();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Logs.Write("Program Exit", 1);
            Environment.Exit(0);
        }
    }
}