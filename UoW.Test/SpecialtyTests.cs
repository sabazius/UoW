using AutoMapper;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.Controllers;
using UoW.Models.Users;
using Xunit;

namespace UoW.Test
{
    public class SpecialtyTests
    {
        private IMapper _mapper;
      
        public SpecialtyTests()
        {
            var mockMapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapper());
            });
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public async Task Specialty_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 1;
            var mockedService = new Mock<ISpecialtyService>();

            mockedService.Setup(x => x.GetAll())
                .Returns(Task.FromResult(GetAllSpecialties().AsEnumerable()));
            var controller = new SpecialtyController
        }

        private List<Speciality> GetAllSpecialties()
        {
            return new List<Speciality>()
            {
                {new Speciality {FacultyId = 1, Id = 1, LectorId = 23, Name = "test", ShortName = "ts" } }
            };
        }
    }
}
