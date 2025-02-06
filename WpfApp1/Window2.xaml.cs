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
                foreach (var invent in db.Inventory)
                {
                    if (invent.IdSaveData == player.IdSaveData)
                    {
                        foreach (var potion in db.Potion)
                        {
                            if (invent.IdItems == potion.Id)
                            {
                                listbox1.Items.Add(potion.Name);
                            }
                        }
                        foreach (var items in db.Items)
                        {
                            if (invent.IdItems == items.Id)
                            {
                                listbox2.Items.Add(items.Name);
                            }
                        }
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
                    Potion potion1 = new Potion();
                    foreach (var invent in db.Inventory)
                    {
                        if (invent.IdSaveData == IdDataSave)
                        {
                            foreach (var potion in db.Potion)
                            {
                                if (potion.Id == invent.IdPotion)
                                {
                                    potion1 = potion;
                                    foreach (var sd in db.SaveData)
                                    {
                                        if (sd.Id == IdDataSave)
                                        {
                                            switch (potion.Type.ToString())
                                            {
                                                case "HP":
                                                    {
                                                        players.HP += potion.Stat;
                                                        break;
                                                    }
                                                case "ATK":
                                                    {
                                                        players.ATK += potion.Stat;
                                                        break;
                                                    }
                                                case "DEF":
                                                    {
                                                        players.DEF += potion.Stat;
                                                        break;
                                                    }
                                            }
                                            listbox1.Items.Remove(potion.Name);
                                            break;
                                        }
                                    }
                                    break;
                                }
                               
                            }
                            break;
                        }
                    }
                    db.Potion.Remove(potion1);
                    db.SaveChanges();
                    Close();
                }

                else if (listbox2.SelectedItem != null)
                {
                    foreach (var invent in db.Inventory)
                    {
                        if (invent.IdSaveData == IdDataSave)
                        {
                            foreach (var item in db.Items)
                            {
                                if (item.IsPutOn == false && item.Name == listbox2.SelectedItem.ToString())
                                {
                                    foreach (var sd in db.SaveData)
                                    {
                                        if (sd.Id == IdDataSave)
                                        {
                                            switch (item.Type.ToString())
                                            {
                                                case "HP":
                                                    {
                                                        players.HP += item.Stat;
                                                        item.IsPutOn = true;
                                                        break;
                                                    }
                                                case "ATK":
                                                    {
                                                        players.ATK += item.Stat;
                                                        item.IsPutOn = true;
                                                        break;
                                                    }
                                                case "DEF":
                                                    {
                                                        players.DEF += item.Stat;
                                                        item.IsPutOn = true;
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    }
                                    item.IsPutOn = true;
                                    MessageBox.Show($"Вас надели {item.Name}", "z", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else if(item.IsPutOn == true && item.Name == listbox2.SelectedItem.ToString())
                                {
                                    var res = MessageBox.Show("Вы хотите это снять?", "ZOV", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                    if (res == MessageBoxResult.Yes)
                                    {

                                        item.IsPutOn = false;
                                        foreach (var sd in db.SaveData)
                                        {
                                            if (sd.Id == IdDataSave)
                                            {
                                                switch (item.Type.ToString())
                                                {
                                                    case "HP":
                                                        {
                                                            players.HP -= item.Stat;
                                                            item.IsPutOn = true;
                                                            break;
                                                        }
                                                    case "ATK":
                                                        {
                                                            players.ATK -= item.Stat;
                                                            item.IsPutOn = true;
                                                            break;
                                                        }
                                                    case "DEF":
                                                        {
                                                            players.DEF -= item.Stat;
                                                            item.IsPutOn = true;
                                                            break;
                                                        }
                                                }
                                                break;
                                            }
                                        }
                                        item.IsPutOn = false;
                                        MessageBox.Show("Вас понял", "z", MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
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
