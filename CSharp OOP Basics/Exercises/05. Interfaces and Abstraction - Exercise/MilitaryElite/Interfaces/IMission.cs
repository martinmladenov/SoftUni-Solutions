public interface IMission
{
    string CodeName { get; }
    MissionState State { get; }

    void CompleteMission();
}