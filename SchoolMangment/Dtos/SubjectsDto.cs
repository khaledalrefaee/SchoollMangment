using System.ComponentModel.DataAnnotations;

namespace SchoolMangment.Dtos
{
    public class SubjectsDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int MinimumDegree { get; set; }

        [Required]
        public int Term { get; set; }

        public int Year { get; set; }

        public int DeptId { get; set; }
    }
}
