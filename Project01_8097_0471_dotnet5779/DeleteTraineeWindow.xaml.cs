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
using BL;
namespace PL
{
    /// <summary>
    /// Interaction logic for DeleteTraineeWindow.xaml
    /// </summary>
    public partial class DeleteTraineeWindow : Window
    {
        private Ibl bl = BL.Ibl_imp.GetInstance;

        public static BE.Trainee ChosenTrainee;

        private ObservableCollection<BE.Trainee> TraineeCollection =
      new ObservableCollection<BE.Trainee>();

        public DeleteTraineeWindow()
        {
            InitializeComponent();
            ComoBoxTrainee.DataContext = TraineeCollection;
            // the testers names will appear at the ComoBox list at
            // the user interface (the current window).
            BL.Ibl blayer = BL.Ibl_imp.GetInstance;
            foreach (var item in blayer.GetTrainees())
            {
                TraineeCollection.Add(item);
            }
        }

        private void DeleteTrainee_Click(object sender, RoutedEventArgs e)
        {
            //chose the seleted tester form Comobox
            ChosenTrainee = (BE.Trainee)ComoBoxTrainee.SelectedValue;
            if (ChosenTrainee == null)
            {
                MessageBox.Show("you do not chose a trainee!");
                return;
            }
            bl.DeleteTrainee(ChosenTrainee);
            this.Close();
        }
    }
}
