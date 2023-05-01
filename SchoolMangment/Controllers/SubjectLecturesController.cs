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
    public class SubjectLecturesController : ControllerBase
    {
        ApplicationDbcontext _context;
        public SubjectLecturesController(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]

        //this method the get all student from db 
        public async Task<IActionResult> getAllSubjectLectures()
        {
            //to convert the data from table to list 
            var subjectlectures = await _context.SubjectLectures.ToListAsync();
            //check if the depts is empty or not
            if (!subjectlectures.Any())
            {
                return NotFound();
            }
            return Ok(subjectlectures);
        }

        //add new dept
        [HttpPost]
        public async Task<IActionResult> AddSubjectLectures(SubjectLecturesDto dto)
        {
            //to check if there is any prop not vaild 


            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            if (!_context.Subjects.Any(dept => dept.Id == dto.SubjId))
            {
                return NotFound(" Subjects not Found");
            }

            var subjectLectures = new SubjectLectures
            {

                Content = dto.Content,
                Title = dto.Title,
                SubjectsId = dto.SubjId,

            };

            //if there is any execption 
            try
            {
                //to add new dept to the database
                await _context.SubjectLectures.AddAsync(subjectLectures);
                //to save the database 
                await _context.SaveChangesAsync();
                return Ok(subjectLectures);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateSubjectLectures(SubjectLecturesDto dto, int id)
        {

            var SubjectLectures = await _context.SubjectLectures.FindAsync(id);
            //_context.Departments.Where(dept=> dept.Id==id && dept.Name=="programming")
            //to check if the dept is exiting or not 
            if (SubjectLectures == null)
            {
                return NotFound("the Subject is not found ");
            }
            if (!_context.Subjects.Any(dept => dept.Id == dto.SubjId))
            {
                return NotFound("dept not Found");
            }

            SubjectLectures.Content = dto.Content;
            SubjectLectures.Title = dto.Title;
            SubjectLectures.SubjectsId = dto.SubjId;


            try
            {
                _context.Update(SubjectLectures);
                await _context.SaveChangesAsync();
                return Ok(SubjectLectures);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteSubjectLectures(int id)
        {
            var SubjectLectures = await _context.SubjectLectures.FindAsync(id);
            if (SubjectLectures is null)
            {
                return NotFound();
            }
            try
            {
                _context.Remove(SubjectLectures);
                await _context.SaveChangesAsync();
                return Ok(SubjectLectures);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
