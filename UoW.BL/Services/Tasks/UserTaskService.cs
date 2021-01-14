using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Contracts.Requests;
using UoW.Models.Tasks;

namespace UoW.BL.Services.Tasks
{
	public class UserTaskService : IUserTaskService
	{
		IUserTaskRepository _userTaskRepository;
		ITaskTypeRepository _taskTypeRepository;
		IUserRepository _userRepository;
		IStoryRepository _storyRepository;
		ISprintRepository _sprintRepository;
		IProjectRepository _projectRepository;
		ILogger _logger;

		public UserTaskService(IUserTaskRepository userTaskRepository,
							   ITaskTypeRepository taskTypeRepository,
							   IUserRepository userRepository,
							   ISprintRepository sprintRepository,
							   IProjectRepository projectRepository,
							   IStoryRepository storyRepository,
							   ILogger logger)
		{
			_userTaskRepository = userTaskRepository;
			_taskTypeRepository = taskTypeRepository;
			_userRepository = userRepository;
			_storyRepository = storyRepository;
			_sprintRepository = sprintRepository;
			_projectRepository = projectRepository;
			_logger = logger;
		}

		public async Task<UserTask> AddTime(int taskId, int minutes)
		{
			var client = _userTaskRepository.GetClient();

			var task = await _userTaskRepository.GetById(taskId);
			task.MinutesSpended += minutes;

			var story = _storyRepository.GetById(task.StoryId);
			story.MinutesSpended += minutes;

			var sprint = _sprintRepository.GetById(story.SprintId);
			sprint.MinutesSpended += minutes;

			var project = _projectRepository.GetById(story.ProjectId);
			project.MinutesSpended += minutes;

			using (var session = await client.StartSessionAsync())
			{
				// Begin transaction
				session.StartTransaction();

				try
				{
					var result = await _userTaskRepository.Update(task);

					_storyRepository.Update(story);
					_sprintRepository.Update(sprint);
					_projectRepository.Update(project);

					return result;
				}
				catch (Exception)
				{
					_logger.Error("Error updating time spend!");
					session.AbortTransaction();
				}

			}
			return null;
		}

		public async Task<UserTask> Create(UserTask userTask)
		{
			return await _userTaskRepository.Create(userTask);
		}

		public async Task Delete(int userTaskId)
		{
			await _userTaskRepository.Delete(userTaskId);
		}

		public async Task<IEnumerable<UserTask>> GetAll()
		{
			return await _userTaskRepository.GetAll();
		}

		public async Task<UserTask> GetById(int userTaskId)
		{
			return await _userTaskRepository.GetById(userTaskId);
		}

		public async Task<UserTask> Update(UserTask userTask)
		{
			return await _userTaskRepository.Update(userTask);
		}

		public async Task<UserTask> UpdateUserTask(UpdateTaskRequest updateTaskRequest)
		{
			var userTask = await _userTaskRepository.GetById(updateTaskRequest.UserTaskID);
			var taskTypeIsValid = await _taskTypeRepository.GetById(updateTaskRequest.TaskType) != null;
			var validUser = await _userRepository.GetById(updateTaskRequest.AssignedToUserId) != null;

			if (userTask == null)
			{
				return null;
			}

			if (validUser)
			{
				userTask.AssignedToUserID = updateTaskRequest.AssignedToUserId;
			}

			if (taskTypeIsValid)
			{
				userTask.TaskType = updateTaskRequest.TaskType;
			}

			if (updateTaskRequest.Name != userTask.Name)
			{
				var validName = await _userTaskRepository.GetByName(updateTaskRequest.Name) == null;

				if (!validName)
				{
					return null;
				}
				userTask.Name = updateTaskRequest.Name;
			}


			userTask.StartDate = updateTaskRequest.StartDate;
			userTask.EndDate = updateTaskRequest.EndDate;
			userTask.Description = updateTaskRequest.Description;
			userTask.MinutesSpended += updateTaskRequest.MinutesSpend;

			var result = await _userTaskRepository.Update(userTask);

			return result;
		}
	}
}
