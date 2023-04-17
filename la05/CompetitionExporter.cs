using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace la05
{
    public class CompetitionExporter : ICompetitionExporterService
    {
        public void SaveToJson(ICollection<Sportsman> competition, string title, string date)
        {
            string path = $"{title}-{date}.json";
            
            var json = JsonConvert.SerializeObject(notes);
            File.WriteAllText(path, json);
        }
    }
}
