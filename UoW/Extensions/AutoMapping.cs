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
            CreateMap<IEnumerable<SpecialtyResponse>, IEnumerable<Specialty>>();

            CreateMap<FacultyRequest, Faculty>().ReverseMap();
            CreateMap<FacultyResponse, Faculty>().ReverseMap();
            CreateMap<IEnumerable<FacultyResponse>, IEnumerable<Faculty>>();

            CreateMap<UserRequest, User>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap();
            CreateMap<IEnumerable<UserResponse>, IEnumerable<User>>();
            CreateMap<TeamRequest, Team>().ReverseMap();
            CreateMap<UserTaskRequest, UserTask>().ReverseMap();
            CreateMap<UserResponse, UserTask>().ReverseMap();
            CreateMap<TeamResponse, Team>().ReverseMap();
            CreateMap<IEnumerable<TeamResponse>, IEnumerable<Team>>();
            CreateMap<IEnumerable<UserTaskResponse>, IEnumerable<UserTask>>().ReverseMap();

            CreateMap<SprintRequest, Sprint>();
            CreateMap<SprintResponse, Sprint>();
            CreateMap<TaskTypeRequest, TaskType>().ReverseMap();
            CreateMap<TaskTypeResponse, TaskType>().ReverseMap();
            CreateMap<IEnumerable<TaskTypeResponse>, IEnumerable<TaskType>>();
            CreateMap<UserPositionRequest, UserPosition>().ReverseMap();
            CreateMap<UserPositionResponse, UserPosition>().ReverseMap();
            CreateMap<IEnumerable<UserPositionResponse>, IEnumerable<UserPosition>>();
            CreateMap<LectorResponse, Lector>().ReverseMap();
            CreateMap<LectorRequest, Lector>().ReverseMap();
            CreateMap<IEnumerable<LectorResponse>, IEnumerable<Lector>>();
        }
    }
}
