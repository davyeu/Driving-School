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
using BE;
namespace PL
{
    /// <summary>
    /// Interaction logic for updateTraineeWindow.xaml
    /// </summary>
    public partial class updateTraineeWindow : Window
    {
        public static Trainee ChosenTrainee;
        private ObservableCollection<Trainee> TraineeCollection =
      new ObservableCollection<BE.Trainee>();
        private Ibl bl = BL.Ibl_imp.GetInstance;
        public updateTraineeWindow()
        {
            InitializeComponent();
            ComoBoxTrainee.DataContext = TraineeCollection;
            foreach (var item in bl.GetTrainees())
            {
                TraineeCollection.Add(item);
            }
        }

        private void updateTrainee_Click(object sender, RoutedEventArgs e)
        {
            ChosenTrainee = (Trainee)ComoBoxTrainee.SelectedValue;
            if (ChosenTrainee == null)
            {
                MessageBox.Show("you do not chose a Trainee!");
                return;
            }
            //create an instance of the  suitable update window

            updateTraineeWindow2.updateTrainee1 = ChosenTrainee;
            Window updateTrainee = new updateTraineeWindow2();
            updateTrainee.ShowDialog();
            this.Close();
        }

        private void ComoBoxTrainee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
