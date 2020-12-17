using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.BL.Services.Users;
using UoW.Controllers.Users;
using UoW.DL.Interfaces.Users;
using UoW.Models.Common;
using UoW.Models.Users;
using Xunit;

namespace UoW.Test
{
    public class LectorTest
    {
        private IMapper _mapper;
        private Mock<ILectorRepository> _lectorRepository;
        private LectorsController _lectorContoller;
        private ILectorService _ilectorService;
        private Mock<IFacultyRepository> _facultyRepository;


        IList<Lector> _lectors = new List<Lector>()
        {
             { new Lector {Id = 1,DateStarted=DateTime.Now,FacultyId=1,FirstName="georgi",LastName="donev"} },
             { new Lector {Id = 2,DateStarted=DateTime.Now,FacultyId=2,FirstName="ivan",LastName="milev"} }
        };
        public LectorTest()
        {
            var nockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());

            });

            _mapper = nockMapper.CreateMapper();

            _facultyRepository = new Mock<IFacultyRepository>();

            _lectorRepository = new Mock<ILectorRepository>();
            _ilectorService = new LectorService(_lectorRepository.Object, _facultyRepository.Object);
        }


        [Fact]
        public async Task UserPostion_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var nockedService = new Mock<ILectorService>();

            nockedService.Setup(x => x.GetAll())
                .ReturnsAsync(_lectors);

            //inject
            var controller = new LectorsController(nockedService.Object, _mapper);

             //Act
            var result = await controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var position = okObjectResult.Value as IEnumerable<Lector>;

            Assert.NotNull(position);
            Assert.Equal(expectedCount, position.Count());
        }

        [Fact]
        public async Task Lector_GetById_NameCheck()
        {
            //setup
            var LectorId = 2;
            var expectedName = "ivan";

            _lectorRepository.Setup(x => x.GetById(LectorId))
                .ReturnsAsync(_lectors.FirstOrDefault(x => x.Id == LectorId));

            //_facultyRepository.Setup(x => x.GetById())
            //   .ReturnsAsync(_lectors.FirstOrDefault(x => x.Id == LectorId));

            var result = await _lectorContoller.GetById(LectorId);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var position = okObjectResult.Value as Lector;

            Assert.NotNull(position);
            Assert.Equal(expectedName, position.FirstName);
        }

        //[Fact]

        //public async Task Lector_Update_PositionName()
        //{
        //    //setup
        //    var lectorId = 1;

        //    var position = _lector.FirstOrDefault(x => x.Id == LectorId));
        //    position.PositionName = "New Position Name";

        //    _lectorRepository.Setup(x => x.Update(position))
        //        .ReturnsAsync(_lectorPosition.FirstorDefault(x => x.Id == lecotrPosition));

        //    //Act
        //    var result = await _controller.SaveLectorPosition(_mapper.Map<ILectorRequest>(position));

        //    //Assert
        //    var okObjectResult = result as OkObjectResult;
        //    Assert.NotNull(okObjectResult);

        //    var pos = okObjectResult.Value as LectorPosition;
        //    Assert.NotNull(pos);
        //    Assert.Equal(expectedPositionName, pos.PositionName);
        //}
    }
}

