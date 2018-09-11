namespace HostBuilderServices
{
    public interface IAppsettings
    {
        string SqlConnectionString { get; set; }
        double Timer { get; set; }
    }
}
