namespace DbFirstCIS2.Models;

public partial class TblUser
{
    public int TblUserId { get; set; }

    public string Username { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<TblComputerUser> TblComputerUsers { get; set; }

}
