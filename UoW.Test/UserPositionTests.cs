using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.Controllers.Users;
using UoW.Models.Common;
using UoW.Models.Contracts.Responses;
using UoW.Models.Users;
using Xunit;

namespace UoW.Test
{
	public class UserPositionTests
	{
		private IMapper _mapper;
		public UserPositionTests()
		{
			var mockMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapping());
			});

			_mapper = mockMapper.CreateMapper();
		}

		[Fact]
		public async Task UserPosition_GetAll_Count_Check()
		{
			//setup
			var expectedCount = 2;

			var mockedService = new Mock<IUserPositionService>();

			mockedService.Setup(x => x.GetAll())
				.Returns(Task.FromResult(GetAllTestPositions().AsEnumerable()));
			//inject
			var controller = new UserPositionController(mockedService.Object, _mapper);

			//Act
			var result = await controller.GetAll();

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var positions = okObjectResult.Value as IEnumerable<UserPositionResponse>;
			Assert.NotNull(positions);
			Assert.Equal(expectedCount, positions.Count());
		}

		private List<UserPosition> GetAllTestPositions()
		{
			return new List<UserPosition>()
			{
				{ new UserPosition { Id = 1, Description = "Test Description", PositionName = "Position 1" } },
				{ new UserPosition { Id = 2, Description = "Another Test Description", PositionName = "Position 2" } },
			};
		}

	}
}
