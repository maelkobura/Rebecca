using Microsoft.Extensions.Logging;
using Rebecca.TAS.Security;

namespace Rebecca.TAS.Core;

public class Core
{

    private ILogger logger;
    
    public static Core? Singleton { get; private set; }
    public ILoggerFactory LoggerFactory { get; private set; }
    
    public KeysManager KeysManager { get; private set; }
    
    public Core(ILoggerFactory loggerFactory)
    {
        if(Singleton != null) return;
        Singleton = this;
        LoggerFactory = loggerFactory;
        logger = CreateLogger(GetType());
        
        logger.LogInformation("Initializing RTAS Core Systems...");
        KeysManager = new KeysManager();
    }

    public ILogger CreateLogger(Type type)
    {
        return LoggerFactory.CreateLogger(type.Name);
    }
}