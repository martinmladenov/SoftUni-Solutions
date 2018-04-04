namespace UnitTestingExercise.Database
{
    public class Person
    {
        public Person(int id, string username)
        {
            Id = id;
            Username = username;
        }

        public int Id { get; }
        public string Username { get; }
    }
}
