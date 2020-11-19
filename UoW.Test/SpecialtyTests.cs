using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.Controllers;
using UoW.Models.Common;
using UoW.Models.Contracts.Responses;
using UoW.Models.Users;
using Xunit;

namespace UoW.Test
{
    public class SpecialtyTests
    {
        private IMapper _mapper;

        public SpecialtyTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
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
            //inject
            var controller = new SpecialtyController(mockedService.Object, _mapper);

            //Act
            var result = await controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var specialties = okObjectResult.Value as IEnumerable<SpecialtyResponse>;
            Assert.NotNull(specialties);
            Assert.Equal(expectedCount, specialties.Count());
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
