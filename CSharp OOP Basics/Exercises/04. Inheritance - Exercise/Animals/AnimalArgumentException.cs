namespace Animals
{
    using System;

    public class AnimalArgumentException : ArgumentException
    {
        public override string Message => "Invalid input!";
    }
}
