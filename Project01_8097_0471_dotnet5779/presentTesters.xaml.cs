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
    /// Interaction logic for presentTesters.xaml
    /// </summary>
    public partial class presentTesters : Window
    {
       
        public DataTable dataTableColection { get; } 
      

        public presentTesters()
        {
            InitializeComponent();
            dataTableColection = getDataTable();          
            getDataTable();
            gridTesters.DataContext = dataTableColection.DefaultView;

        }

        private DataTable  getDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(new System.Data.DataColumn("ID", typeof(string)));
            dataTable.Columns.Add(new System.Data.DataColumn("FirstName", typeof(string)));
            dataTable.Columns.Add(new System.Data.DataColumn("LastName", typeof(string)));
            List<Tester> testers=BL.Ibl_imp.GetInstance.GetTesters();         
            foreach (Tester tester in testers )
             {
                 var row = dataTable.NewRow();
                 row["ID"] = tester.Id;
                 row["FirstName"] =tester.FirstName;
                 row["LastName"] = tester.LastName;

                 dataTable.Rows.Add(row);
             }

            return dataTable;
        }
    }
}

