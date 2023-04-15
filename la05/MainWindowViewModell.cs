﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    public class MainWindowViewModell : ObservableRecipient
    {

        private Sportsman selectedFromSportmen;
        private Sportsman selectedFromCompetition;

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

        public MainWindowViewModell()
        {
            Sportsmen = new ObservableCollection<Sportsman>();
            InCompetition = new ObservableCollection<Sportsman>();

            LoadSportsmenCommand = new RelayCommand(
                () => LoadSportsmen(),
                () => Sportsmen.Count == 0
                );

            AddToCompetitionCommand = new RelayCommand(
                () => InCompetition.Add(SelectedFromSportsmen.GetCopy()),
                () => SelectedFromSportsmen != null
                );

            ViewDetailsCommand = new RelayCommand(
                () => Sportsmen.Add(null),
                () => SelectedFromCompetition != null
                );
        }

        private void LoadSportsmen()
        {
            Sportsmen.Add(new Sportsman("Jack", 75, 70, true, "Club1", 50));
            Sportsmen.Add(new Sportsman("Joe", 70, 75, false, "Club1", 60));
            Sportsmen.Add(new Sportsman("James", 78, 40, true, "Club3", 52));
        }
    }
}
