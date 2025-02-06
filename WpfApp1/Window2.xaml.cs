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
using MainClasses;
using System.Diagnostics.Eventing.Reader;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public string NameGG { get; set; }
        public Players players { get; set; }
        private int IdDataSave {  get; set; }
        public Window2(string Namegg, Players players)
        {
            this.NameGG = Namegg;
            this.players = players;
            InitializeComponent();
            ItemsPrint();
        }
        public Players GetPalyer()
        {
            return players;
        }

        public void ItemsPrint()
        {
            using (MMORPGBDEntities3 db = new MMORPGBDEntities3())
            {
                Player player = new Player();
                foreach (var players in db.Player)
                {
                    if (players.Login == NameGG)
                    {
                        player.IdSaveData = players.IdSaveData;
                        IdDataSave = Convert.ToInt32(players.IdSaveData);
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
            using (MMORPGBDEntities3 db = new MMORPGBDEntities3())
            {
                Window Window = new MainWindow();
                if (listbox1.SelectedItem != null)
                {
                    Inventory it=new Inventory();
                    foreach (Inventory items in db.Inventory)
                    {
                        if (items.Name == listbox1.SelectedItem.ToString()&&items.IdSaveData == IdDataSave)
                        {
                            it = items;
                            foreach (var sd in db.SaveData)
                            {
                                if(sd.Id == IdDataSave)
                                {
                                    switch (items.Type.ToString())
                                    {
                                        case "HP":
                                            {
                                                players.HP += items.Stat;
                                                break;
                                            }
                                        case "ATK":
                                            {
                                                players.ATK += items.Stat;
                                                break;
                                            }
                                        case "DEF":
                                            {
                                                players.DEF += items.Stat;
                                                break;
                                            }
                                    }
                                    listbox1.Items.Remove(items.Name);
                                    break;
                                }
                            }
                            break;                            
                        }
                    }
                    db.Inventory.Remove(it);
                    db.SaveChanges();
                    Close();
                }

                else if (listbox2.SelectedItem != null)
                {
                    foreach (var items in db.Inventory)
                    {
                        if (items.Name == listbox2.SelectedItem.ToString() && items.IdSaveData == IdDataSave)
                        {
                            Inventory it=items;
                            if (items.IsPutOn == false)
                            {
                                foreach (var sd in db.SaveData)
                                {
                                    if (sd.Id == IdDataSave)
                                    {
                                        switch (items.Type.ToString())
                                        {
                                            case "HP":
                                                {
                                                    players.HP += items.Stat;
                                                    items.IsPutOn = true;
                                                    break;
                                                }
                                            case "ATK":
                                                {
                                                    players.ATK += items.Stat;
                                                    items.IsPutOn = true;
                                                    break;
                                                }
                                            case "DEF":
                                                {
                                                    players.DEF += items.Stat;
                                                    items.IsPutOn = true;
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                }
                                it.IsPutOn = true;                             
                                MessageBox.Show($"Вас надели {items.Name}", "z", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                var res = MessageBox.Show("Вы хотите это снять?", "ZOV", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if(res == MessageBoxResult.Yes)
                                {
                                    it.IsPutOn = false;
                                    MessageBox.Show("Вас понял", "z", MessageBoxButton.OK,MessageBoxImage.Information);
                                }
                            }
                            break;
                        }
                    }
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Вы не выбрали ничего", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
