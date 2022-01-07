using Domain.Contracts;
using Domain.Entities;
using Moq;
using Xunit;

namespace WebMotorsTests.Repositories
{
    public class AnnouncementRepositoryTest
    {
        [Fact(DisplayName = "AddAsync Announcement")]
        public async void AnnouncementRepository_AddNewAnnouncement_Respository_ReturnTask()
        {
            var mockAnnouncementRepository = new Mock<IAnnouncementRepository>();
            var announcement = new Announcement("Fiesta", "1.0", "Flez", 2010, 25000, "Tests");
            await mockAnnouncementRepository.Object.AddAsync(announcement);
            mockAnnouncementRepository.Verify(s => s.AddAsync(announcement), Times.Once());
        }

        [Fact(DisplayName = "UpdateAsync Announcement")]
        public async void AnnouncementRepository_UpdateAsync_Respository_ReturnTask()
        {
            var mockAnnouncementRepository = new Mock<IAnnouncementRepository>();

            var announcement = new Announcement();
            var announcementUpdated = announcement.Update("Fiesta", "1.0", "Flez", 2010, 25000, "Tests");

            await mockAnnouncementRepository.Object.UpDateAsync(announcementUpdated);
            mockAnnouncementRepository.Verify(s => s.UpDateAsync(announcementUpdated), Times.Once());
        }

        [Fact(DisplayName = "DeleteAsync Announcement")]
        public async void AnnouncementRepository_DeleteAsync_Respository_ReturnTask()
        {
            var mockAnnouncementRepository = new Mock<IAnnouncementRepository>();

            var announcement = new Announcement("Fiesta", "1.0", "Flez", 2010, 25000, "Tests");

            await mockAnnouncementRepository.Object.FisicRemove(announcement);
            mockAnnouncementRepository.Verify(s => s.FisicRemove(announcement), Times.Once());
        }
    }
}
