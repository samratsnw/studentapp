using Microsoft.Identity.Client;

namespace StudentApp2.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public int DepartmentId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime DOB { get; set; }

        public string Gender { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
