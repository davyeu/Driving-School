using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DeleteTesterWindow.xaml
    /// </summary>
    public partial class DeleteTesterWindow : Window
    {
        BL.Ibl blayer = BL.Ibl_imp.GetInstance;
        public static BE.Tester ChosenTester;

        private ObservableCollection<BE.Tester> TesterCollection =
      new ObservableCollection<BE.Tester>();

        public DeleteTesterWindow()
        {
            InitializeComponent();
            ComoBoxTesters.DataContext = TesterCollection;
            // the testers names will appear at the ComoBox list at
            // the user interface (the current window).
            BL.Ibl blayer = BL.Ibl_imp.GetInstance;
            foreach (var item in blayer.GetTesters())
            {
                TesterCollection.Add(item);
            }
        }

        private void DeleteTester_Click(object sender, RoutedEventArgs e)
        {
            //chose the seleted tester form Comobox
            ChosenTester = (BE.Tester)ComoBoxTesters.SelectedValue;
            if (ChosenTester == null)
            {
                MessageBox.Show("you do not chose a tester!");
                return;
            }
            blayer.DeleteTester(ChosenTester);
            this.Close();
        }
    }
}