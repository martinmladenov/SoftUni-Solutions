namespace SweepAndPrune
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var objects = new List<GameObject>();

            var byName = new Dictionary<string, GameObject>();

            string input;
            while ((input = Console.ReadLine()) != "start")
            {
                var split = input.Split();
                GameObject gameObject = new GameObject(split[1], int.Parse(split[2]), int.Parse(split[3]));
                objects.Add(gameObject);
                byName.Add(split[1], gameObject);
            }

            for (int tick = 1; (input = Console.ReadLine()) != "end"; tick++)
            {
                var split = input.Split();

                if (split[0] == "move")
                {
                    GameObject gameObject = byName[split[1]];
                    gameObject.MoveTo(int.Parse(split[2]), int.Parse(split[3]));
                }

                InsertionSort(objects);

                for (int i = 0; i < objects.Count; i++)
                {
                    for (int j = i + 1; j < objects.Count; j++)
                    {
                        if (objects[i].CollidesWith(objects[j]))
                        {
                            Console.WriteLine($"({tick}) {objects[i]} collides with {objects[j]}");
                        }
                    }
                }
            }
        }

        private static void InsertionSort(List<GameObject> objects)
        {
            for (var i = 0; i < objects.Count - 1; i++)
            {
                for (int index = i + 1; index > 0; index--)
                {
                    if (objects[index - 1].PositionBox.X1 > objects[index].PositionBox.X1)
                    {
                        var temp = objects[index - 1];
                        objects[index - 1] = objects[index];
                        objects[index] = temp;
                    }
                }
            }
        }
    }
}
