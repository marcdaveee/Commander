using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly MockCommanderRepo _repo = new MockCommanderRepo();

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands() { 
            var commandItems = _repo.GetAllCommands();

            return Ok(commandItems);
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repo.GetCommandById(id);

            return Ok(commandItem);
        }

    }
}