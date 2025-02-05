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
        public string NameGG {  get; set; }

        Players MainPlayer;
        Enemy MainEnemy;
        public void LOADER()
        {
            using (MMORPGBDEntities3 db = new MMORPGBDEntities3())
            {
                SaveData saveData = ((SaveData)(from savedata in db.SaveData where savedata.Name == NameGG select savedata));
                MainPlayer.Name = saveData.Name;
                MainPlayer.ATK = saveData.ATK;
                MainPlayer.DEF = saveData.DEF;
                MainPlayer.HP = saveData.HP;

            }
        }
        public Window1()
        {
            InitializeComponent();
        }

        public void Travel()
        {
            DispatcherTimer timeL = new DispatcherTimer();
            DispatcherTimer timerV = new DispatcherTimer();
            DispatcherTimer TTick = new DispatcherTimer();
            timeL.Tick += TimerTickFail;
            timerV.Tick += TimerTickSuccess;
            Random R1 = new Random();
            Random R2 = new Random();
            int TT1 = R1.Next(3,10);
            int TT2 = R2.Next(5,10);
            timeL.Interval = TimeSpan.FromSeconds(TT1);
            timerV.Interval = TimeSpan.FromSeconds(TT2);
            TTick.Interval = TimeSpan.FromSeconds(0);
            if (TT1 > TT2)
            {
                timeL.Start();
            }
            else if (TT2 > TT1)
            {
                timerV.Start();
            }
            else
            {
                timerV.Start();
            }
                TTick.Start();
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
            MessageBox.Show("Battle");
            Battle(MainEnemy, MainPlayer);
        }
        private void TimerTickSuccess(object sender, EventArgs e)
        {
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
        public void InventoryClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(NameGG);
            Window2 window2 = new Window2(NameGG);
            window2.Show();
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
