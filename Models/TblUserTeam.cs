namespace DbFirstCIS2.Models;

public partial class TblUserTeam
{
    public int TblUserId { get; set; }

    public int TblTeamId { get; set; }

    public virtual TblTeam TblTeam { get; set; } = null!;
}
