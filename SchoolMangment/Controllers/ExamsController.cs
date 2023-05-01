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
    public class ExamsController : ControllerBase
    {
        ApplicationDbcontext _context;
        public ExamsController(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        //this method the get all student from db 
        public async Task<IActionResult> getAllExams()
        {
            //to convert the data from table to list 
            var exams = await _context.Exams.Select(e => new
            {
                e.Id,
                e.Term,
                e.SubjectsId,
                e.DateOnly // اسم الخاصية هنا هو DateOnly
            }).ToListAsync();

            //check if the depts is empty or not
            if (!exams.Any())
            {
                return NotFound();
            }
            return Ok(exams);
        }


        [HttpPost]
        public async Task<IActionResult> AddExamsDto(ExamsDto dto)
        {
            //to check if there is any prop not vaild 


            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            if (!_context.Subjects.Any(dept => dept.Id == dto.SubjID))
            {
                return NotFound("Subjects not Found");
            }

            var Exams = new Exams
            {
                Date = dto.Date,
                Term = dto.Term,
                SubjectsId = dto.SubjID,
            };

            //if there is any execption 
            try
            {
                //to add new dept to the database
                await _context.Exams.AddAsync(Exams);
                //to save the database 
                await _context.SaveChangesAsync();
                return Ok(Exams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateExams(ExamsDto dto, int id)
        {

            var Exams = await _context.Exams.FindAsync(id);
            //_context.Departments.Where(dept=> dept.Id==id && dept.Name=="programming")
            //to check if the dept is exiting or not 
            if (Exams == null)
            {
                return NotFound("the Exams is not found ");
            }
            if (!_context.Subjects.Any(dept => dept.Id == dto.SubjID))
            {
                return NotFound("Subjects not Found");
            }

            Exams.Date = dto.Date;
            Exams.Term = dto.Term;

            Exams.SubjectsId = dto.SubjID;

            try
            {
                _context.Update(Exams);
                await _context.SaveChangesAsync();
                return Ok(Exams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //to delete a dept from dept table
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteExams(int id)
        {
            var Exams = await _context.Exams.FindAsync(id);
            if (Exams is null)
            {
                return NotFound();
            }
            try
            {
                _context.Remove(Exams);
                await _context.SaveChangesAsync();
                return Ok(Exams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
