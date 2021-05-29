using BE;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for PresentTests.xaml
    /// </summary>
    public partial class PresentTests : Window
    {
        public DataTable dataTableColection { get; }
        public PresentTests()
        {
            InitializeComponent();
            dataTableColection = getDataTable();         
            gridTests.DataContext = dataTableColection.DefaultView;
        }

        private DataTable getDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(new System.Data.DataColumn("Test ID", typeof(string)));
            dataTable.Columns.Add(new System.Data.DataColumn("Tester ID", typeof(string)));         
            dataTable.Columns.Add(new System.Data.DataColumn("Trainee ID", typeof(string)));       
            List<Test> tests = BL.Ibl_imp.GetInstance.GetTests();
            foreach (Test test in tests)
            {
                var row = dataTable.NewRow();
                row["Test ID"] = test.IdOfTest;
                row["Tester ID"] = test.IdOfTester;
                row["Trainee ID"] = test.IdOfTrainee;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
    }
}
