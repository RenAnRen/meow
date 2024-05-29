using MaterialDesignThemes.Wpf;
using meow.UserControls;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
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

namespace design.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для DiscoveryView.xaml
    /// </summary>
    public partial class ContractorsView : UserControl
    {

        string SQL = "Server=yurilo-9916.7tc.aws-eu-central-1.cockroachlabs.cloud;Port=26257;Database=yurilo_db; User Id = yurilo_admin; Password=yrPjMJoa5LQZGO1owOKdNA;";

        public ContractorsView()
        {
            InitializeComponent();
          
            //ListCont();
        }


        private void ListCont()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(SQL);
            sqlConnection.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;

            command.CommandText = "select date, meet_types.name AS meet_type, counterparties.name AS cont from yurilo_db.meets, yurilo_db.counterparties, yurilo_db.meet_types where yurilo_db.meets.counterpaprties=yurilo_db.counterparties.id_counterparties AND yurilo_db.meets.meet_type=yurilo_db.meet_types.id_meet_types;";
            NpgsqlDataReader dr = command.ExecuteReader();

            blocks.ItemsSource = dr;
            //List l = new();
            //string n = "block_";
            //int a = 1;
            //while (dr.Read())
            //{
                
            //    // Textblock_contractor block = new();
                

            //    //block.Time.Text = dr["date"].ToString();
            //    //block.Type.Text = dr["meet_type"].ToString();
            //    //block.Contractor.Text = dr["cont"].ToString();
            //    //block.Name = n + a.ToString();
            //    a++;
               
            //}
           
            command.Dispose();
            sqlConnection.Close();

        }

      
    }
}
