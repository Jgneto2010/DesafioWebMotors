using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Announcements
{
    public class AnnouncementResponse
    {
        public string Make { get;  set; }
        public string Model { get;  set; }
        public string Version { get;  set; }
        public int Year { get;  set; }
        public int Mileage { get;  set; }
        public string Note { get;  set; }
    }
}
