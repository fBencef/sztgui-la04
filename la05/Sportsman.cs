using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace la05
{
    public class Sportsman : ObservableObject
    {
        private string name;
        private int personalBest;
        private int annualBest;
        private bool hasPermit;
        private string club;
        private int number;

        public Sportsman()
        {
            
        }
        public Sportsman(string name, int personalBest, int annualBest, bool hasPermit, string club, int number)
        {
            this.name = name;
            this.personalBest = personalBest;
            this.annualBest = annualBest;
            this.hasPermit = hasPermit;
            this.club = club;
            this.number = number;
        }

        public string Name { get => name; set => name = value; }
        public int PersonalBest { get => personalBest; set => personalBest = value; }
        public int AnnualBest { get => annualBest; set => annualBest = value; }
        public bool HasPermit { get => hasPermit; set => hasPermit = value; }
        public string Club { get => club; set => club = value; }
        public int Number { get => number; set => number = value; }
        public int MarketValue { get => personalBest * annualBest; }

        public Sportsman GetCopy()
        {
            return new Sportsman()
            {
                Name = this.Name,
                PersonalBest = this.PersonalBest,
                AnnualBest = this.AnnualBest,
                HasPermit = this.HasPermit,
                Club = this.Club,
                Number = this.Number
            };
    }




    }
}
