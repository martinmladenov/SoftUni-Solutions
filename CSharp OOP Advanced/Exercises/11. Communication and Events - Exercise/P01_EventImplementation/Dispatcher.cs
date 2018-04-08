namespace P01_EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);


    public class Dispatcher
    {
        private string name;
        public event NameChangeEventHandler NameChange;

        public Dispatcher(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get => name;
            set
            {
                OnNameChange(new NameChangeEventArgs(value));
                name = value;
            }
        }

        private void OnNameChange(NameChangeEventArgs args)
        {
            NameChange(this, args);
        }
    }
}
