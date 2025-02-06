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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using MainClasses;
using WpfApp1;


namespace WpfApp11
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    /// 
    public partial class Window1 : Window
    { 

        SynchronizationContext ctx = SynchronizationContext.Current ?? new SynchronizationContext();
        int PSD;
        int ESD;
        void RunOnGuiThread(Action action)
        {
            this.ctx.Post(o => action(), null);
        }
        public string NameGG { get; set; }
        DispatcherTimer timeL = new DispatcherTimer();
        DispatcherTimer timerV = new DispatcherTimer();
        DispatcherTimer PlayerASPD = new DispatcherTimer();
        DispatcherTimer EnemyASPD = new DispatcherTimer();
        Players MainPlayer = new Players();
        Enemy MainEnemy = new Enemy();
        public void LOADER()
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
        public Window1(string namegg)
        {
            NameGG = namegg;
            InitializeComponent();
            LOADER();
        }

        public void Travel()
        {
            int TT1;
            int TT2;
            Random R1 = new Random();
            Random R2 = new Random();
            TT1 = R1.Next(3, 10);
            TT2 = R2.Next(5, 10);
            if (TT1 == TT2)
            {
                TT1 = TT2 + 1;
            }
            SynchronizationContext context = SynchronizationContext.Current;

            Thread backgroundThread = new Thread(
                    new ThreadStart(() =>
                    {
                        for (int n = 0; n < TT2; n++)
                        {
                            Thread.Sleep(1000);
                            context?.Post(new SendOrPostCallback((o) =>
                            {
                                PG1.Value = n;
                            }), null);
                        };
                    }
                ));
            backgroundThread.Start();
            timeL.Tick += TimerTickFail;
            timerV.Tick += TimerTickSuccess;
            timeL.Interval = TimeSpan.FromSeconds(TT1);
            timerV.Interval = TimeSpan.FromSeconds(TT2);
            timeL.Start();
            timerV.Start();
            PG1.Maximum = TT2;
            PG1.Minimum = 0;
            PG1.Value = 0;
            PG1.Visibility = Visibility.Visible;
        }

        public void PRGBAR()
        {
            if (PG1.Value < PG1.Maximum)
            {
                PG1.Value += 1;
            }
        }

        private void TimerTickFail(object sender, EventArgs e)
        {
            timerV.Stop();
            timeL.Stop();
            MessageBox.Show("Battle");

            Window3 window3 = new Window3();
            window3.Show();
        }
        private void TimerTickSuccess(object sender, EventArgs e)
        {
            timerV.Stop();
            timeL.Stop();
            MessageBox.Show("Success");

            PG1.Visibility = Visibility.Hidden;
        }
        private void TTTICK(object sender, EventArgs e)
        {
           PRGBAR();
        }

        public void FClickTV(object sender, RoutedEventArgs e)
        {
            Travel();
            IMGPM.Source = (ImageSource)FindResource("FRST");
        }   

        public void SClickTV(object sender, RoutedEventArgs e)
        {
            Travel();
            IMGPM.Source = (ImageSource)FindResource("SWMP");
        }

        public void MClickTV(object sender, RoutedEventArgs e)
        {
            Travel();
            IMGPM.Source = (ImageSource)FindResource("MNTN");
        }

        public void CClickTV(object sender, RoutedEventArgs e)
        {
            Travel();
            IMGPM.Source = (ImageSource)FindResource("CVMN");
        }

        public void TClickTV(object sender, RoutedEventArgs e)
        {
            Travel();
            IMGPM.Source = (ImageSource)FindResource("TWNN");
        }
        public void SSClickTV(object sender, RoutedEventArgs e)
        {
            Travel();
            IMGPM.Source = (ImageSource)FindResource("SWMP");
        }
        public void MMClickTV(object sender, RoutedEventArgs e)
        {
            Travel();
            IMGPM.Source = (ImageSource)FindResource("SWMP");
        }
        public void GGClickTV(object sender, RoutedEventArgs e)
        {
            Travel();
            IMGPM.Source = (ImageSource)FindResource("SWMP");
        }
        private void InventoryClick(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2(NameGG,MainPlayer);  
            window2.Show();
            MainPlayer = window2.GetPalyer();

        }
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            if (Exit.IsChecked == true)
            {
                SaveChanges();
                Close();
            }
        }
        private void SaveClick(object sender, RoutedEventArgs e)
        {
                SaveChanges();
        }
        private void SaveChanges()
        {
            using (MMORPGBDEntities3 db = new MMORPGBDEntities3())
            {
                foreach (var saveData in db.SaveData)
                {
                    if (saveData.Name == NameGG)
                    {
                        saveData.HP = MainPlayer.HP;
                        saveData.ATK = MainPlayer.ATK;
                        saveData.DEF = MainPlayer.DEF;
                        break;
                    }
                }
                db.SaveChanges();
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            using(MMORPGBDEntities3 db = new MMORPGBDEntities3())
            {
                db.SaveChanges();
            }
            base.OnClosing(e);
        }

        public void Battle(Enemy A, Players B)
        {
            MenuNSTG.IsEnabled = false;
            DispatcherTimer PlayerASPD = new DispatcherTimer();
            DispatcherTimer EnemyASPD = new DispatcherTimer();
            int PSD = (5 - (B.SPD / 100 * 10) + (B.DEF / 100 * 5));
            int ESD = (5 - (A.SPD / 100 * 10) + (A.DEF / 100 * 5));
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
            if(MainEnemy.HP > 0 && MainPlayer.HP > 0)
            {
                Battle(MainEnemy, MainPlayer);
            }
            else if(MainEnemy.HP > 0 && MainPlayer.HP <= 0)
            {
                MessageBox.Show("Mob Won");
                MenuNSTG.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Player Won");
                MenuNSTG.IsEnabled = true;
            }
        }
        public void EATK(object sender, EventArgs e)
        {
            MainPlayer.HP -= (MainEnemy.ATK - MainPlayer.DEF);
            if (MainEnemy.HP > 0 && MainPlayer.HP > 0)
            {
                Battle(MainEnemy, MainPlayer);
            }
            else if (MainEnemy.HP > 0 && MainPlayer.HP <= 0)
            {
                MessageBox.Show("Mob Won");
            }
            else
            {
                MessageBox.Show("Player Won");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"HP:{MainPlayer.HP}\nATK:{MainPlayer.ATK}\nDEF:{MainPlayer.DEF}\nSPD:{MainPlayer.SPD}", "Stats", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
