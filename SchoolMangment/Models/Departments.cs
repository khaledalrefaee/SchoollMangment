using System.ComponentModel.DataAnnotations;

namespace SchoolMangment.Models
{
    public class Departments
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public ICollection<Students> Students { get; set; }

       public ICollection<Subjects> Subjects { get; set; }
    }
}
