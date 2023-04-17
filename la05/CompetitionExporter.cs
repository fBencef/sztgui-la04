using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace la05
{
    public class CompetitionExporter : ICompetitionExporterService
    {
        public void SaveToJson(ICollection<Sportsman> competition, string title, string date)
        {
            string path = $"{title}-{date}.json";

            MessageBox.Show(path);

            var json = JsonConvert.SerializeObject(competition);
            File.WriteAllText(path, json);
        }
    }
}
