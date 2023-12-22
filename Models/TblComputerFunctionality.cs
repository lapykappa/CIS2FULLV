namespace DbFirstCIS2.Models;

public partial class TblComputerFunctionality
{
    public int TblComputerFuncionalityId { get; set; }

    public string FunctionalityDescription { get; set; } = null!;

    public virtual ICollection<TblComputer> TblComputers { get; set; } = new List<TblComputer>();
}
