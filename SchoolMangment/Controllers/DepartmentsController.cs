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
    public class DepartmentsController : ControllerBase
    {
        private  ApplicationDbcontext _context;
        public DepartmentsController(ApplicationDbcontext context)
        {
            _context= context;
        }
        [HttpGet]
        [Route("department/{departmentName}/students")]
        public IActionResult GetStudentsByDepartment(string departmentName)
        {
            var students = _context.Students
                .Where(s => s.Departments.Name == departmentName)
                .ToList();

            if (!students.Any())
            {
                return NotFound();
            }

            return Ok(students);
        }

        [HttpGet]
        //this method the get all dept from db 
        public async Task<IActionResult> getAllDept()
        {
            //to convert the data from table to list 
            var depts =await _context.Departments.ToListAsync();
            //check if the depts is empty or not
            if (!depts.Any())
            {
                return NotFound();
            }
            return Ok(depts);
        }
        //add new dept
        [HttpPost]
        public async Task<IActionResult>AddDept(DeptDto dto)
        {
            //to check if there is any prop not vaild 

         
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }
            var dept = new Departments
            {
                Name = dto.Name,
            };
            //if there is any execption 
            try
            {
                //to add new dept to the database
                await _context.Departments.AddAsync(dept);
                //to save the database 
                await  _context.SaveChangesAsync();
                return Ok(dept);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }
        [HttpPut("id")]
        public async Task<IActionResult>UpdateDept(DeptDto dto,int id )
        {
           
            var dept = await _context.Departments.FindAsync(id);
            //_context.Departments.Where(dept=> dept.Id==id && dept.Name=="programming")
            //to check if the dept is exiting or not 
            if(dept == null)
            {
                return NotFound("the dept is not found ");
            }
            dept.Name=dto.Name;
            try
            {
                _context.Update(dept);
                await _context.SaveChangesAsync();
                return Ok(dept);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //to delete a dept from dept table
        [HttpDelete("id")]
        public async Task<IActionResult>DeleteDept(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if(dept is null)
            {
                return NotFound();
            }
            try
            {
                _context.Remove(dept);
                await _context.SaveChangesAsync();
                return Ok(dept);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
