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

        }
        
             
          
    
#pragma warning disable IDE1006 // Стили именования
        private void panelHeader_MouseDown(object sender, MouseButtonEventArgs e)
#pragma warning restore IDE1006 // Стили именования
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

     

    }
}
