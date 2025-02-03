using MainClasses;
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
using WpfApp11;


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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (MMORPGBDEntities3 db = new MMORPGBDEntities3())
            {
                var log = db.Player.FirstOrDefault(p => p.Login == UserName.Text);
                var pas = db.Player.FirstOrDefault(p => p.Password == Password.Text);
                if (log != null && pas != null)
                {
                    MessageBox.Show("Вход на сервер ", "Успех", MessageBoxButton.OK, MessageBoxImage.None);
                    Window1 window1 = new Window1();
                    window1.Show();
                    
                }
                else
                {
                    MessageBox.Show("Такого логина или пароля нет ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (MMORPGBDEntities3 db = new MMORPGBDEntities3())
            {
                var log = db.Player.FirstOrDefault(p => p.Login == UserName.Text);
                var pas = db.Player.FirstOrDefault(p => p.Password == Password.Text);
                if (log == null && pas == null)
                {
                    Player player = new Player();
                    SaveData saveData = new SaveData();
                    saveData.Name = UserName.Text;
                    saveData.HP = 100;
                    saveData.ATK = 10;
                    saveData.DEF = 5;
                    db.SaveData.Add(saveData);
                    db.SaveChanges();
                    MessageBox.Show(saveData.Id.ToString());
                    player.Login = UserName.Text;
                    player.Password = Password.Text;
                    player.IdSaveData = saveData.Id;
                    db.Player.Add(player);
                    db.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались", "Гойда!", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window1 window1 = new Window1();
                    window1.Show();
                }
                else
                {
                    MessageBox.Show("Такой логин уже есть", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
