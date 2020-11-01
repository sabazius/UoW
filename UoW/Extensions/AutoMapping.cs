using AutoMapper;
using UoW.Models.Contracts.Requests;
using UoW.Models.Contracts.Responses;
using UoW.Models.Tasks;

namespace UoW.Models.Common
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SprintRequest, Sprint>();
            CreateMap<Sprint, SprintResponse>();
        }
    }
}
