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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (ProgectMMO db = new ProgectMMO())
            {
                Player player = new Player();
                foreach (var players in db.Player)
                {
                    if (players.Login == "Username")
                    {
                        player.IdSaveData = players.IdSaveData;
                    }
                }
                foreach(var items in db.Inventory)
                {
                    if (items.IdSaveData == player.IdSaveData)
                    {
                        listbox1.Items.Add(items.Name);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            if (listbox1.SelectedItem != null)
            {
                MessageBox.Show("1");
            }
            else if(listbox2.SelectedItem != null)
            {
                MessageBox.Show("2");
            }
            else
            {
                MessageBox.Show("Вы не выбрали ничего","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            mainWindow.Close();
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Close();
        }
    }
}
