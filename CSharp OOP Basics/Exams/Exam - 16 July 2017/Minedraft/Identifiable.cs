public abstract class Identifiable
{
    private string id;

    protected Identifiable(string id)
    {
        Id = id;
    }

    public string Id
    {
        get => id;
        protected set => id = value;
    }
}

