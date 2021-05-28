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

namespace PL
{
    /// <summary>
    /// Interaction logic for XMLWindowTest.xaml
    /// </summary>
    public partial class XMLWindowTest : Window
    {
        public XMLWindowTest()
        {
            InitializeComponent();
        }

        private void AddTest_Click(object sender, RoutedEventArgs e)
        {
            PL.addTestWindow test = new PL.addTestWindow();
            test.Show();
            test.Close();

        }

        private void UpdateTast_Click(object sender, RoutedEventArgs e)
        {
            PL.updateTestWindow test = new PL.updateTestWindow();
            test.Show();
            test.Close();
        }

        private void DeleteTest_Click(object sender, RoutedEventArgs e)
        {
            PL.DeleteTestWindow test = new PL.DeleteTestWindow();
            test.Show();
            test.Close();
        }
    }
}
