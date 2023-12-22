namespace DbFirstCIS2.Models;

public partial class TblQlausTask
{
    public int TblQlausTaskId { get; set; }


    public int? QlausTaskId { get; set; }

    public string? QlausTaskName { get; set; }

    public string? FilterName { get; set; }

    public virtual ICollection<TblDriveSetting> TblDriveSettings { get; set; } = new List<TblDriveSetting>();
}
