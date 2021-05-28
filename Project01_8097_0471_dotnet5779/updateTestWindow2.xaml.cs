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
using BE;
using BL;


namespace PL
{
    /// <summary>
    /// Interaction logic for updateTestWindow2.xaml
    /// </summary>
    public partial class updateTestWindow2 : Window
    {
        BL.Ibl blayer = BL.Ibl_imp.GetInstance;
        public static Test updateTest1;
  
        public updateTestWindow2()
        {
            InitializeComponent();
            TestDetails.DataContext = updateTest1;

            kindOfCarComboBox.ItemsSource = Enum.GetValues(typeof(MyEnum.kindOfCars));
    
            gearBoxComboBox.ItemsSource =Enum.GetValues(typeof(MyEnum.gearBox));

          

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource testViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("testViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // testViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource myEnumViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("myEnumViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // myEnumViewSource.Source = [generic data source]
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                //update only n e s s c a r y details!
                updateTest1.KeepDistance = keepDistanceCheckBox.IsChecked.Value;
                updateTest1.LookingAtMirrors = lookingAtMirrorsCheckBox.IsChecked.Value;
                updateTest1.BackParking = backParkingCheckBox.IsChecked.Value;
                updateTest1.Signals = signalsCheckBox.IsChecked.Value;
                updateTest1.Score = scoreCheckBox.IsChecked.Value;

                //TesterRemarktextBox.Text, -there is no property to this field!!!


                blayer.UpdateTest(updateTest1);
            }


            catch (ArgumentNullException ex)
            {

                MessageBox.Show("The parmeter " + ex.ParamName + " is incorrect");
            }
            catch (FormatException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }
    }
}
