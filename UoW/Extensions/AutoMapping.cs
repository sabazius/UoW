using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.Contracts.Requests;
using UoW.Models.Contracts.Responses;
using UoW.Models.Tasks;

namespace UoW.Models.Common
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SpecialtyRequest, Speciality>();
            CreateMap<SpecialtyResponse, Speciality>();
            CreateMap<SprintRequest, Sprint>();
            CreateMap<Sprint, SprintResponse>();
        }
    }
}
