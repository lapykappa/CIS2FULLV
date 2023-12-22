namespace DbFirstCIS2.Models;

public partial class TblUserRole
{
    public int TblUserId { get; set; }

    public int TblRoleId { get; set; }

    public virtual TblRole TblRole { get; set; } = null!;

    public virtual TblUser TblUser { get; set; } = null!;
}
