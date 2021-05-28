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
    /// Interaction logic for WorkScheduleWindow.xaml
    /// </summary>
    public partial class WorkScheduleWindow : Window
    {
        public static BE.Tester updatedTester;

        public WorkScheduleWindow()
        {
            InitializeComponent();
         }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            //initlaized the matrix of day of worker
            int i = -1;

            foreach (ListBox item in ListBoxesStackPanel.Children)
            {
                i++;
                foreach (var element in item.SelectedItems)
                {
                    if (element.ToString() == "System.Windows.Controls.ListBoxItem: 9:00-10:00")
                        updatedTester.ArrayOfWorkerDays[i, 0] = true;
                    if (element.ToString() == "System.Windows.Controls.ListBoxItem: 10:00-11:00")
                        updatedTester.ArrayOfWorkerDays[i, 1] = true;
                    if (element.ToString() == "System.Windows.Controls.ListBoxItem: 11:00-12:00")
                        updatedTester.ArrayOfWorkerDays[i, 2] = true;
                    if (element.ToString() == "System.Windows.Controls.ListBoxItem: 12:00-13:00")
                        updatedTester.ArrayOfWorkerDays[i, 3] = true;
                    if (element.ToString() == "System.Windows.Controls.ListBoxItem: 13:00-14:00")
                        updatedTester.ArrayOfWorkerDays[i, 4] = true;
                    if (element.ToString() == "System.Windows.Controls.ListBoxItem: 14:00-15:00")
                        updatedTester.ArrayOfWorkerDays[i, 5] = true;
                }

            }
            BL.Ibl blayer = BL.Ibl_imp.GetInstance;
            blayer.UpdateTester(updatedTester);
        }
    }
}
