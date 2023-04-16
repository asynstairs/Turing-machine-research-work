using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Tkachev_TuringSimulation_WPF.Files;

public static class GlobalPaths
{
    public static readonly IReadOnlyDictionary<LogFilesTypes, string> LogFiles = new Dictionary<LogFilesTypes, string>()
    {
        [LogFilesTypes.Protocol] = "Protocol.log",
    };

    public static async Task ClearAllAsync()
    {
        foreach (var path in LogFiles.Values)
        {
            await File.WriteAllTextAsync(path, string.Empty);
        }
    }
}