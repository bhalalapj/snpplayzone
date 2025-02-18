namespace SnpPlayzone.Models;

public class AppConfig
{
    public string ConfigurationsFolder { get; set; }

    public string AppPropertiesFileName { get; set; }

    public string PrivacyStatement { get; set; }
    public ConnectionStrings ConnectionStrings { get; set; }
}

public class ConnectionStrings
{
    public string snp { get; set; }
}
