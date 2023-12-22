namespace DbFirstCIS2.Models;

public partial class TblDriveJobset
{
    public int TblDriveJobsetId { get; set; }

    public int TblDriveId { get; set; }

    public int TblJobsetId { get; set; }

    public int DriveJobsetOrder { get; set; }

    public bool IsDriveJobsetEnabled { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual TblDrive TblDrive { get; set; } = null!;

    public virtual TblJobset TblJobset { get; set; } = null!;
}
