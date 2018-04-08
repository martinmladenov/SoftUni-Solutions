namespace P01_EventImplementation
{
    using System;

    public class NameChangeEventArgs : EventArgs
    {
        public NameChangeEventArgs(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
