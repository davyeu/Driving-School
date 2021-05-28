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
    /// Interaction logic for addTestWindow.xaml
    /// </summary>
    public partial class addTestWindow : Window
    {
        private ObservableCollection<BE.Tester> TesterCollection =
     new ObservableCollection<BE.Tester>();
        private ObservableCollection<BE.Trainee> TraineesCollection =
    new ObservableCollection<BE.Trainee>();

        BL.Ibl blayer = BL.Ibl_imp.GetInstance;
        BE.Trainee chosenTr = new BE.Trainee(); // will be change below according to the user choice
        BE.Tester chosenTs = new BE.Tester(); // will be change below according to the user choice
        DateTime timeOfTheTest = new DateTime(); // will be change below according to the user choice
        public addTestWindow()
        {
            InitializeComponent();
            idTextBox.Text = (BE.Configuration.CounterTestId+1).ToString(); // set the id of the test

            //set trainees list at ComoBox
            ComoBoxTrainees.DataContext = TraineesCollection;
            foreach (var item in blayer.GetTrainees())
            {
                TraineesCollection.Add(item);
            }
            
        }

        private void cheakTesters_Click(object sender, RoutedEventArgs e)
        {
            //cheaking whether the tester is open at the selected date
            DateTime temp = new DateTime();
            DateTime temp2;
            try
            {
                temp = (DateTime)TestDatePicker.SelectedDate;
                string choise = TestHour.SelectedValue.ToString();
                switch (choise)
                {
                    case "System.Windows.Controls.ComboBoxItem: 9:00-10:00": 
                        { temp2= new DateTime(temp.Year,temp.Month,temp.Day,9,0,0); break; }
                    case "System.Windows.Controls.ComboBoxItem: 10:00-11:00":
                        { temp2 = new DateTime(temp.Year, temp.Month, temp.Day, 10, 0, 0); break; }
                    case "System.Windows.Controls.ComboBoxItem: 11:00-12:00":
                        { temp2 = new DateTime(temp.Year, temp.Month, temp.Day, 11, 0, 0); break; }
                    case "System.Windows.Controls.ComboBoxItem: 12:00-13:00":
                        { temp2 = new DateTime(temp.Year, temp.Month, temp.Day, 12, 0, 0); break; }
                    case "System.Windows.Controls.ComboBoxItem: 13:00-14:00":
                        { temp2 = new DateTime(temp.Year, temp.Month, temp.Day, 13, 0, 0); break; }
                    case "System.Windows.Controls.ComboBoxItem: 14:00-15:00":
                        { temp2 = new DateTime(temp.Year, temp.Month, temp.Day, 14, 0, 0); break; }
                    default: { throw new Exception() ; }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("you don not chose a date or hour");
                return;
            }
            timeOfTheTest = temp2;
            //finding  chosen trainee address
           
            foreach (var item in blayer.GetTrainees())
            {
                if (item.ToString() == ComoBoxTrainees.SelectedValue.ToString())
                {
                     chosenTr = (BE.Trainee)item; break;
                }
            }
            ComoBoxTesters.DataContext = TesterCollection;
            // cheaking for  suitable Testers
            var suitableTesters = from item in blayer.openTesters(timeOfTheTest)
                                  from item2 in blayer.testersInTheArae(chosenTr.Address)
                                  where item.Id == item2.Id
                                  select item;

            foreach (var item3 in suitableTesters)
                TesterCollection.Add(item3);
           
            if (TesterCollection.Count == 0)
            {
                MessageBox.Show("there are no open testers at this date or range");
                return;
            }
            else
            {
                MessageBox.Show("there are  open testers at this date or range, you can select one of them" +
                      " at the field below");
                TestDetailsContinue.IsEnabled = true;
                AddTestButton.IsEnabled = true;
            }
        }

      

        private void AddTestButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComoBoxTesters.SelectedValue== null)
            {
                MessageBox.Show("please chosse a tester from the list");
                return;
            }
            foreach (var item in blayer.GetTesters())
            {
                if (item.ToString()== ComoBoxTesters.SelectedValue.ToString())
                {
                    chosenTs = item;
                    try {
                        BE.Test newTest = new BE.Test(chosenTs, chosenTr);
                        newTest.TimeOfTest = timeOfTheTest;
                            blayer.AddTest(newTest);
                            
                    }
                    catch (Exception ex)
                    {
                        BE.Configuration.CounterTestId--;
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    MessageBox.Show("The Test crate successfuly!");
                    this.Close();
                }
            }
        }
    }
}
