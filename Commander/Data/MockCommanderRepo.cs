using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command newCommand)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command> 
            {
                new Command { Id = 1, HowTo = "Change Directory", Line = "cd <name of directory>", Platform = "Windows Command Prompt" },
                new Command { Id = 2, HowTo="List Files/Directory", Line="ls", Platform="Windows Command Prompt"},
                new Command { Id = 3, HowTo="Make Directory", Line="mkdir <name of directory>", Platform="Windows Command Prompt"}
             };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = id, HowTo = "Change Directory", Line = "cd <name of directory>", Platform = "Windows Command Prompt" };
        }

        //public IEnumerable<Command> GetAllCommands()
        //{
        //    var commands = new List<Command>
        //    {
        //        new Command { Id = 1, HowTo = "Change directory", Line = "cd <name of directory>", Platform = "Windows Command Prompt" },
        //        new Command { Id = 2, HowTo = "List directory", Line = "ls ", Platform = "Windows Command Prompt" },
        //        new Command { Id = 3, HowTo = "Make directory", Line = "mkdir <name of directory>", Platform = "Windows Command Prompt" },
        //    };

        //    return commands;
        //}

        //public Command getCommand(int id)
        //{
        //    return new Command { Id = id, HowTo = "Change directory", Line = "cd <name of directory>", Platform = "Windows Command Prompt" };
        //}


    }
}
