using System.ComponentModel.DataAnnotations;

namespace SchoolMangment.Dtos
{
    public class StudentDto
    {
        [Required]
        public string FirsName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DeptId { get; set; }
    }
}
