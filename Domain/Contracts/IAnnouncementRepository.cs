using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IAnnouncementRepository
    {
        Task AddAsync(Announcement obj);
        Task<int> SaveChangesAsync();
        Task FisicRemove(Announcement obj);
        Task<Announcement> GetById(int id);
        Task UpDateAsync(Announcement obj);
    }
}
