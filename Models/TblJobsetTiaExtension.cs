namespace DbFirstCIS2.Models;

public partial class TblJobsetTiaExtension
{
    public int TblJobsetId { get; set; }

    public int TblTiaExtensionId { get; set; }

    public virtual TblJobset TblJobset { get; set; } = null!;

    public virtual TblTiaExtension TblTiaExtension { get; set; } = null!;
}
