using Service.Contracts;
using Service.ViewModels.Announcements;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;

namespace Service.Services
{
    public class AnnouncementsService : IAnnouncementsService
    {
        private readonly IExternalServiceQueryService _externalServiceQueryService;
        private readonly IAnnouncementRepository _announcementRepository;
        public AnnouncementsService(IExternalServiceQueryService externalServiceQueryService, IAnnouncementRepository announcementRepository)
        {
            _externalServiceQueryService = externalServiceQueryService;
            _announcementRepository = announcementRepository;

        }

        public async Task<bool> RegisterAd(AddAnnouncementViewModel input)
        {
            try
            {
                var resultMake = await _externalServiceQueryService.ConsultMake();
                var objMake = resultMake.First(x => x.Id == input.IdMake);

                var resultModel = await _externalServiceQueryService.ConsultModel(objMake.Id);
                var objModel = resultModel.First(x => x.Id == input.IdModel);

                var resultVersion = await _externalServiceQueryService.ConsultVersion(objModel.Id);
                var objVersion = resultVersion.First(x => x.Id == input.IdVersion);


                var objGeral = new Announcement(objMake.Name, objModel.Name, objVersion.Name, input.Year, input.Mileage, input.Note);


                await _announcementRepository.AddAsync(objGeral);
                await _announcementRepository.SaveChangesAsync();
                return await Task.FromResult(true);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var anuncio = await _announcementRepository.GetById(id);

            await _announcementRepository.FisicRemove(anuncio);
            await _announcementRepository.SaveChangesAsync();
            return await Task.FromResult(true);

        }

        public async Task<AnnouncementResponse> GetByIdObj(int id)
        {
            try
            {
                var anuncio = await _announcementRepository.GetById(id);
                var trt = new AnnouncementResponse()
                {

                    Make = anuncio.Make,
                    Mileage = anuncio.Mileage,
                    Model = anuncio.Model,
                    Note = anuncio.Note,
                    Version = anuncio.Version,
                    Year = anuncio.Year

                };

                return await Task.FromResult(trt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(UpDateAnnouncementViewModel input)
        {
            var anuncio = await _announcementRepository.GetById(input.Id);

            anuncio.Update(input.Make, input.Model, input.Version, input.Year, input.Mileage, input.Note);

            await _announcementRepository.UpDateAsync(anuncio);
            await _announcementRepository.SaveChangesAsync();

            return await Task.FromResult(true);

        }
    }
}
