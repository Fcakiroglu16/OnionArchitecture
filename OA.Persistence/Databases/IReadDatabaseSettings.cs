namespace OA.Persistence.Databases;

public interface IReadDatabaseSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}