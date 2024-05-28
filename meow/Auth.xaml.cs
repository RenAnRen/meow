using design;
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
using System.Windows.Shapes;

namespace meow
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        string SQL = "Server=yurilo-9916.7tc.aws-eu-central-1.cockroachlabs.cloud;Port=26257;Database=yurilo_db; User Id = yurilo_admin; Password=yrPjMJoa5LQZGO1owOKdNA;";

        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLConnectionReader();
        }

        private void SQLConnectionReader()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(SQL);
            sqlConnection.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;

            command.CommandText = "SELECT * FROM users WHERE login='" + log.Text + "' AND password ='" + passw.Password + "';";
            NpgsqlDataReader dr = command.ExecuteReader();

            int count = 0;
            while (dr.Read())
            {
                count++;
            }
            if (count == 1)
            {
                this.Hide();
                MainWindow last_win = new MainWindow();

                last_win.Show();
            }
            if (count > 1)
            {
                MessageBox.Show("Логин и пароль повторяются. Попробуйте снова!");
            }
            if (count < 1)
            {
                MessageBox.Show("Данные введены некорректно.");
            }
        }
    }
}
