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
using System.Windows.Shapes;
using DragonNest.Dependencies;

namespace DragonNest
{
    /// <summary>
    /// Interaction logic for Control.xaml
    /// </summary>
    public partial class Control : Window
    {
        public Control()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database.CloseConnection();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
