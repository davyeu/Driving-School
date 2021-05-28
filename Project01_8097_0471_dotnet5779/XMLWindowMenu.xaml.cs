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
    /// Interaction logic for XMLWindowMenu.xaml
    /// </summary>
    public partial class XMLWindowMenu : Window
    {
        public XMLWindowMenu()
        {
            InitializeComponent();
        }

       

        private void TestersFile_Click(object sender, RoutedEventArgs e)
        {
            BL.Ibl bl = BL.FactoryBL.GetBL("Dal_XML_imp-Testers");
            PL.XMLWindowTester tester = new PL.XMLWindowTester();
            tester.Show();
            this.Close();
        }

        private void TraineesFile_Click(object sender, RoutedEventArgs e)
        {
            BL.Ibl bl = BL.FactoryBL.GetBL("Dal_XML_imp-Trainees");
            PL.XMLWindowTrainee trainee = new PL.XMLWindowTrainee();
            trainee.Show();
            this.Close();
        }

        private void TestsFile_Click(object sender, RoutedEventArgs e)
        {
            BL.Ibl bl = BL.FactoryBL.GetBL("Dal_XML_imp-Tests");
            PL.XMLWindowTest test = new PL.XMLWindowTest();
            test.Show();
            this.Close();
        }
    }
}
