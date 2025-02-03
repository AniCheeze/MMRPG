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
            listbox1.Items.Add("sdfg");
            listbox1.Items.Add("sdfg");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1");
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("2");
        }
    }
}
