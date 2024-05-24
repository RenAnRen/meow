using Npgsql;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace design.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для DiscoveryView.xaml
    /// </summary>
    public partial class MeetsView : UserControl
    {
        string SQL = "Server=yurilo-9916.7tc.aws-eu-central-1.cockroachlabs.cloud;Port=26257;Database=yurilo_db; User Id = yurilo_admin; Password=yrPjMJoa5LQZGO1owOKdNA;";


        public MeetsView()
        {
            InitializeComponent();

            ComboBoxes();

        }

        private void ComboBoxes() 
        {
            ListContr();
            ListServ();
        }

        private void ListContr()
        {
           NpgsqlConnection sqlConnection = new NpgsqlConnection(SQL);
            sqlConnection.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            DataTable dataTable = new DataTable("yurilo_db.counterparties");
            DataSet ds = new DataSet();
            dataAdapter.SelectCommand = command;

            command.CommandText = "SELECT name FROM yurilo_db.counterparties;";
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                comboBoxcont.Items.Add(dr["Name"].ToString());
            }
 
            command.Dispose();
            sqlConnection.Close();  
        }

        private void ListServ()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(SQL);
            sqlConnection.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            DataTable dataTable = new DataTable("yurilo_db.counterparties");
            DataSet ds = new DataSet();
            dataAdapter.SelectCommand = command;

            command.CommandText = "SELECT descriptions FROM yurilo_db.services;";
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                comboBoxserv.Items.Add(dr["descriptions"].ToString());
            }

            command.Dispose();
            sqlConnection.Close();
        }

        private void Label_GotFocus(object sender, RoutedEventArgs e)
        {
            comboBoxserv.SelectedIndex = -1;
            comboBoxcont.SelectedIndex = -1;
            Date.Text = "ДД.ММ.ГГГГ";
            comboBox.SelectedIndex = -1;    
        }
    }
}
