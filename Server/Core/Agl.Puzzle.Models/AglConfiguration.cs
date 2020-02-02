namespace Agl.Puzzle.Models
{

    public class AglConfiguration
    {
        public Logging Logging { get; set; }
        public AglAzureDataStore AglAzureDataStore { get; set; }
    }

    public class AglAzureDataStore
    {
        public string ApiUrl { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public Debug Debug { get; set; }
        public Console Console { get; set; }
        public Aglazuredatastore AglAzureDataStore { get; set; }
    }

    public class Debug
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
    }

    public class Console
    {
        public Loglevel1 LogLevel { get; set; }
    }

    public class Loglevel1
    {
        public string Default { get; set; }
    }

    public class Aglazuredatastore
    {
        public string ApiUrl { get; set; }
    }

}
