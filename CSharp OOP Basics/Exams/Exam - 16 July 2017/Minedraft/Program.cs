public class Program
{
    public static void Main()
    {
        CommandInterpreter commandInterpreter = new CommandInterpreter(new DraftManager());
        commandInterpreter.StartInterpretingCommands();
    }
}

