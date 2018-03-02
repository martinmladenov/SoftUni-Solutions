public class Mission : IMission
{
    public Mission(string codeName, MissionState state)
    {
        CodeName = codeName;
        State = state;
    }

    public string CodeName { get; }
    public MissionState State { get; private set; }

    public void CompleteMission()
    {
        State = MissionState.Finished;
    }

    public override string ToString()
    {
        return $"Code Name: {CodeName} State: {State}";
    }
}