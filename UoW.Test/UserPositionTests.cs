using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.BL.Services.Users;
using UoW.Controllers.Users;
using UoW.DL.Interfaces.Users;
using UoW.Models.Common;
using UoW.Models.Contracts.Requests;
using UoW.Models.Contracts.Responses;
using UoW.Models.Users;
using Xunit;

namespace UoW.Test
{
	public class UserPositionTests
	{
		private IMapper _mapper;
		private Mock<IUserPositionRepository> _userPositionRepository;
		private IUserPositionService _userPositionService;
		private UserPositionController _controller;

		IList<UserPosition> _userPositions = new List<UserPosition>()
			{
				{ new UserPosition { Id = 1, Description = "Test Description", PositionName = "Position 1" } },
				{ new UserPosition { Id = 2, Description = "Another Test Description", PositionName = "Position 2" } },
			};

		public UserPositionTests()
		{
			var mockMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapping());
			});

			_mapper = mockMapper.CreateMapper();

			_userPositionRepository = new Mock<IUserPositionRepository>();

			
			_userPositionService = new UserPositionService(_userPositionRepository.Object);

			//inject
			_controller = new UserPositionController(_userPositionService, _mapper);
		}

		[Fact]
		public async Task UserPosition_GetAll_Count_Check()
		{
			//setup
			var expectedCount = 2;

			_userPositionRepository.Setup(x => x.GetAll())
				.ReturnsAsync(_userPositions);

			//Act
			var result = await _controller.GetAll();

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var positions = okObjectResult.Value as IEnumerable<UserPositionResponse>;
			Assert.NotNull(positions);
			Assert.Equal(expectedCount, positions.Count());
		}

		[Fact]
		public async Task UserPosition_GetById_NameCheck()
		{
			//setup
			var userPositionId = 2;
			var expectedName = "Position 2";
			var expectedDescription = "Another Test Description";

			_userPositionRepository.Setup(x => x.GetById(userPositionId))
				.ReturnsAsync(_userPositions.FirstOrDefault(x => x.Id == userPositionId));

			//Act
			var result = await _controller.GetUserPosition(userPositionId);

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var position = okObjectResult.Value as UserPositionResponse;
			Assert.NotNull(position);
			Assert.Equal(expectedName, position.PositionName);
			Assert.Equal(expectedDescription, position.Description);
		}

		[Fact]
		public async Task UserPosition_GetById_NotFound()
		{
			//setup
			var userPositionId = 3;

			_userPositionRepository.Setup(x => x.GetById(userPositionId))
				.ReturnsAsync(_userPositions.FirstOrDefault(x => x.Id == userPositionId));

			//Act
			var result = await _controller.GetUserPosition(userPositionId);

			//Assert
			var notFoundObjectResult = result as NotFoundObjectResult;
			Assert.NotNull(notFoundObjectResult);
		}

		[Fact]
		public async Task UserPosition_Update_PositionName()
		{
			//setup
			var userPositionId = 1;
			var expectedPositionName = "New Position Name";

			var position = _userPositions.FirstOrDefault(x => x.Id == userPositionId);
			position.PositionName = expectedPositionName;

			_userPositionRepository.Setup(x => x.Update(position)).ReturnsAsync(_userPositions.FirstOrDefault(x => x.Id == userPositionId));

			//Act
			var result = await _controller.SaveUserPosition(position);

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var pos = okObjectResult.Value as UserPositionResponse;
			Assert.NotNull(pos);
			Assert.Equal(expectedPositionName, pos.PositionName);
		}

		[Fact]
		public async Task UserPosition_Delete_Existing_PositionName()
		{
			//setup
			var userPositionId = 1;

			var position = _userPositions.FirstOrDefault(x => x.Id == userPositionId);


			_userPositionRepository.Setup(x => x.Delete(userPositionId)).Callback( () => _userPositions.Remove(position));

			//Act
			var result = await _controller.DeleteUserPosition(userPositionId);

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			Assert.Null(_userPositions.FirstOrDefault(x => x.Id == userPositionId));
		}

		[Fact]
		public async Task UserPosition_Delete_NotExisting_PositionName()
		{
			//setup
			var userPositionId = 3;

			var position = _userPositions.FirstOrDefault(x => x.Id == userPositionId);


			_userPositionRepository.Setup(x => x.Delete(userPositionId)).Callback(() => _userPositions.Remove(position));

			//Act
			var result = await _controller.DeleteUserPosition(userPositionId);

			//Assert
			var okObjectResult = result as NotFoundObjectResult;
			Assert.NotNull(okObjectResult);

			Assert.Null(_userPositions.FirstOrDefault(x => x.Id == userPositionId));
		}

	}
}
