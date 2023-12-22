namespace DbFirstCIS2.Models;

public partial class TblDriveInstalledSoftware
{
    public int TblDriveId { get; set; }

    public int TblInstalledSoftwareId { get; set; }

    public virtual TblDrive TblDrive { get; set; } = null!;

    public virtual TblInstalledSoftware TblInstalledSoftware { get; set; } = null!;
}
