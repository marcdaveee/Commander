using AutoMapper;
using Commander.Data;
using Commander.Dtos.Command;
using Commander.Mappers;
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
        private readonly ICommanderRepo _repo;
        // Using Automapper
        private readonly IMapper _mapper;


        //Assign the dependency injected value to be used inside this class using constructor injection
        public CommandsController(ICommanderRepo repo, IMapper mapper)  
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands() { 

            // Using defined extension mapping methods
            var commandItems = _repo.GetAllCommands().Select(c => c.toCommandReadDto());

            //Using automapper
            //return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));            
            return Ok(commandItems);
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            // Using defined extension mapping methods
            var commandItem = _repo.GetCommandById(id).toCommandReadDto();

            if(commandItem == null)
            {
                return NotFound();
            }

            //Using automapper
            //return Ok(_mapper.Map<CommandReadDto>(commandItem));

            return Ok(commandItem);
        }

    }
}