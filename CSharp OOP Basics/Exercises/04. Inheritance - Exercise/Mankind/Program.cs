namespace Mankind
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] studentInfo = Console.ReadLine().Split();
            string[] workerInfo = Console.ReadLine().Split();

            Student student;
            Worker worker;

            try
            {
                student = new Student(studentInfo[0], studentInfo[1], studentInfo[2]);

                worker = new Worker(workerInfo[0], workerInfo[1], decimal.Parse(workerInfo[2]),
                    decimal.Parse(workerInfo[3]));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
    }
}
