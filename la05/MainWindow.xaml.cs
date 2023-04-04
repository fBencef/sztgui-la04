using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace la05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Ha itt van megvalósítva a collection és a Load (click event), akkor működik a betöltés.
        //View-modelből még nem.
        
        //ObservableCollection<Sportsman> sportsmen = new ObservableCollection<Sportsman>();
        public MainWindow()
        {
            InitializeComponent();
            //listBox_sportsmen.ItemsSource = sportsmen;
        }

        private void button_load_Click(object sender, RoutedEventArgs e)
        {
            //sportsmen.Add(new Sportsman("Jack", 75, 70, true, "Club1", 50));
            //sportsmen.Add(new Sportsman("Jack", 70, 75, false, "Club1", 50));
            //sportsmen.Add(new Sportsman("James", 78, 40, true, "Club3", 52));
        }
    }
}
