using Domain.Contracts;
using Domain.Entities;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly WebMotorsContext _context;
        protected readonly DbSet<Announcement> DbSet;

        public AnnouncementRepository(WebMotorsContext context)
        {
            DbSet = context.Set<Announcement>();
            _context = context;
        }

        public async Task AddAsync(Announcement obj) => await DbSet.AddAsync(obj);
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        public async Task<Announcement> GetById(int id) => await DbSet.Where(c => c.Id == id).FirstOrDefaultAsync();

        public async Task FisicRemove(Announcement obj)
        {
            DbSet.Remove(obj);
            await Task.CompletedTask;
        }

        public async Task UpDateAsync(Announcement obj)
        {
            DbSet.Update(obj);
            await Task.CompletedTask;
        }
    }
}
