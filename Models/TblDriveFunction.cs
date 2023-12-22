namespace DbFirstCIS2.Models;

public partial class TblDriveFunction
{
    public int TblDriveFunctionId { get; set; }

    public string DriveFunctionDescription { get; set; } = null!;

    public virtual ICollection<TblDrive> TblDrives { get; set; } = new List<TblDrive>();
}
