using Microsoft.EntityFrameworkCore;
using SchoolMangment.Models;

namespace SchoolMangment.dbContext
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext>options):base(options)
        {
                
        }
      
        public DbSet<StudentMarks> StudentMarks { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Subjects> Subjects { get; set; }

        public DbSet<Students> Students { get; set; }

        public DbSet<SubjectLectures> SubjectLectures { get; set; }

        public DbSet<Exams> Exams { get; set; }
    
    }
}
