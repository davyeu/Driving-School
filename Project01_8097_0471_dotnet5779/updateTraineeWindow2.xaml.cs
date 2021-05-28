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
using BE;
using BL;
namespace PL
{
    /// <summary>
    /// Interaction logic for updateTraineeWindow2.xaml
    /// </summary>
    public partial class updateTraineeWindow2 : Window
    {
        private Ibl bl = BL.Ibl_imp.GetInstance;
        public static Trainee updateTrainee1;
        public updateTraineeWindow2()
        {
            InitializeComponent();

            TraineeDetails.DataContext = updateTrainee1;
            LastTestPicker.DisplayDateEnd = DateTime.Now.AddDays(-7);
            KindOfCarComboBox.ItemsSource = Enum.GetValues(typeof(MyEnum.kindOfCars));
            birthDayPicker.DisplayDateEnd = DateTime.Now.AddYears(-Configuration.minimumTraineeAge);
            GenderComboBox.ItemsSource = Enum.GetValues(typeof(MyEnum.gender));
            gearBoxComboBox.ItemsSource = Enum.GetValues(typeof(MyEnum.gearBox));
           
        }




        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                string street = StreetTextBox.Text;
                string city = CityTextBox.Text;
                int numOfStreet = int.Parse(BuildingTextBox.Text);
               
                TraineeDetails.DataContext = updateTrainee1;



                updateTrainee1 = new Trainee(updateTrainee1.Id, LNameTextBox.Text, FNameTextBox.Text,
                    birthDayPicker.DisplayDate, (MyEnum.gender)GenderComboBox.SelectedValue, PhoneTextBox.Text,
                    new BE.Address(street, numOfStreet, city), (MyEnum.kindOfCars)KindOfCarComboBox.SelectedValue,
                    (MyEnum.gearBox)gearBoxComboBox.SelectedValue, nameOfTeacherTextBox.Text, nameOfTeacherTextBox.Text);
                try { updateTrainee1.NumOfLessons = int.Parse(numberOfLessonsTextBox.Text); }
                catch (Exception ex)
                {
                    MessageBox.Show("can not parse number of lessons");
                }
                bl.UpdateTrainee(updateTrainee1);
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
