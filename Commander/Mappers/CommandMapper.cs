using Commander.Dtos.Command;
using Commander.Models;

namespace Commander.Mappers
{
    public static class CommandMapper
    {
        public static CommandReadDto toCommandReadDto(this Command commandModel)
        {
            return new CommandReadDto
            {
                Id = commandModel.Id,
                HowTo = commandModel.HowTo,
                Line = commandModel.Line,
            };
        }
    }
}
