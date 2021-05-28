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
    /// Interaction logic for UpdateTesterWindow.xaml
    /// </summary>
    public partial class UpdateTesterWindow : Window
    {
        public static BE.Tester ChosenTester;
        private ObservableCollection<BE.Tester> TesterCollection =
      new ObservableCollection<BE.Tester>();

        public UpdateTesterWindow()
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

        private void updateTester_Click(object sender, RoutedEventArgs e)
        {
            //chose the seleted tester form Comobox
             ChosenTester = (BE.Tester)ComoBoxTesters.SelectedValue;
            if (ChosenTester==null)
            {
                MessageBox.Show("you do not chose a tester!");
                return;
            }

            //create an instance of the  suitable update window

            UpdateTesterWindow2.updatedTester = ChosenTester;
            Window updateTester = new UpdateTesterWindow2();
            updateTester.ShowDialog();
            this.Close();
        }

        private void workSchedule_Click(object sender, RoutedEventArgs e)
        {
            //chose the seleted tester form Comobox
            ChosenTester = (BE.Tester)ComoBoxTesters.SelectedValue;
            if (ChosenTester == null)
            {
                MessageBox.Show("you do not chose a tester!");
                return;
            }

            //create an instance of the  suitable update window
            WorkScheduleWindow.updatedTester = ChosenTester;
            Window updateTesterSchedule = new WorkScheduleWindow();
            updateTesterSchedule.ShowDialog();
            this.Close();
        }
    }
}
