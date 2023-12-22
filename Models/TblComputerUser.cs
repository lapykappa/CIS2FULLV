namespace DbFirstCIS2.Models;

public partial class TblComputerUser
{
    public int TblComputerId { get; set; }

    public int TblUserId { get; set; }

    public bool IsResponsible { get; set; }

    public virtual TblComputer TblComputer { get; set; } = null!;

    public virtual TblUser TblUser { get; set; } = null!;
}
