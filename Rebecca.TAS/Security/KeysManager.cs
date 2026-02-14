using Microsoft.Extensions.Logging;
using NSec.Cryptography;

namespace Rebecca.TAS.Security;

public class KeysManager
{
    private ILogger logger = Core.Core.Singleton.CreateLogger(typeof(KeysManager));
    
    private Key PrivateKey;
    private PublicKey PublicKey;

    public KeysManager(bool showPrivateKey = false)
    {
        logger.LogInformation("Initializing Keys Manager...");
        GenerateKeys(showPrivateKey);
        logger.LogInformation("Public key: {}", 
            BitConverter.ToString(PublicKey.Export(KeyBlobFormat.RawPublicKey)).Replace("-", ""));
        logger.LogInformation("Private key: {}", 
            showPrivateKey ? BitConverter.ToString(PrivateKey.Export(KeyBlobFormat.RawPrivateKey)).Replace("-", "") : "hidden");
    }

    private void GenerateKeys(bool export)
    {
        logger.LogInformation("Generating Keys...");
        var algorithm = SignatureAlgorithm.Ed25519;
        PrivateKey = new Key(algorithm, new KeyCreationParameters
        {
            ExportPolicy = export ? KeyExportPolicies.AllowPlaintextExport: KeyExportPolicies.None
        });
        PublicKey = PrivateKey.PublicKey;
    }
}