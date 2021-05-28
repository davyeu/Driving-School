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
using System.Collections.ObjectModel;

using BL;
using BE;
namespace PL
{
    /// <summary>
    /// Interaction logic for DeleteTestWindow.xaml
    /// </summary>
    public partial class DeleteTestWindow : Window
    {
        BL.Ibl blayer = BL.Ibl_imp.GetInstance;

        public static BE.Test ChosenTest;

        private ObservableCollection<BE.Test> TestCollection =
      new ObservableCollection<BE.Test>();
        public DeleteTestWindow()
        {
            InitializeComponent();
            ComoBoxTest.DataContext = TestCollection;
            foreach (var Item in blayer.GetTests())
            {
                TestCollection.Add(Item);
            }
        }

        private void ComoBoxTrainee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeleteTrainee_Click(object sender, RoutedEventArgs e)
        {
           
            ChosenTest = (BE.Test)ComoBoxTest.SelectedValue;
            if (ChosenTest == null)
            {
                MessageBox.Show("you do not chose a Test!");
                return;
            }
            blayer.DeleteTest(ChosenTest);
            this.Close();
        }
    }
}
