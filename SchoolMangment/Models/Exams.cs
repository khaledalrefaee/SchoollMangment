using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace SchoolMangment.Models
{
    public class Exams
    {
        private static object vm;

        public int Id { get; set; }
        [Required]


        public string Date { get; set; }

        public DateTime DateOnly
        {
            get
            {

                return DateTime.ParseExact(Date, "dd MM yyyy", CultureInfo.InvariantCulture);
            }
            set
            {
                Date = value.ToString("dd MM yyyy");
            }
        }

        [ForeignKey("SubjID")]
        public int SubjectsId { get; set; }
        public Subjects Subjects { get; set; }
        

        [MaxLength(2)]
        public int Term { get; set; }

        public ICollection<StudentMarks> StudentMarks { get; set; }
    }
}


