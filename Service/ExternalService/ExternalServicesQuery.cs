using RestSharp;
using Service.Contracts;
using Service.ViewModels.MakeResponse;
using Service.ViewModels.ModelResponse;
using Service.ViewModels.VersionResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ExternalService
{
    public class ExternalServicesQuery : IExternalServiceQueryService
    {
        private readonly RestClient _client;
        public ExternalServicesQuery()
        {
            _client = new RestClient();
        }

        
        public async Task<IEnumerable<MakeViewModel>> ConsultMake()
        {
            try
            {
                var request = new RestRequest("https://desafioonline.webmotors.com.br/api/OnlineChallenge/Make");
                var result = await _client.GetAsync<IEnumerable<MakeViewModel>>(request);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public async Task<IEnumerable<ModelViewModel>> ConsultModel(int id)
        {
            try
            {
                var request = new RestRequest($"https://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID={id}");
                var result = await _client.GetAsync<IEnumerable<ModelViewModel>>(request);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
        public async Task<IEnumerable<VersionViewModel>> ConsultVersion(int id)
        {
            try
            {
                var request = new RestRequest($"https://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID={id}");
                var result = await _client.GetAsync<IEnumerable<VersionViewModel>>(request);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
