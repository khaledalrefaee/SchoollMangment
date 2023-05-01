using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMangment.Models
{
    public class Students
    {
        public int Id { get; set; }
        [Required]
        public string FirsName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterDate { get;  }=DateTime.Now;


        [ForeignKey("DeptID")]
        public int DepartmentsId { get; set; }
        public  Departments? Departments { get; set; }


        public ICollection<StudentMarks> StudentMarks { get; set; }

    }
}
