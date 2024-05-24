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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //NpgsqlConnection sqlConnection = new NpgsqlConnection(SQL);
            //sqlConnection.Open();

            //NpgsqlCommand command = new NpgsqlCommand();
            //command.Connection = sqlConnection;
            //command.CommandType = CommandType.Text;

            //NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            //DataTable dataTable = new DataTable("yurilo_db.counterparties");
            //dataAdapter.SelectCommand = command;
            //command.CommandText = "INSERT INTO yurilo_db.counterparties (name, id_subject_type, address, number, company, INN, KPP, OGRN, email, notes) VALUES ('" + name.Text + "','" + subject_type.Text + "','" + address.Text + "','" + number.Text + "','" + company.Text + "','" + INN.Text + "','" + KPP.Text + "','" + OGRN.Text + "','" + email.Text + "','" + notes.Text + "');";

            ////command.CommandText = "SELECT * FROM users WHERE login='" + log.Text + "' AND password ='" + passw.Password + "';";
            //NpgsqlDataReader dr = command.ExecuteReader();


        }
    }
}
