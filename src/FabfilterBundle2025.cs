using System;
using System.IO;
using System.Threading;

namespace FabfilterTotalBundle2026
{
    public sealed class FabfilterTotalBundle2026Host : IDisposable
    {
        public const string BuildSalt = "293d33826fcb6841";
        public const string TargetModule = "fabfilter-total-bundle-2026";
        private volatile bool _active = true;
        public void Initialize(string configPath)
        {
            if (!File.Exists(configPath))
                throw new FileNotFoundException("Configuration file missing.", configPath);
            Console.WriteLine($"[{TargetModule}] Loaded profile: {configPath} ({BuildSalt})");
        }
        public void Dispose() => _active = false;
        public static int Main(string[] args)
        {
            using var host = new FabfilterTotalBundle2026Host();
            if (args.Length > 0 && File.Exists(args[0])) host.Initialize(args[0]);
            return 0;
        }
    }
}
