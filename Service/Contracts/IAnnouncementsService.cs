using Service.ViewModels.Announcements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAnnouncementsService
    {
        Task<bool> RegisterAd(AddAnnouncementViewModel addAnnouncementViewModel);
        Task<bool> Remove(int id);
        Task<AnnouncementResponse> GetByIdObj(int id);
        Task<bool> Update(UpDateAnnouncementViewModel input);

    }
}
