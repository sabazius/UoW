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
            CreateMap<SpecialtyRequest, Specialty>().ReverseMap();
            CreateMap<SpecialtyResponse, Specialty>().ReverseMap();
            CreateMap<SprintRequest, Sprint>();
            CreateMap<SprintResponse, Sprint>();
            CreateMap<UserPositionRequest, UserPosition>().ReverseMap();
            CreateMap<UserPositionResponse, UserPosition>().ReverseMap();
            CreateMap<IEnumerable<UserPositionResponse>, IEnumerable<UserPosition>>();
            CreateMap<IEnumerable<SpecialtyResponse>, IEnumerable<Specialty>>();
            CreateMap<LectorResponse, Lector>().ReverseMap();
            CreateMap<LectorRequest, Lector>().ReverseMap();
            CreateMap<IEnumerable<LectorResponse>, IEnumerable<Lector>>();
        }
    }
}
