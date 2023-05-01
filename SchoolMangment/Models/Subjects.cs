using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace SchoolMangment.Models
{
    public class Subjects
    {
        private DateOnly year;

        public int Id { get; set; }
        [Required]

        [ForeignKey("DeptID")]
        public int DepartmentsId { get; set; }
        public Departments? Departments { get; set; }

        [Required]
        public string Name { get; set; }

       
        public int MinimumDegree { get; set; }

      
        public int Term { get; set; }

        public int Year { get; set; }

        public ICollection<SubjectLectures> SubjectLectures { get; set; }

        public ICollection<Exams> Exams { get; set; }

    }
}
