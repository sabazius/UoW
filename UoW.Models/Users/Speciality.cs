namespace UoW.Models.Users
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int FacultyId { get; set; }
        public int LectorId { get; set; }
    }
}
