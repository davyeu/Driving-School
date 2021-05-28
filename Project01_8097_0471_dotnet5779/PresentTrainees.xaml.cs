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
    /// Interaction logic for PresentTrainees.xaml
    /// </summary>
    public partial class PresentTrainees : Window
    {
        public DataTable dataTableColection { get; }
        public PresentTrainees()
        {
            InitializeComponent();
            dataTableColection = getDataTable();
            getDataTable();
            gridTrainees.DataContext = dataTableColection.DefaultView;
        }

        private DataTable getDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(new System.Data.DataColumn("ID", typeof(string)));
            dataTable.Columns.Add(new System.Data.DataColumn("FirstName", typeof(string)));
            dataTable.Columns.Add(new System.Data.DataColumn("LastName", typeof(string)));
            List<Trainee> trainees = BL.Ibl_imp.GetInstance.GetTrainees();
            foreach (Trainee trainee in trainees)
            {
               
                var row = dataTable.NewRow();
                row["ID"] = trainee.Id;
                row["FirstName"] = trainee.FirstName;
                row["LastName"] = trainee.LastName;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}

