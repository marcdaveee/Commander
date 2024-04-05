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

        public static Command toCommandFromCreateDto(this CreateCommandDto newCommand)
        {
            return new Command
            {
                HowTo = newCommand.HowTo,
                Line = newCommand.Line,
                Platform = newCommand.Platform,
            };
        }

        public static Command toCommandFromUpdateDto(this UpdateCommandDto updatedCommand)
        {
            return new Command
            {
                HowTo = updatedCommand.HowTo,
                Line = updatedCommand.Line,
            };
        }
    }
}
