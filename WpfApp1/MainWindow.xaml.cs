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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LinearGradientBrush gradientBrush = new LinearGradientBrush(Color.FromRgb(81, 225, 255), Color.FromRgb(11, 60, 196), new Point(0.5, 0), new Point(0.5, 1));
            Background = gradientBrush;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (RPGMMODBEntities db = new RPGMMODBEntities())
            {
               
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
