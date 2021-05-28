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
    /// Interaction logic for dataPresention.xaml
    /// </summary>
    public partial class dataPresention : Window
    {
        public dataPresention()
        {
            InitializeComponent();
        }

        private void show_testers_Click(object sender, RoutedEventArgs e)
        {
            Window presentTesters = new PL.presentTesters();
            presentTesters.Show();

        }

        private void show_trainees_Click(object sender, RoutedEventArgs e)
        {
            Window presentTrainees = new PL.PresentTrainees();
            presentTrainees.Show();
        }

        private void show_tests_Click(object sender, RoutedEventArgs e)
        {
            Window presentTests = new PL.PresentTests();
            presentTests.Show();
        }
    }
}
