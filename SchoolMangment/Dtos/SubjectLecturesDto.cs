using System.ComponentModel.DataAnnotations;

namespace SchoolMangment.Dtos
{
    public class SubjectLecturesDto
    {

        public int SubjId { get; set; }
        public string Title { get; set; }

        [MaxLength(255)]
        public string Content { get; set; }
    }
}
