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
using BL;
using BE;
namespace PL
{
    /// <summary>
    /// Interaction logic for AddTraineeWindow.xaml
    /// </summary>
    /// 

    public partial class AddTraineeWindow : Window
    {
        private Ibl bl = Ibl_imp.GetInstance;


        public AddTraineeWindow()
        {
            InitializeComponent();
            genderList.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.gender));
            gearBoxList.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.gearBox));
            kindOfCarList.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.kindOfCars));
            birthDayPicker.DisplayDateEnd = DateTime.Now.AddYears(-Configuration.minimumTraineeAge);

        }

       
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {


                try
                {



                    string street = StreetTextBox.Text;
                    string city = CityTextBox.Text;
                    int numOfStreet = int.Parse(BuildingTextBox.Text);



                    bl.AddTrainee(new BE.Trainee(idTextBox.Text, LastNametextBox.Text, FirstNameTextBox.Text, birthDayPicker.DisplayDate,
                        (MyEnum.gender)genderList.SelectedValue, PelephoneNumberTextBox.Text,
                    new BE.Address(street, numOfStreet, city), (MyEnum.kindOfCars)kindOfCarList.SelectedValue,
                    (MyEnum.gearBox)gearBoxList.SelectedValue, NameOfSchoolTextBox.Text, NameOfTeacherTextBox.Text));
                    this.Close();
                }



                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
