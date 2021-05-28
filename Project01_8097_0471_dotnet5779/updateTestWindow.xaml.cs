using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BE;
using BL;
namespace PL
{
    /// <summary>
    /// Interaction logic for updateTestWindow.xaml
    /// </summary>
    public partial class updateTestWindow : Window
    {
        public static Test ChosenTest;
        private ObservableCollection<Test> TestCollection =
      new ObservableCollection<BE.Test>();
        BL.Ibl blayer = BL.Ibl_imp.GetInstance;
        public updateTestWindow()
        {
            InitializeComponent();
            ComoBoxTest.DataContext = TestCollection;
            foreach (var item in blayer.GetTests())
            {
                TestCollection.Add(item);
            }
        }

        private void updateTester_Click(object sender, RoutedEventArgs e)
        {
            ChosenTest = (Test)ComoBoxTest.SelectedValue;
            if (ChosenTest == null)
            {
                MessageBox.Show("you do not chose a Test!");
                return;
            }
            //create an instance of the  suitable update window

            updateTestWindow2.updateTest1 = ChosenTest;
            Window updateTest1 = new updateTestWindow2();
            updateTest1.ShowDialog();
            this.Close();
        }

        private void ComoBoxTesters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
