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
using System.Windows.Shapes;
using WpfApp11;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public string NameGG { get; set; }
        public Window2(string Namegg)
        {
            this.NameGG = Namegg;
            InitializeComponent();
            ItemsPrint();
        }

        public void ItemsPrint()
        {
            MessageBox.Show(NameGG);
            using (MMORPGBDEntities3 db = new MMORPGBDEntities3())
            {
                Player player = new Player();
                foreach (var players in db.Player)
                {
                    if (players.Login == NameGG)
                    {
                        player.IdSaveData = players.IdSaveData;
                    }
                }
                foreach (var items in db.Inventory)
                {
                    if (items.IdSaveData == player.IdSaveData && items.IsArmor == false)
                    {
                        listbox1.Items.Add(items.Name);
                    }
                    else if (items.IdSaveData == player.IdSaveData && items.IsArmor == true)
                    {
                        listbox2.Items.Add(items.Name);
                    }
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window Window = new MainWindow();
            if (listbox1.SelectedItem != null)
            {
                MessageBox.Show("1");
            }
            else if (listbox2.SelectedItem != null)
            {
                
            }
            else
            {
                MessageBox.Show("Вы не выбрали ничего", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
