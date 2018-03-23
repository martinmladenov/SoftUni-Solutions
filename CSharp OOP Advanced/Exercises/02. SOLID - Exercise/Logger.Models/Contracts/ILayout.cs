namespace Logger.Models.Contracts
{
    public interface ILayout
    {
        string FormatMessage(IMessage message);
    }
}