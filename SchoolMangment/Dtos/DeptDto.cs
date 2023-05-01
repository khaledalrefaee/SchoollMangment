using System.ComponentModel.DataAnnotations;

namespace SchoolMangment.Dtos
{
    public class DeptDto
    {
        [Required]
        
        public string Name { get; set; }
    }
}
