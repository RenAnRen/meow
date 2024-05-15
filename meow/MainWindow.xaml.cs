using design.MVVM.View;
using System;
using System.Buffers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace design
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            sidepanel.Visibility = Visibility.Hidden;

            HomeView homeView = new HomeView();
          
            homeView.dfw.Text = DateTime.Now.DayOfWeek.ToString();
            MessageBox.Show(homeView.dfw.Text);
        }

    
        private void panelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            

            sidepanel.Visibility = Visibility.Visible;
            panelHeader.Visibility = Visibility.Hidden;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
            sidepanel.Visibility = Visibility.Hidden;
            panelHeader.Visibility = Visibility.Visible;
        }

      

        //private static void DayOfWeek()
        //{
        //    DateTime date = DateTime.Now;
        //    string day = date.ToString("dddd");
        //    //   HomeView HVM = new HomeView();
        //    string DAY = day.ToUpper();
        //    string aaa = DAY + ", " + $"{date:M}";
        //    MainWindow hmv = new MainWindow();
        //    hmv.Show();

        //    hmv.DataContext = aaa;

        //    //HVM.dfw.Text = day + ", " + $"{date:M}";
        //}

    }
}
