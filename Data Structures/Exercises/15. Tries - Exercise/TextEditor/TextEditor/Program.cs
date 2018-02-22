using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        TextEditor textEditor = new TextEditor();

        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            var split = input.Split();
            string command = split[0];
            if (command == "login")
            {
                textEditor.Login(split[1]);
            }
            else if (command == "logout")
            {
                textEditor.Logout(split[1]);
            }
            else if (command == "users")
            {
                string prefix = string.Empty;
                if (split.Length > 1)
                {
                    prefix = split[1];
                }

                Console.WriteLine(string.Join(Environment.NewLine, textEditor.Users(prefix)));
            }
            else
            {
                string username = command;
                command = split[1];

                if (command == "insert")
                {
                    int index = int.Parse(split[2]);
                    string toInsert = GetText(split, 3);
                    textEditor.Insert(username, index, toInsert);
                }
                else if (command == "prepend")
                {
                    string toPrepend = GetText(split, 2);
                    textEditor.Prepend(username, toPrepend);
                }
                else if (command == "delete")
                {
                    int index = int.Parse(split[2]);
                    int length = int.Parse(split[3]);
                    textEditor.Delete(username, index, length);
                }
                else if (command == "substring")
                {
                    int index = int.Parse(split[2]);
                    int length = int.Parse(split[3]);
                    textEditor.Substring(username, index, length);
                }
                else if (command == "clear")
                {
                    textEditor.Clear(username);
                }
                else if (command == "length")
                {
                    Console.WriteLine(textEditor.Length(username));
                }
                else if (command == "print")
                {
                    Console.WriteLine(textEditor.Print(username));
                }
                else if (command == "undo")
                {
                    textEditor.Undo(username);
                }
            }
        }
    }

    private static string GetText(string[] split, int index)
    {
        string str = string.Join(" ", split.Skip(index));
        return str.Substring(1, str.Length - 2);
    }
}