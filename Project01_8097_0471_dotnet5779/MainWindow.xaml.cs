/**
 * David BM 
 * email: davidbenmi@gmail.com
 * 
 * This is .NET project that represents a platform to connection between driving teachers and students.
 * The establishment of the program is the Microsoft three layers Moodle:
 * Presentation layer, Business Layer and Data Layer.
 * In the Data layer we store a database of driving teachers and students and their personal details.
 * We can see the details of the teachers and the students and do many manipulations on them like:
 *  set a lesson, by the GUI that show up at the running of the program. 
 *  The Business layer has all the logical operations that enable the manipulation of the driving school.
 */



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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project01_8097_0471_dotnet5779
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BL.Ibl blayer = BL.FactoryBL.GetBL("Dal_imp");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTester_Click(object sender, RoutedEventArgs e)
        {
            BL.Ibl blayer = BL.FactoryBL.GetBL("Dal_imp");
            Window AddTesterWindow = new PL.AddTester();
            AddTesterWindow.Show();
        }

        private void UpdateTester_Click(object sender, RoutedEventArgs e)
        {
            BL.Ibl blayer = BL.FactoryBL.GetBL("Dal_imp");
            Window UpdateTesterWindow = new PL.UpdateTesterWindow();
            UpdateTesterWindow.Show();
        }

        private void DeleteTester_Click(object sender, RoutedEventArgs e)
        {
            BL.Ibl blayer = BL.FactoryBL.GetBL("Dal_imp");
            Window DeleteTesterWindow = new PL.DeleteTesterWindow();
            DeleteTesterWindow.Show();
        }

        private void AddTrainee_Click(object sender, RoutedEventArgs e)
        {
            BL.Ibl blayer = BL.FactoryBL.GetBL("Dal_imp");
            Window addTraineeWindow = new PL.AddTraineeWindow();
            addTraineeWindow.Show();
        }

        private void updateTrainee_Click(object sender, RoutedEventArgs e)
        {
            BL.Ibl blayer = BL.FactoryBL.GetBL("Dal_imp");
            Window updateTraineeWindow = new PL.updateTraineeWindow();
            updateTraineeWindow.Show();
        }

        private void removeTrainee_Click(object sender, RoutedEventArgs e)
        {
            BL.Ibl blayer = BL.FactoryBL.GetBL("Dal_imp");
            Window removeTraineeWindow = new PL.DeleteTraineeWindow();
            removeTraineeWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource testViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("testViewSource")));
            
            // Load data by setting the CollectionViewSource.Source property:
            // testViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource traineeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("traineeViewSource")));
            

            // Load data by setting the CollectionViewSource.Source property:
            // traineeViewSource.Source = [generic data source]
        }

        private void addTest_Click(object sender, RoutedEventArgs e)
        {
            BL.Ibl blayer = BL.FactoryBL.GetBL("Dal_imp");
            Window addTestWindow = new PL.addTestWindow();
            addTestWindow.Show();
        }

        private void updateTest_Click(object sender, RoutedEventArgs e)
        {
            BL.Ibl blayer = BL.FactoryBL.GetBL("Dal_imp");
            Window updateTestWindow = new PL.updateTestWindow();
            updateTestWindow.Show();
        }

        private void deleteTest_Click(object sender, RoutedEventArgs e)
        {
            BL.Ibl blayer = BL.FactoryBL.GetBL("Dal_imp");
            Window deleteTestWindow = new PL.DeleteTestWindow();//
            deleteTestWindow.Show();
        }

        private void XMLfile_Click(object sender, RoutedEventArgs e)
        {
            Window XMLFile = new PL.XMLWindowMenu();
            XMLFile.Show();
        }

        private void show_data(object sender, RoutedEventArgs e)
        {
            Window dataPresention = new PL.dataPresention();
            dataPresention.Show();
        }
    }
}
