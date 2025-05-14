// filepath: /Users/user/Documents/GitHub/Tazo/Tazo.Models/Entities/Student.cs
namespace Tazo.Models.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}