using System.Collections.Generic;

namespace la05
{
    public interface ICompetitionLogic
    {
        void AddToCompetition(Sportsman sportsman);
        void ViewDetails(Sportsman sportsman);
        void SetupCollections(IList<Sportsman> sportsmen, IList<Sportsman> competition);
        void ExportCompetition(IList<Sportsman> competition, string title, string date);
    }
}