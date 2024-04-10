using Commander.Dtos.Command;
using Commander.Mappers;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(t => t.Id == id);
        }

        public void CreateCommand(Command newCommand)
        {            
            if(newCommand == null)
            {
                throw new ArgumentNullException(nameof(newCommand));
            }
            _context.Commands.Add(newCommand);
            _context.SaveChanges();            
        }

        public void UpdateCommand(Command updatedCommand)
        {
            // nothing to do
            _context.SaveChanges();
        }

        public void DeleteCommand(Command commandToDelete)
        {
            _context.Remove(commandToDelete);
            _context.SaveChanges();
        }
    }
}
