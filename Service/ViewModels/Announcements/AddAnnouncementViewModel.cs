using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Announcements
{
    public class AddAnnouncementViewModel
    {
        public int IdMake { get; set; }
        public int IdModel { get; set; }
        public int IdVersion { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Note { get; set; }
    }
}
