using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Color_Coding
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int mainIterator = 0; mainIterator < n; mainIterator++)
            {
                List<Color> inputColors = new List<Color>(Array.ConvertAll(Console.ReadLine().Split(), input => new Color(input)));
                List<Color> outputColors = new List<Color>(Array.ConvertAll(Console.ReadLine().Split(), input => new Color(input)));

                bool cannotFix = false;

                for (int i = 0; i < inputColors.Count; i++)
                    if (outputColors.Count > i && inputColors[i].Name == outputColors[i].Name)
                    {
//                        Console.WriteLine($"make full {i} {inputColors[i].Name} {inputColors[i].IsHalf}");
                        inputColors[i].IsHalf = false;

                        for (int j = i + 1; j < inputColors.Count; j++)
                        {
                            if (inputColors[j].IsHalf) continue;
                            if (inputColors[j].CompareTo(inputColors[i]))
                                inputColors[j].IsHalf = true;
                            break;
                        }

                    }
                    else if (inputColors[i].IsHalf)
                    {
//                        Console.WriteLine($"remove {i} {inputColors[i].Name} {inputColors[i].IsHalf}");
                        inputColors.RemoveAt(i);
                        i--;
                    }
                    else
                    {
//                        Console.WriteLine($"cannot fix {i} {inputColors[i].Name} {inputColors[i].IsHalf}");
                        cannotFix = true;
                        break;
                    }

                Console.WriteLine((!cannotFix).ToString().ToLower());

            }

        }
    }

    class Color
    {
        public string Name { get; }
        public bool IsHalf { get; set; }

        public Color(string input)
        {
            IsHalf = input.StartsWith("(");
            Name = input.Split("()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
        }

        public bool CompareTo(Color otherColor)
        {
            return Name == otherColor.Name && IsHalf == otherColor.IsHalf;
        }

    }
}
