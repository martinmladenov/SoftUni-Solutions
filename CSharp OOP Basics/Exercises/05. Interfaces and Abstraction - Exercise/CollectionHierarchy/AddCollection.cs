public class AddCollection<T> : IAddCollection<T>
{
    private T[] arr;

    private int currIndex;

    public AddCollection()
    {
        arr = new T[100];
        currIndex = 0;
    }

    public int Add(T element)
    {
        arr[currIndex] = element;

        return currIndex++;
    }
}
