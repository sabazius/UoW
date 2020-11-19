using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.Controllers.Users;
using UoW.Models.Common;
using UoW.Models.Users;
using Xunit;

namespace UoW.Test
{
    public class LectorPositionTest
    {
        public LectorPositionTest()
        {
            var nockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());

            });

        }


        [Fact]
        public async Task UserPostion_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var nockedService = new Mock<ILectorService>();

            nockedService.Setup(x => x.GetAll())
                .Returns(Task.FromResult(GetAllLectorPosition().AsEnumerable()));

            //inject
            var controller = new LectorsController(nockedService.Object);

             //Act
            var result = await controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var position = okObjectResult.Value as IEnumerable<Lector>;

            Assert.NotNull(position);
            Assert.Equal(expectedCount, position.Count());
        }

        private List<Lector> GetAllLectorPosition()
        {
            return new List<Lector>()
            {
                { new Lector {Id = 1,DateStarted=DateTime.Now,FacultyId=1,FirstName="georgi",LastName="donev"} },
                { new Lector {Id = 2,DateStarted=DateTime.Now,FacultyId=2,FirstName="ivan",LastName="milev"} }
            };

        }
    }
}

