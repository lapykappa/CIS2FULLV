namespace DbFirstCIS2.Models;

public partial class TblJobset
{
    public int TblJobsetId { get; set; }

    public string JobsetName { get; set; } = null!;

    public string TestDataDropLocation { get; set; } = null!;

    public string TestAutomatDropLocation { get; set; } = null!;

    public bool? EnableRestore { get; set; }

    public string Cdfolder { get; set; } = null!;

    public int? DeploymentTypeSelection { get; set; }

    public string SuppliesType { get; set; } = null!;

    public string TriggerFile { get; set; } = null!;

    public virtual ICollection<TblDriveJobset> TblDriveJobsets { get; set; } = new List<TblDriveJobset>();
}
