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
    /// Interaction logic for XMLWindowTrainee.xaml
    /// </summary>
    public partial class XMLWindowTrainee : Window
    {
        public XMLWindowTrainee()
        {
            InitializeComponent();
        }

        private void AddTrainee_Click(object sender, RoutedEventArgs e)
        {
            PL.AddTraineeWindow trainne = new PL.AddTraineeWindow();
            trainne.Show();
            this.Close();
        }

        private void UpdateTrainne_Click(object sender, RoutedEventArgs e)
        {
            PL.updateTraineeWindow trainne = new PL.updateTraineeWindow();
            trainne.Show();
            this.Close();
        }

        private void DeleteTrainne_Click(object sender, RoutedEventArgs e)
        {
            PL.DeleteTraineeWindow trainne = new PL.DeleteTraineeWindow();
            trainne.Show();
            this.Close();
        }
    }
}
