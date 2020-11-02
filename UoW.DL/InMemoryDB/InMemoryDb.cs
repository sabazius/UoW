using UoW.Models.Tasks;
using UoW.Models.Users;
using System;
using System.Collections.Generic;

namespace UoW.DL.InMemoryDB
{
    public static class InMemoryDb
    {
        public static List<UserTask> UserTasks { get; set; } = new List<UserTask>();
        public static List<User> Users  { get; set; } = new List<User>();
        public static List<Story> Stories { get; set; } = new List<Story>();
        public static List<Team> Teams { get; set; } = new List<Team>();
        public static List<Faculty> Faculties { get; set; } = new List<Faculty>();
        public static List<Lector> Lectors { get; set; } = new List<Lector>();
        public static List<Speciality> Specialties { get; set; } = new List<Speciality>();
        public static List<Project> Projects { get; set; } = new List<Project>();
        public static List<Sprint> Sprints { get; set; } = new List<Sprint>();
        public static List<TaskType> TaskTypes { get; set; } = new List<TaskType>();

        public static List<UserPosition> UserPositions { get; set; } = new List<UserPosition>();

        public static void Init()
        {
            Specialties.Add(new Speciality
            {
                FacultyId = 123,
                Id = 2,
                LectorId = 321,
                Name = "Telecommunications and Information Systems",
                ShortName = "TIS"
            });
            Specialties.Add(new Speciality
            {
                FacultyId = 124,
                Id = 1,
                LectorId = 213,
                Name = "Software Engineer",
                ShortName = "SE"
            });
            Users.Add(new User
            {
                Id = 1,
                FacultylID = 123,
                Name = "Boris",
                Email = "boris@UoW.com",
                TeamID = 12
            });

            Users.Add(new User
            {
                Id = 2,
                FacultylID = 456,
                Name = "Stefan",
                Email = "stefan@UoW.com",
                TeamID = 12
            });

            //Initi Story
            Stories.Add(new Story 
            {
                Id = 55,
                Name = "Controlers Story",
                Description = "Create all required controlers",
                EndDate = new DateTime(2020, 12, 23),
                ProjectId = 2,
                StartDate = DateTime.Now
            });

            //Inti faculties

            Faculties.Add(new Faculty()
            {
                Id = 1,
                Name = "Physico-technological faculty",
                Description = "We are the best",
                ShortName = "PTF"
            });

            //Init Teams
            Teams.Add(new Team
            {
                Id = 43,
                Name = "Team A",
                FacultyID = 1,
                DateCreated = new DateTime(2019,10,01)
            });

            Teams.Add(new Team
            {
                Id = 44,
                Name = "Team B",
                FacultyID = 1,
                DateCreated = new DateTime(2019, 10, 01)
            });

            //Init User Taks
            UserTasks.Add(new UserTask
            {
                Id = 23,
                AssignedToUserID = 2,
                Description = "Task Description",
                EndDate = new DateTime(2020, 11, 23),
                Name = "Create Controlers",
                OwnerId = 1,
                StartDate = DateTime.Now,
                StoryId = 55
            });

            Sprints.Add(new Sprint
            {
                Description = "Description",
                EndDate = DateTime.Now.AddDays(5),
                Id = 133,
                Name = "Sprint name",
                StartDate = DateTime.Now,
                TeamID = 1
            });
            Lectors.Add(new Lector
            {
                Id = 24,
                FirstName = "Vladimir",
                LastName = "Sovniov",
                DateStarted = new DateTime(2018, 10, 12)
            });

            Projects.Add(new Project
            {
                Description = "Project description",
                Id = 4322,
                Name = "Some project name",
                OwnerId = 2
            });

            //User positions
            UserPositions.Add(new UserPosition
            {
                Id = 1,
                PositionName = "Junior Developer",
                Description = "Begginer C# developer"
            });
            UserPositions.Add(new UserPosition
            {
                Id = 2,
                PositionName = "Middle Developer",
                Description = "Experienced C# developer"
            });
            UserPositions.Add(new UserPosition
            {
                Id = 3,
                PositionName = "Senior Developer",
                Description = "Very experienced C# developer"
            });
        }

    }
}
