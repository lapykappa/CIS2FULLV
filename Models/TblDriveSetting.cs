namespace DbFirstCIS2.Models;

public partial class TblDriveSetting
{
    public int TblDriveSettingId { get; set; }

    public int TblDriveId { get; set; }

    public int? TblQlausTaskId { get; set; }

    public string PreBatch { get; set; } = null!;

    public string PostBatch { get; set; } = null!;

    public string? TestCaseFile { get; set; }

    public virtual TblDrive TblDrive { get; set; } = null!;

    public virtual TblQlausTask? TblQlausTask { get; set; }
}
