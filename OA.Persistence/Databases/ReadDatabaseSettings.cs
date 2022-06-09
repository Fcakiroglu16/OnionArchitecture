namespace OA.Persistence.Databases;

public class ReadDatabaseSettings : IReadDatabaseSettings
{
 
    

    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
}