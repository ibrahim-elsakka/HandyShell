using Nucs.JsonSettings.Modulation.Recovery;
using Nucs.JsonSettings.Modulation;
using Nucs.JsonSettings;
using System;
using Nucs.JsonSettings.Fluent;
using Nucs.JsonSettings.Autosave;
using System.IO;

namespace HandyShell
{
    public class Configs : JsonSettings, IVersionable
    {
        public static readonly string AppName = "HandyShell";
        public static readonly string RootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppName);
        public static readonly string AppConfigPath = Path.Combine(RootPath, "AppConfig.json");

        public static Configs Settings = Configure<Configs>()
                                   .WithRecovery(RecoveryAction.RenameAndLoadDefault)
                                   .WithVersioning(VersioningResultAction.RenameAndLoadDefault)
                                   .LoadNow()
                                   .EnableAutosave();

        [EnforcedVersion("1.0.0.0")]
        public virtual Version Version { get; set; } = new Version(1, 0, 0, 0);
        public override string FileName { get; set; } = AppConfigPath;

        public virtual bool IsTopMenuCustomize { get; set; }

        
    }
}
