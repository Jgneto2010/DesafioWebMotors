using Domain.Contracts;
using Moq;
using Service.Contracts;
using Service.ViewModels.Announcements;
using System.Threading.Tasks;
using Xunit;

namespace WebMotorsTests.Services
{
    public class AnnouncementsServiceTest
    {
        [Fact(DisplayName = "Register new Announcement")]
        public async void AnnouncementsService_RegisterNewAnnouncement_ReturnTrue()
        {
            var mockExternalService = new Mock<IExternalServiceQueryService>();
            var mockAnnouncementRepository = new Mock<IAnnouncementRepository>();

            var mockService = new Mock<IAnnouncementsService>();

            var addAnnouncementViewModel = new AddAnnouncementViewModel
            {
                IdMake = 1,
                IdModel = 1,
                IdVersion = 1,
                Mileage = 250,
                Note = "Teste",
                Year = 2021
            };

            mockService.Setup(s => s.RegisterAd(addAnnouncementViewModel))
                .Returns(Task.FromResult(true));

            var result = await mockService.Object.RegisterAd(addAnnouncementViewModel);

            mockService.Verify(s => s.RegisterAd(addAnnouncementViewModel), Times.Once());

            Assert.True(result);
        }

        [Fact(DisplayName = "Delete announcement")]
        public async void AnnouncementsService_DeleteAnnouncement_ReturnTrue()
        {
            var mockExternalService = new Mock<IExternalServiceQueryService>();
            var mockAnnouncementRepository = new Mock<IAnnouncementRepository>();

            var mockService = new Mock<IAnnouncementsService>();

            mockService.Setup(s => s.Remove(1))
                .Returns(Task.FromResult(true));

            var result = await mockService.Object.Remove(1);

            mockService.Verify(s => s.Remove(1), Times.Once());

            Assert.True(result);
        }

        [Fact(DisplayName = "Update announcement")]
        public async void AnnouncementsService_UpdateAnnouncement_ReturnTrue()
        {
            var mockExternalService = new Mock<IExternalServiceQueryService>();
            var mockAnnouncementRepository = new Mock<IAnnouncementRepository>();

            var mockService = new Mock<IAnnouncementsService>();

            var updateAnnouncementViewModel = new UpDateAnnouncementViewModel
            {
                Id = 1,
                Model = "Fiesta",
                Version = "1.0 Flex",
                Mileage = 250,
                Note = "Teste",
                Year = 2021,
                Make = "Ford"
            };

            mockService.Setup(s => s.Update(updateAnnouncementViewModel))
                .Returns(Task.FromResult(true));

            var result = await mockService.Object.Update(updateAnnouncementViewModel);

            mockService.Verify(s => s.Update(updateAnnouncementViewModel), Times.Once());

            Assert.True(result);
        }
    }
}
