namespace DbFirstCIS2.Models;

public partial class TblInterfaceName
{
    public int TblInterfaceNameId { get; set; }

    public string InterfaceName { get; set; } = null!;

    public virtual ICollection<TblInterface> TblInterfaces { get; set; } = new List<TblInterface>();
}
