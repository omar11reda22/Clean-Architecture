using Cores.Features.DepartmentCQRS.Command.Mapping;
using Cores.Features.DepartmentCQRS.Command.Request;
using Cores.Features.DepartmentCQRS.Query.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator mediatR;

        public DepartmentsController(IMediator mediatR)
        {
            this.mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> Getalldepartment()
        {
            var items = await mediatR.Send(new Departmentlistquery());
            return Ok(items);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getdeptbyid(int id)
        {
            var item = await mediatR.Send(new DepartmentGetbyidQuery(id));
            if (item == null) return NotFound();    
            return Ok(item);

        }
        [HttpPost]
        public async Task<IActionResult> Addnewdept(DepartmentAddDTO departmentAddDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = await mediatR.Send(new DepartmentADDCommand(departmentAddDTO));
            return Ok(item);    
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> removedept(int id)
        {
            var item = await mediatR.Send(new DepartmentremoveCommand(id));
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}
