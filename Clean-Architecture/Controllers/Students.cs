using Cores.Features.StudentCQRS.Command.Mapping;
using Cores.Features.StudentCQRS.Command.Requests;
using Cores.Features.StudentCQRS.Queries.Handlers;
using Cores.Features.StudentCQRS.Queries.Models;
using Cores.Features.StudentCQRS.Queries.Models.requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Students : ControllerBase
    {

        #region Fields
        private readonly IMediator mediatR;
        #endregion
        public Students(IMediator mediatR)
        {
            this.mediatR = mediatR;
        }
      


        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var result =  await mediatR.Send(new StudentlistQuery());

            
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBYID(int id)
        {
            var result = await mediatR.Send(new StudentByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddanewSTD(StudentAddInput studentAddInput)
        {
            if (!ModelState.IsValid)
                return BadRequest("sorry something is wrong");
            var result = await mediatR.Send(new StudentAddCommand(studentAddInput));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Removeing(int id)
        {
            var result = await mediatR.Send(new StudentRemoveCommand(id));
            if (result == null)
                return BadRequest("something is Wrong");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , StudentUpdateCommand studentUpdateCommand)
        {
            if (id != studentUpdateCommand.id)
                return BadRequest("sorry this id not true");
            if (!ModelState.IsValid)
                return BadRequest("sorry something is wrong");
            var result = mediatR.Send(new StudentUpdateCommand(id));
            return Ok(result);  


        }

    }
}
