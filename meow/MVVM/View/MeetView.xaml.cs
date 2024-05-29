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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace design.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для DiscoveryView.xaml
    /// </summary>
    public partial class MeetView : UserControl
    {

        string SQL = "Server=yurilo-9916.7tc.aws-eu-central-1.cockroachlabs.cloud;Port=26257;Database=yurilo_db; User Id = yurilo_admin; Password=yrPjMJoa5LQZGO1owOKdNA;";

        public MeetView()
        {
            InitializeComponent();
            ComboBoxes();
        }

      

        private void ComboBoxes()
        {
            ListContr();
            ListServ();
            List();

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
                 Cont.Items.Add(dr["Name"].ToString());
            }

            command.Dispose();
            sqlConnection.Close();
        }

        private void List()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(SQL);
            sqlConnection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand();
            command1.Connection = sqlConnection;
            command1.CommandType = CommandType.Text;

            NpgsqlDataAdapter dataAdapter1 = new NpgsqlDataAdapter();
            DataTable dataTable1 = new DataTable("yurilo_db.meet_types");
            DataSet ds1 = new DataSet();
            dataAdapter1.SelectCommand = command1;

            command1.CommandText = "SELECT name FROM yurilo_db.meet_types;";
            NpgsqlDataReader dr1 = command1.ExecuteReader();

            while (dr1.Read())
            {
                Type.Items.Add(dr1["Name"].ToString());
            }

            command1.Dispose();
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
            DataTable dataTable = new DataTable("yurilo_db.employees");
            DataSet ds = new DataSet();
            dataAdapter.SelectCommand = command;

            command.CommandText = "SELECT name FROM yurilo_db.employees;";
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                emp.Items.Add(dr["name"].ToString());
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

            
            int id_meet_type = int.Parse(GetMeetType());
            int id_emp = int.Parse(GetEmp());
            int id_cont = int.Parse(GetCont());


            //////// 
            command.CommandText = "INSERT INTO yurilo_db.meets (resume, counterparties, employyes, meet_type) VALUES (" + notes.Text + "," + id_cont + "," + id_emp + "," +  id_meet_type +  ");";
            /////

          
            NpgsqlDataReader dr = command.ExecuteReader();
            this.Content = new MeetsView();
        }

        private string GetMeetType()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(SQL);
            sqlConnection.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            DataTable dataTable = new DataTable("yurilo_db.meet_types");
            DataSet ds = new DataSet();
            dataAdapter.SelectCommand = command;
            
            command.CommandText = "SELECT id_meet_types FROM yurilo_db.meet_types WHERE name='" + Type.SelectedValue.ToString() + "';";
            NpgsqlDataReader dr = command.ExecuteReader();
            var id = "`";
            if (dr.Read()) { 
              id = dr[0].ToString();
            }
            return id;
           

            command.Dispose();
            sqlConnection.Close();
        }


        private string GetEmp()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(SQL);
            sqlConnection.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            DataTable dataTable = new DataTable("yurilo_db.employees");
            DataSet ds = new DataSet();
            dataAdapter.SelectCommand = command;

            command.CommandText = "SELECT id_employees  FROM yurilo_db.employees WHERE name='" + emp.SelectedValue.ToString() + "';";
            NpgsqlDataReader dr = command.ExecuteReader();
            var name = "`";
            if (dr.Read())
            {
                name = dr[0].ToString();
            }
            return name;


            command.Dispose();
            sqlConnection.Close();
        }

        private string GetCont()
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

            command.CommandText = "SELECT id_counterparties  FROM yurilo_db.counterparties WHERE name='" + Cont.SelectedValue.ToString() + "';";
            NpgsqlDataReader dr = command.ExecuteReader();
            var name = "`";
            if (dr.Read())
            {
                name = dr[0].ToString();
            }
            return name;


            command.Dispose();
            sqlConnection.Close();
        }


    }
}
