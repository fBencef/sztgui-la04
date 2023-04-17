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
using System.Windows.Shapes;

namespace la05
{
    /// <summary>
    /// Interaction logic for DetailViewer.xaml
    /// </summary>
    public partial class DetailViewerWindow : Window
    {
        
        public DetailViewerWindow(Sportsman sportsman)
        {
            InitializeComponent();
            
            label_name_number.Content = $"{sportsman.Name} - {sportsman.Number}";
            label_club.Content = $"Egyesület: {sportsman.Club}";
            label_permit.Content = $"Engedély: {PermitToStringConverter.Convert(sportsman.HasPermit)}";
            label_personalBest.Content = $"Egyéni csúcs: {sportsman.PersonalBest}";
            label_annualBest.Content = $"Éves csúcs: {sportsman.AnnualBest}";
        }
    }
}
