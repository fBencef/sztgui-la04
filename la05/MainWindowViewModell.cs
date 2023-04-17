using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace la05
{
    public class MainWindowViewModell : ObservableRecipient
    {
        ICompetitionLogic logic;

        private Sportsman selectedFromSportmen;
        private Sportsman selectedFromCompetition;
        private string title = "testTitle";
        private string date = "testDate";

        public ObservableCollection<Sportsman> Sportsmen { get; set; }
        public ObservableCollection<Sportsman> InCompetition { get; set; }

        public Sportsman SelectedFromSportsmen
        {
            get { return selectedFromSportmen; }
            set
            {
                SetProperty(ref selectedFromSportmen, value);
                (AddToCompetitionCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public Sportsman SelectedFromCompetition
        {
            get { return selectedFromCompetition; }
            set
            {
                SetProperty(ref selectedFromCompetition, value);
                (ViewDetailsCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public event EventHandler sportsmenChanged;
        public ICommand LoadSportsmenCommand { get; set; }
        public ICommand AddToCompetitionCommand { get; set; }
        public ICommand ViewDetailsCommand { get; set; }
        public ICommand ExportCompetitionCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModell()
            :this(IsInDesignMode ? null : Ioc.Default.GetService<ICompetitionLogic>())
        {
            
        }

        public MainWindowViewModell(ICompetitionLogic logic)
        {
            this.logic = logic;

            Sportsmen = new ObservableCollection<Sportsman>();
            InCompetition = new ObservableCollection<Sportsman>();

            logic.SetupCollections(Sportsmen, InCompetition);

            LoadSportsmenCommand = new RelayCommand(
                () => LoadSportsmen(),
                () => Sportsmen.Count == 0
                );

            AddToCompetitionCommand = new RelayCommand(
                () => logic.AddToCompetition(SelectedFromSportsmen),
                () => SelectedFromSportsmen != null && SelectedFromSportsmen.HasPermit
                );

            ViewDetailsCommand = new RelayCommand(
                () => logic.ViewDetails(SelectedFromCompetition),
                () => SelectedFromCompetition != null
                );

            ExportCompetitionCommand = new RelayCommand(
                () => ExportCompetition(InCompetition, title, date),
                () => true
                );
        }

        private void LoadSportsmen()
        {
            Sportsmen.Add(new Sportsman("Jack", 75, 70, true, "Club1", 50));
            Sportsmen.Add(new Sportsman("Joe", 70, 75, false, "Club1", 60));
            Sportsmen.Add(new Sportsman("James", 78, 40, true, "Club3", 52));
        }

        //Does not work from logic, using this instead
        private void ExportCompetition(ICollection<Sportsman> competition, string title, string date)
        {
            string path = $"{title}-{date}.json";

            MessageBox.Show($"Exported competition as: \"{path}\"");

            var json = JsonConvert.SerializeObject(competition);
            File.WriteAllText(path, json);
        }
    }
}
