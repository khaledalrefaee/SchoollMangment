using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMangment.Models
{
    public class StudentMarks
    {

        public int Id { get; set; }

        public int Mark { get; set; }


        [ForeignKey("StudID")]
        public int StudenstId { get; set; }
        public Students? Students { get; set; }


        [ForeignKey("ExamID")]
        public int ExamsId { get; set; }
        public Exams? Exams { get; set; }
      
    }
}
