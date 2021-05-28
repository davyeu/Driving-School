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
    /// Interaction logic for XMLWindowTester.xaml
    /// </summary>
    public partial class XMLWindowTester : Window
    {
        public XMLWindowTester()
        {
            InitializeComponent();
        }

        private void AddTester_Click(object sender, RoutedEventArgs e)
        {
            PL.AddTester tester = new PL.AddTester();
            tester.Show();
            this.Close();
        }

        private void UpdateTester_Click(object sender, RoutedEventArgs e)
        {
            PL.UpdateTesterWindow tester = new PL.UpdateTesterWindow();
            tester.Show();
            this.Close();
        }

        private void DeleteTester_Click(object sender, RoutedEventArgs e)
        {
            PL.DeleteTesterWindow tester = new PL.DeleteTesterWindow();
            tester.Show();
            this.Close();

        }
    }
}
