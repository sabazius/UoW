using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using UoW.Models.Tasks;

namespace UoW.DAL.InMemoryDB
{
    public static class InMemoryDB
    {
        public static List<Story> Stories { get; set } = new List<Story>();
        public static void Init()
        {
            Story.Add(new Story
            {
                Name = "test name",
                Description = " ",
                EndDate = DateTime.Now.Add(5),
                StartDate = DateTime.Now,
                ProjectID = 12

            }) ;
        }
    }}
