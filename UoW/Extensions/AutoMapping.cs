using AutoMapper;
using System.Collections.Generic;
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
            CreateMap<SpecialtyRequest, Speciality>().ReverseMap();
            CreateMap<SpecialtyResponse, Speciality>().ReverseMap();
            CreateMap<SprintRequest, Sprint>();
            CreateMap<SprintResponse, Sprint>();
            CreateMap<UserPositionRequest, UserPosition>().ReverseMap();
            CreateMap<UserPositionResponse, UserPosition>().ReverseMap();
            CreateMap<IEnumerable<UserPositionResponse>, IEnumerable<UserPosition>>();
            CreateMap<IEnumerable<SpecialtyResponse>, IEnumerable<Speciality>>();
        }
    }
}
