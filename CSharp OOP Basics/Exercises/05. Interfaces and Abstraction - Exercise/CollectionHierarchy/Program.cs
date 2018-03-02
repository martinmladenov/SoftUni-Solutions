using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        string[] toAdd = Console.ReadLine().Split();

        IAddCollection<string>[] collections =
        {
            new AddCollection<string>(),
            new AddRemoveCollection<string>(),
            new MyList<string>()
        };

        StringBuilder sb = new StringBuilder();

        foreach (var collection in collections)
        {
            foreach (var element in toAdd)
            {
                sb.Append(collection.Add(element) + " ");
            }

            sb.AppendLine();
        }

        int n = int.Parse(Console.ReadLine());

        foreach (var collection in collections)
        {
            if (!(collection is IAddRemoveCollection<string> addRemoveCollection))
                continue;

            for (int i = 0; i < n; i++)
            {
                sb.Append(addRemoveCollection.Remove() + " ");
            }

            sb.AppendLine();
        }

        Console.Write(sb);
    }
}
