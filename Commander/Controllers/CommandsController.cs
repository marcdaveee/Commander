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
            var commandItem = _repo.GetCommandById(id);

            if(commandItem == null)
            {
                return NotFound();
            }

            var commandItemDto = commandItem.toCommandReadDto();
            //Using automapper
            //return Ok(_mapper.Map<CommandReadDto>(commandItem));

            return Ok(commandItemDto);
        }

        [HttpPost]
        public IActionResult CreateCommand([FromBody] CreateCommandDto commandDto)
        {
            var commandModel = commandDto.toCommandFromCreateDto();

            _repo.CreateCommand(commandModel);

            return CreatedAtAction(nameof(GetCommandById), new { id = commandModel.Id }, commandModel.toCommandReadDto() );
        }

        [HttpPut("{id}")]

        public IActionResult UpdateCommand([FromRoute] int id, [FromBody] UpdateCommandDto updatedCommandDto)
        {
            var commandModel = _repo.GetCommandById(id);

            if(commandModel == null)
            {
                return NotFound();
            }

            commandModel.HowTo = updatedCommandDto.HowTo;
            commandModel.Line = updatedCommandDto.Line;

            _repo.UpdateCommand(commandModel);

            return NoContent();        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCommand([FromRoute] int id)
        {
            var commandItem = _repo.GetCommandById(id);
            
            if(commandItem == null)
            {
                return NotFound();
            }

            _repo.DeleteCommand(commandItem);

            return NoContent();
        }
    }
}