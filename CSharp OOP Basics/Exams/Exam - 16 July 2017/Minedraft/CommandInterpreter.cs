using System;
using System.Collections.Generic;
using System.Linq;

public class CommandInterpreter
{
    private DraftManager draftManager;
    private bool shutdown;

    public CommandInterpreter(DraftManager draftManager)
    {
        this.draftManager = draftManager;
        this.shutdown = false;
    }

    public void StartInterpretingCommands()
    {
        while (!shutdown)
        {
            string output = InterpretCommand(Console.ReadLine());
            Console.WriteLine(output);
        }
    }

    private string InterpretCommand(string input)
    {
        string[] split = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string cmd = split[0];
        List<string> arguments = split.Skip(1).ToList();

        string msg = null;

        switch (cmd)
        {
            case "RegisterHarvester":
                msg = this.draftManager.RegisterHarvester(arguments);
                break;
            case "RegisterProvider":
                msg = this.draftManager.RegisterProvider(arguments);
                break;
            case "Day":
                msg = this.draftManager.Day();
                break;
            case "Mode":
                msg = this.draftManager.Mode(arguments);
                break;
            case "Check":
                msg = this.draftManager.Check(arguments);
                break;
            case "Shutdown":
                msg = this.draftManager.ShutDown();
                shutdown = true;
                break;
        }

        return msg;
    }
}