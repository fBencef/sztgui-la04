﻿using System.Collections.Generic;

namespace la05
{
    public interface ICompetitionLogic
    {
        void AddToCompetition(Sportsman sportsman);
        void RemoveFromCompetition(Sportsman sportsman);
        void SetupCollections(IList<Sportsman> sportsmen, IList<Sportsman> competition);
    }
}