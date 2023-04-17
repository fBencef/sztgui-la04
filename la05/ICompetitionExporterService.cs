using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace la05
{
    public interface ICompetitionExporterService
    {
        void SaveToJson(ICollection<Sportsman> competition, string title, string date);
    }
}
