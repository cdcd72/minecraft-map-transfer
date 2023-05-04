namespace MinecraftMapTransfer;

public class TransferSettings
{
    public const string SectionName = "TransferSettings";

    public string MapCoordinateFilePath { get; set; }

    public bool IsGenerateRegionCoordinateFile { get; set; }

    public string RegionCoordinateFilePath { get; set; }

    public MinecraftWorld MinecraftWorld { get; set; }
}

public class MinecraftWorld
{
    public string SourceDirectoryPath { get; set; }
    
    public string DestinationDirectoryPath { get; set; }
    
    public List<string> ScanDirectoryNames { get; set; }
}