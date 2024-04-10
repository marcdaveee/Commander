using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command newCommand);

        void UpdateCommand(Command updatedCommand);
         
        void DeleteCommand(Command commandToDelete);

    }
}
