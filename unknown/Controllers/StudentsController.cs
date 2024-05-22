using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using unknown.DTOs;
using unknown.Models;

namespace unknown.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ManytomanyContext context;

        public StudentsController(ManytomanyContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public IActionResult getstudentbyid(int id)
        {
            // using lazy loading without include lazy with DTO 
            var student = context.Students.FirstOrDefault(s => s.StdId == id);

            StudentDTO studentDTO = new StudentDTO()
            {
                ID = student.StdId,
                Name = student.StdName,
                Email = student.StdEmail,
                Country = student.Cnr.CntName,
                Course = student.Crs.Select(s => s.CrsName).ToList()

            };





            return Ok(studentDTO);
        }
        [HttpGet("students")]
        public ActionResult getstudent()
        {


            var std = context.Students.ToList();

            List<StudentDTO> studentDTOs = new List<StudentDTO>();

            foreach (var student in std)
            {
                StudentDTO studentDTO = new StudentDTO()
                {
                    ID = student.StdId,
                    Name = student.StdName,
                    Email = student.StdEmail,
                    Country = student.Cnr.CntName,


                };
                studentDTOs.Add(studentDTO);
            }




            return Ok(studentDTOs);
        }

        [HttpPost]
        public ActionResult addnewstudent(AddnewstudentDTO studentDTO)
        {
            if (ModelState.IsValid)
            {
                // should maping here from dto to student in db 
                Student std = new Student();
                 std.StdName = studentDTO.Name; 
                 std.StdEmail = studentDTO.Email;
                std.CnrId = studentDTO.countryid;

                var selectedcourses = context.Courses.Where(s => studentDTO.coursesid.Contains(s.CrsId));
                std.Crs = selectedcourses.ToList();

                context.Students.Add(std); 
                context.SaveChanges(); 
            }
            else
                return BadRequest();
            return Ok(studentDTO);
        }
    }
}
