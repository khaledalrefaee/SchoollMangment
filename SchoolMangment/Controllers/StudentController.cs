using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolMangment.dbContext;
using SchoolMangment.Dtos;
using SchoolMangment.Models;
using Students = SchoolMangment.Models.Students;

namespace SchoolMangment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        ApplicationDbcontext _context;
        public StudentController(ApplicationDbcontext context)
        {
            _context = context;
        }
        [HttpGet]
        //this method the get all student from db 
        public async Task<IActionResult> getAllStudent()
        {
            //to convert the data from table to list 
            var student = await _context.Students.ToListAsync();
            //check if the depts is empty or not
            if (!student.Any())
            {
                return NotFound();
            }
            return Ok(student);
        }
        //add new dept
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDto dto)
        {
            //to check if there is any prop not vaild 

          
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            if (!_context.Departments.Any(dept => dept.Id == dto.DeptId))
            {
                return NotFound("dept not Found");
            }
            
            var student = new Students
            {
                FirsName = dto.FirsName,
                LastName    =dto.LastName,
                Email   = dto.Email,
                Phone   = dto.Phone,
                DepartmentsId = dto.DeptId,
              
     
            };

            //if there is any execption 
            try
            {
                //to add new dept to the database
                await _context.Students.AddAsync(student);
                //to save the database 
                await _context.SaveChangesAsync();
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateStudent(StudentDto dto, int id)
        {

            var student = await _context.Students.FindAsync(id);
            //_context.Departments.Where(dept=> dept.Id==id && dept.Name=="programming")
            //to check if the dept is exiting or not 
            if (student == null)
            {
                return NotFound("the Student is not found ");
            }
            if (!_context.Departments.Any(dept => dept.Id == dto.DeptId))
            {
                return NotFound("dept not Found");
            }

            student.FirsName = dto.FirsName;
            student.LastName = dto.LastName;
            student.Phone  = dto.Phone;
            student.Email  = dto.Email;
            student.DepartmentsId = dto.DeptId;
            
            try
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //to delete a dept from Student table
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null)
            {
                return NotFound();
            }
            try
            {
                _context.Remove(student);
                await _context.SaveChangesAsync();
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
