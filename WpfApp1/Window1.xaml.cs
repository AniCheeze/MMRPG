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

namespace WpfApp11
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
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
            if(PG1.Value < TT2)
            {
                TTick.Start();
            }
            PG1.Maximum = TT2;
            PG1.Minimum = 0;
            PG1.Value = 0;
            PG1.Visibility = Visibility.Visible;
        }

        public void PRGBAR()
        {
            while (PG1.Value < PG1.Maximum)
            {
                PG1.Value += 1;
            }
        }

        private void TimerTickFail(object sender, EventArgs e)
        {
            MessageBox.Show("Battle");
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
            
        }

        public void SClickTV(object sender, RoutedEventArgs e)
        {

        }

        public void MClickTV(object sender, RoutedEventArgs e)
        {

        }

        public void CClickTV(object sender, RoutedEventArgs e)
        {

        }

        public void TClickTV(object sender, RoutedEventArgs e)
        {

        }
        public void SSClickTV(object sender, RoutedEventArgs e)
        {

        }
        public void MMClickTV(object sender, RoutedEventArgs e)
        {

        }
        public void GGClickTV(object sender, RoutedEventArgs e)
        {

        }
    }
}
