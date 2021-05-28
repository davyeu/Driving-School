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
    /// Interaction logic for AddTester.xaml
    /// </summary>
    public partial class AddTester : Window
    {
        public AddTester()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BE.Tester tester;
            try
            {
                // collecting the information from the current window and insert them to local variables
                string id = idTextBox.Text;
                string firstName = FNameTextBox.Text;
                string lastName = LNameTextBox.Text;

                DatePicker p = birthDayPicker;
                DateTime d = p.DisplayDate;

                BE.MyEnum.gender gender;
                ComboBox temp = genderList;
                if (temp.Text == "Male")
                {
                    gender = BE.MyEnum.gender.male;
                }
                else
                {
                    gender = BE.MyEnum.gender.female;
                }

                string PhoneNumber = PhoneTextBox.Text;

                string streetName = StreetTextBox.Text;
                int numOfBuilding = int.Parse(BuildingTextBox.Text);
                string city = CityTextBox.Text;

                int numOfExperience = int.Parse(ExperienceTextBox.Text);
                int maxTestAtWeek = int.Parse(MaxTestsTextBox.Text);

                List<BE.MyEnum.kindOfCars> kindOfCars = new List<BE.MyEnum.kindOfCars>();
                foreach (var item in carList.SelectedItems)
                {
                    if (item.ToString() == "System.Windows.Controls.ListBoxItem: PrivateCar")
                        kindOfCars.Add(BE.MyEnum.kindOfCars.PrivateCar);
                    if (item.ToString() == "System.Windows.Controls.ListBoxItem: TwoWheeledVehicles")
                        kindOfCars.Add(BE.MyEnum.kindOfCars.TwoWheeledVehicles);
                    if (item.ToString() == "System.Windows.Controls.ListBoxItem: Truck")
                        kindOfCars.Add(BE.MyEnum.kindOfCars.Truck);
                    if (item.ToString() == "System.Windows.Controls.ListBoxItem: Semitrailer")
                        kindOfCars.Add(BE.MyEnum.kindOfCars.Semitrailer);
                }

                int maximumDistanceFromAddress = int.Parse(distanceTextBox.Text);
                int numOfTestsAtWeek = int.Parse(MaxTestsTextBox.Text);

                 tester = new BE.Tester(id, lastName, firstName, d, gender, PhoneNumber,
                    new BE.Address(streetName, numOfBuilding, city), numOfExperience, maxTestAtWeek,
                    maximumDistanceFromAddress, numOfTestsAtWeek);

                tester.KindOfCar = kindOfCars;
                BL.Ibl blayer = BL.Ibl_imp.GetInstance;
                blayer.AddTester(tester);
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
