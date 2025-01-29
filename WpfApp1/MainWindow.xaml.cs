using System;
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
using System.Xml.Linq;


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
            using (Database1Entities2 db = new Database1Entities2())
            {
                var log = db.Player.FirstOrDefault(p => p.NameLog == UserName.Text);
                var pas = db.Player.FirstOrDefault(p => p.Password == Password.Text);
                if (log != null && pas != null)
                {
                    MessageBox.Show("Вход на сервер ", "Успех", MessageBoxButton.OK, MessageBoxImage.None);
                }
                else
                {
                    MessageBox.Show("Такого логина или пароля нет ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
