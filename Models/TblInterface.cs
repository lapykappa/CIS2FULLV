namespace DbFirstCIS2.Models;

public partial class TblInterface
{
    public int TblInterfacesId { get; set; }

    public int TblComputerId { get; set; }

    public int TblInterfaceNameId { get; set; }

    public string Address { get; set; } = null!;

    public string MacAddress { get; set; } = null!;

    public bool IsTestInterface { get; set; }

    public virtual TblComputer TblComputer { get; set; } = null!;

    public virtual TblInterfaceName TblInterfaceName { get; set; } = null!;
}
