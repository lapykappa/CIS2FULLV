namespace DbFirstCIS2.Models;

public partial class TblInstalledSoftware
{
    public int TblInstalledSoftwareId { get; set; }

    public string Vendor { get; set; } = null!;

    public string SwName { get; set; } = null!;

    public string MainVersion { get; set; } = null!;

    public string MajorVersion { get; set; } = null!;

    public string BuildLabel { get; set; } = null!;
}
