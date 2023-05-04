
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using MinecraftMapTransfer;
using MinecraftMapTransfer.Extensions;

var sc = new ServiceCollection();

sc.AddSingleton(GetConfiguration());

var sp = sc.BuildServiceProvider();

var transferSettings = sp.GetRequiredService<IConfiguration>().GetSection(TransferSettings.SectionName).Get<TransferSettings>();

var regionCoordinateList = await GetRegionCoordinateListAsync(transferSettings);

FetchMinecraftWorldDirectory(transferSettings, regionCoordinateList);

#region Private Method

static IConfiguration GetConfiguration()
{
    var releaseJsonSource = new JsonConfigurationSource
    {
        FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory()),
        Path = "appsettings.json",
        Optional = false,
        ReloadOnChange = true
    };

    return new ConfigurationBuilder()
        .Add(releaseJsonSource)
        .Build();
}

static async Task<List<string>> GetRegionCoordinateListAsync(TransferSettings transferSettings)
{
    var regionCoordinateList = new List<string>();
    
    foreach (var mapCoordinate in await File.ReadAllLinesAsync(transferSettings.MapCoordinateFilePath))
    {
        var regionCoordinate = mapCoordinate.ToRegionCoordinate();
    
        if (!regionCoordinateList.Contains(regionCoordinate))
            regionCoordinateList.Add(regionCoordinate);
    }

    if (transferSettings.IsGenerateRegionCoordinateFile)
        await File.WriteAllLinesAsync(transferSettings.RegionCoordinateFilePath, regionCoordinateList);
    
    return regionCoordinateList;
}

static void FetchMinecraftWorldDirectory(TransferSettings transferSettings, List<string> regionCoordinateList)
{
    var sourceDirectoryRootPath = transferSettings.MinecraftWorld.SourceDirectoryPath;
    var destinationDirectoryRootPath = transferSettings.MinecraftWorld.DestinationDirectoryPath;

    if (!Directory.Exists(destinationDirectoryRootPath))
        Directory.CreateDirectory(destinationDirectoryRootPath);

    foreach (var scanDirectoryName in transferSettings.MinecraftWorld.ScanDirectoryNames)
    {
        var sourceDirectoryPath = Path.Combine(sourceDirectoryRootPath, scanDirectoryName);
        var destinationDirectoryPath = Path.Combine(destinationDirectoryRootPath, scanDirectoryName);
        
        if (!Directory.Exists(sourceDirectoryPath))
            continue;
        
        foreach (var regionCoordinate in regionCoordinateList)
        {
            var fileName = $"r.{regionCoordinate.Replace(',', '.')}.mca";
            var sourceFilePath = Path.Combine(sourceDirectoryPath, fileName);
            var destinationFilePath = Path.Combine(destinationDirectoryPath, fileName);

            if (!File.Exists(sourceFilePath))
                continue;
            
            if (!Directory.Exists(destinationDirectoryPath))
                Directory.CreateDirectory(destinationDirectoryPath);
                
            File.Copy(sourceFilePath, destinationFilePath, true);
        }
    }
}

#endregion
