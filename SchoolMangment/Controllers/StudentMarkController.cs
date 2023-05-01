using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolMangment.dbContext;
using SchoolMangment.Dtos;
using SchoolMangment.Models;

namespace SchoolMangment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentMarkController : ControllerBase
    {
        ApplicationDbcontext _context;
        public StudentMarkController(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        //this method the get  getAllStudentMark from db 
        public async Task<IActionResult> getAllStudentMark()
        {
            //to convert the data from table to list 
            var marks = await _context.StudentMarks.ToListAsync();
            //check if the depts is empty or not
            if (!marks.Any())
            {
                return NotFound("the table is emty");
            }
            return Ok(marks);
        }


        [HttpPost]
        public async Task<IActionResult> AddStudentMark(StudentMarksDto dto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            if (!_context.Exams.Any(Exam => Exam.Id == dto.ExamID))
            {
                return NotFound("Exams not Found");
            }
            //to check if there is any prop not vaild 
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            if (!_context.Students.Any(stu => stu.Id == dto.StudID))
            {
                return NotFound("Student not found");
            }

            var marks = new StudentMarks
            {
                Mark = dto.Mark,
                ExamsId = dto.ExamID,
                StudenstId = dto.StudID,
            };

            //if there is any execption 
            try
            {
                //to add new marks to the database
                await _context.StudentMarks.AddAsync(marks);
                //to save the database 
                await _context.SaveChangesAsync();
                return Ok(marks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateStudentMarck(StudentMarksDto dto, int id)
        {

            var mark = await _context.StudentMarks.FindAsync(id);
            //_context.Departments.Where(dept=> dept.Id==id && dept.Name=="programming")
            //to check if the dept is exiting or not 
            if (mark == null)
            {
                return NotFound("the StudentMarks is not found ");
            }

            if (!_context.Students.Any(Student => Student.Id == dto.StudID))
            {
                return NotFound("Student not Found");
            }

            if (!_context.Exams.Any(Exam => Exam.Id == dto.ExamID))
            {
                return NotFound("Exams not Found");
            }

            mark.Mark = dto.Mark;
            mark.StudenstId = dto.StudID;
            mark.ExamsId = dto.ExamID;

            try
            {
                _context.Update(mark);
                await _context.SaveChangesAsync();
                return Ok(mark);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteStudentMark(int id)
        {
            var mark = await _context.StudentMarks.FindAsync(id);
            if (mark is null)
            {
                return NotFound("the StudentMark Not Fund");
            }
            try
            {
                _context.Remove(mark);
                await _context.SaveChangesAsync();
                return Ok(mark);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

