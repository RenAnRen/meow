﻿using System;
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

namespace design.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
           public string DayOfWeek
        {
            get { return dfw.Text; }
            set { dfw.Text = value; }
        }

        public HomeView()
        {
           InitializeComponent();

        
            DayOfWeek = DateTime.Now.ToString("dddd").ToUpper() + ", " + $"{DateTime.Now:M}";


        }







    } 
   
}
