using AutoMapper;
using UoW.Models.Contracts.Requests;
using UoW.Models.Contracts.Responses;
using UoW.Models.Tasks;
using UoW.Models.Users;

namespace UoW.Models.Common
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SpecialtyRequest, Speciality>();
            CreateMap<SpecialtyResponse, Speciality>();
            CreateMap<SprintRequest, Sprint>();
            CreateMap<SprintResponse, Sprint>();
            CreateMap<UserPositionRequest, UserPosition>();
            CreateMap<UserPositionResponse, UserPosition>();
        }
    }
}
