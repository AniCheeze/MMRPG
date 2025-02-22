﻿using MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        bool battleOver;
        Enemy MainEnemy = new Enemy("A", 100, 10, 5, 5);
        Players MainPlayer = new Players();
        DispatcherTimer PlayerASPD = new DispatcherTimer();
        DispatcherTimer EnemyASPD = new DispatcherTimer();
        SynchronizationContext context = SynchronizationContext.Current;
        public Window3()
        {
            InitializeComponent();
            LOADER();
            ENPGHP.Value = MainEnemy.HP;
            HPLB.Content = $"HP:{MainPlayer.HP}";
            ATKLB.Content = $"ATK:{MainPlayer.ATK}";
            DEFLB.Content = $"DEF:{MainPlayer.DEF}";
            SPDLB.Content = $"SPD:{MainPlayer.SPD}";
            PGBARPRG(MainEnemy, MainPlayer);
        }
        private void LOADER()
        {
            using (MMORPGBDEntities3 db = new MMORPGBDEntities3())
            {
                foreach (var saveData in db.SaveData)
                {
                    MainPlayer.Name = saveData.Name;
                    MainPlayer.ATK = saveData.ATK;
                    MainPlayer.DEF = saveData.DEF;
                    MainPlayer.HP = saveData.HP;
                    MainPlayer.SPD = 5;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void PGBARPRG(Enemy A, Players B)
        {
            int PSD = (5 - (B.SPD % 2 * 2) + (B.DEF % 3));
            int ESD = (5 - (A.SPD % 2 * 2) + (A.DEF % 3));
            ENPG.Maximum = ESD;
            PLPG.Maximum = PSD;
            Thread backgroundThread = new Thread(
                    new ThreadStart(() =>
                    {
                        for (int n = 0; n < 50; n++)
                        {
                            Thread.Sleep(1000);
                            context?.Post(new SendOrPostCallback((o) =>
                            {
                                if (PLPG.Value < PLPG.Maximum)
                                {
                                    PLPG.Value = n;
                                }
                                else if (battleOver == true)
                                {
                                    n = 50;
                                }
                                else
                                {
                                    PLPG.Value = 0;
                                    n = 0;
                                }
                            }), null);
                        };
                    }
                ));
            Thread backgroundThread1 = new Thread(
                    new ThreadStart(() =>
                    {
                        for (int n = 0; n < ESD; n++)
                        {
                            Thread.Sleep(1000);
                            context?.Post(new SendOrPostCallback((o) =>
                            {
                                if (ENPG.Value < PLPG.Maximum)
                                {
                                    PLPG.Value = n;
                                }
                                else if (battleOver == true)
                                {
                                    n = 50;
                                }
                                else
                                {
                                    ENPG.Value = 0;
                                    n = 0;
                                }
                            }), null);
                        };
                    }
                ));
            backgroundThread1.Start();
            backgroundThread.Start();
            Battle(A, B);
        }
        public void Battle(Enemy A, Players B)
        {
            int PSD = (5 - (B.SPD % 2 * 2) + (B.DEF % 3));
            int ESD = (5 - (A.SPD % 2 * 2) + (A.DEF % 3));
            PlayerASPD.Interval = TimeSpan.FromSeconds(PSD);
            EnemyASPD.Interval = TimeSpan.FromSeconds(ESD);
            PlayerASPD.Tick += PATK;
            EnemyASPD.Tick += EATK;
            PlayerASPD.Start();
            EnemyASPD.Start();
        }
        public void PATK(object sender, EventArgs e)
        {
            MainEnemy.HP -= (MainPlayer.ATK - MainEnemy.DEF);
            ENPGHP.Value = MainEnemy.HP;
            if (MainEnemy.HP > 0 && MainPlayer.HP > 0)
            {
                Battle(MainEnemy, MainPlayer);
            }
            else if (MainEnemy.HP > 0 && MainPlayer.HP <= 0)
            {
                PlayerASPD.Stop();
                EnemyASPD.Stop();
                MessageBox.Show("Mob Won");
                battleOver = true;
                Close();
            }
            else
            {
                PlayerASPD.Stop();
                EnemyASPD.Stop();
                MessageBox.Show("Player Won");
                battleOver = true;
                Close();
            }
        }
        public void EATK(object sender, EventArgs e)
        {
            MainPlayer.HP -= (MainEnemy.ATK - MainPlayer.DEF);
            HPLB.Content = $"HP:{MainPlayer.HP}";
            if (MainEnemy.HP > 0 && MainPlayer.HP > 0)
            {
                Battle(MainEnemy, MainPlayer);
            }
            else if (MainEnemy.HP > 0 && MainPlayer.HP <= 0)
            {
                PlayerASPD.Stop();
                EnemyASPD.Stop();
                MessageBox.Show("Mob Won");
                battleOver = true;
                Close();
            }
            else
            {
                PlayerASPD.Stop();
                EnemyASPD.Stop();
                MessageBox.Show("Player Won");
                battleOver = true;
                Close();
            }
        }
    }
}
