using Service.ViewModels.MakeResponse;
using Service.ViewModels.ModelResponse;
using Service.ViewModels.VersionResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IExternalServiceQueryService
    {
        Task<IEnumerable<MakeViewModel>> ConsultMake();
        Task<IEnumerable<ModelViewModel>> ConsultModel(int id);
        Task<IEnumerable<VersionViewModel>> ConsultVersion(int id);
    }
}
