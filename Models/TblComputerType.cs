namespace DbFirstCIS2.Models;

public partial class TblComputerType
{
    public int TblComputerTypeId { get; set; }

    public string ComputerTypeDescription { get; set; } = null!;

    public virtual ICollection<TblComputer> TblComputers { get; set; } = new List<TblComputer>();
}
