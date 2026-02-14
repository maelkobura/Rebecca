using Microsoft.Extensions.Logging;
using Rebecca.TAS.Core;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

var core = new Core(loggerFactory);

