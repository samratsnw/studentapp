namespace StudentApp2.DTOs
{
    public class StudentUpsertDto
    {
        public int? StudentID { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Dob { get; set; }
        public string Gender { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
