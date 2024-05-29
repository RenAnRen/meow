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
using Npgsql;
using static System.Net.Mime.MediaTypeNames;

namespace design.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для DiscoveryView.xaml
    /// </summary>
    public partial class ContractorView : UserControl
    {
        string SQL = "Server=yurilo-9916.7tc.aws-eu-central-1.cockroachlabs.cloud;Port=26257;Database=yurilo_db; User Id = yurilo_admin; Password=yrPjMJoa5LQZGO1owOKdNA;";


        public ContractorView()
        {
            InitializeComponent();
            ComboBoxes();
        }

        private void ComboBoxes()
        {
           
                NpgsqlConnection sqlConnection = new NpgsqlConnection(SQL);
                sqlConnection.Open();

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = sqlConnection;
                command.CommandType = CommandType.Text;

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
                DataTable dataTable = new DataTable("yurilo_db.subject_types");
                DataSet ds = new DataSet();
                dataAdapter.SelectCommand = command;

                command.CommandText = "SELECT name FROM yurilo_db.subject_types;";
                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    sub_type.Items.Add(dr["name"].ToString());
                }

                command.Dispose();
                sqlConnection.Close();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            NpgsqlConnection sqlConnection = new NpgsqlConnection(SQL);
            sqlConnection.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            DataTable dataTable = new DataTable("yurilo_db.counterparties");
            dataAdapter.SelectCommand = command;

            int id_subject_type = int.Parse(GetType());
           
            command.CommandText = "INSERT INTO yurilo_db.counterparties (name, id_subject_type, address, number, company, inn, kpp, ogrn, email, notes) VALUES ('" + name.Text + "'," + id_subject_type + ",'" + address.Text + "','" + number.Text +  "','" + company.Text + "','"  + INN.Text + "','" + KPP.Text + "','"  + OGRN.Text + "','" + email.Text + "','" + notes.Text + "');";

            NpgsqlDataReader dr = command.ExecuteReader();
            this.Content = new ContractorsView();

        }

        private string GetType()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(SQL);
            sqlConnection.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            DataTable dataTable = new DataTable("yurilo_db.subject_types");
            DataSet ds = new DataSet();
            dataAdapter.SelectCommand = command;

            command.CommandText = "SELECT id_subject_types FROM yurilo_db.subject_types WHERE name='" + sub_type.SelectedValue.ToString() + "';";
            NpgsqlDataReader dr = command.ExecuteReader();
            var id = " ";
            if (dr.Read())
            {
                id = dr[0].ToString();
            }
            return id;


            command.Dispose();
            sqlConnection.Close();
        }
    }
}
