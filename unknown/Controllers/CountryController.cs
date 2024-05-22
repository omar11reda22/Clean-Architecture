using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using unknown.DTOs;
using unknown.Models;

namespace unknown.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ManytomanyContext context;

        public CountryController(ManytomanyContext context)
        {
            this.context = context;
        }
        [HttpGet("country")]
        public async Task<IActionResult> getallCountry()
        {
            var results = await context.Countries.AsNoTracking().ToListAsync();

            return Ok(results);
        }
        //[HttpGet("courses")]
        //public async Task<IActionResult> getallcourses()
        //{
        //    var items = await context.Courses.AsNoTracking().ToListAsync();
        //    return Ok(items);
        //}

        [HttpGet("{id}")]
        public ActionResult getbyid(int id)
        {
            var countr = context.Countries.Find(id);

            if (countr == null)
                return NotFound();
            CountryDTO cnt = new CountryDTO()
            {
            id = countr.CntId,
            Name = countr.CntName, 
            studentinthiscountry = countr.Students.Select(s => s.StdName).ToList()
            };
            return Ok(cnt); 
        }
      
    }
}
