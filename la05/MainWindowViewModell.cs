using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace la05
{
    public class MainWindowViewModell
    {
        public ObservableCollection<Sportsman> Sportsmen = new ObservableCollection<Sportsman>();
        public int TestValue; //debug

        public event EventHandler sportsmenChanged;
        public event EventHandler testValueChanged; // debug
        public ICommand LoadSportsmenCommand { get; set; }

        public MainWindowViewModell()
        {

            LoadSportsmenCommand = new RelayCommand(
                () => LoadSportsmen()
                );
            TestValue = 0; //debug
            //LoadSportsmen();
        }

        private void LoadSportsmen()
        {
            Sportsmen.Add(new Sportsman("Jack", 75, 70, true, "Club1", 50));
            Sportsmen.Add(new Sportsman("Jack", 70, 75, false, "Club1", 50));
            Sportsmen.Add(new Sportsman("James", 78, 40, true, "Club3", 52));

            TestValue++; //debug

            sportsmenChanged?.Invoke(this, null);
            testValueChanged?.Invoke(this, null); //debug
        }
    }
}
