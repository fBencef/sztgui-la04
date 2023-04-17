using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace la05
{
    public class CompetitionLogic : ICompetitionLogic
    {
        IList<Sportsman> sportsmen;
        IList<Sportsman> competition;
        IDetailViewerService detailViewerService;
        ICompetitionExporterService competitionExporterService;

        public CompetitionLogic(IDetailViewerService viwerService, ICompetitionExporterService exporterService)
        {
            this.detailViewerService = viwerService;
            this.competitionExporterService = exporterService;
        }

        public void SetupCollections(IList<Sportsman> sportsmen, IList<Sportsman> competition)
        {
            this.sportsmen = sportsmen;
            this.competition = competition;
        }

        public void AddToCompetition(Sportsman sportsman)
        {
            competition.Add(sportsman);
        }

        public void ViewDetails(Sportsman sportsman)
        { 
            detailViewerService.ViewDetails(sportsman);
        }
        public void ExportCompetition(IList<Sportsman> competition, string title, string date)
        {
            competitionExporterService.SaveToJson(competition, title, date);
        }

        public void LoadSportsmen()
        {
            sportsmen.Add(new Sportsman("Jack", 75, 70, true, "Club1", 50));
            sportsmen.Add(new Sportsman("Joe", 70, 75, false, "Club1", 60));
            sportsmen.Add(new Sportsman("James", 78, 40, true, "Club3", 52));
        }

    }
}
