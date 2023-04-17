using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace la05
{
    public class DetailViewerViaWindow : IDetailViewerService
    {
        public void ViewDetails(Sportsman sportsman)
        {
            new DetailViewerWindow(sportsman).ShowDialog();
        }
    }
}
