namespace UoW.Models.Users
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int FacultyId { get; set; }
        public int LectorId { get; set; }
    }
}
