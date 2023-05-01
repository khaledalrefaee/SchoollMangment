using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMangment.Models
{
    public class SubjectLectures
    {

        public int Id { get; set; }
        [Required]


        [ForeignKey("SubjectsId")]
        public int SubjectsId { get; set; }
        public Subjects? Subjects { get; set; }


        public string Title { get; set; }

        [MaxLength(255)]
        public string Content { get; set; }
        
    }
}
