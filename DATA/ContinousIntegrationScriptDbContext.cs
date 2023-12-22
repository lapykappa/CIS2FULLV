using DbFirstCIS2.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstCIS2.DATA;

public partial class ContinousIntegrationScriptDbContext : DbContext
{
    public ContinousIntegrationScriptDbContext()
    {
    }

    public ContinousIntegrationScriptDbContext(DbContextOptions<ContinousIntegrationScriptDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblComputer> TblComputers { get; set; }

    public virtual DbSet<TblComputerFunctionality> TblComputerFunctionalities { get; set; }

    public virtual DbSet<TblComputerType> TblComputerTypes { get; set; }

    public virtual DbSet<TblComputerUser> TblComputerUsers { get; set; }

    public virtual DbSet<TblDrive> TblDrives { get; set; }

    public virtual DbSet<TblDriveFunction> TblDriveFunctions { get; set; }

    public virtual DbSet<TblDriveInstalledSoftware> TblDriveInstalledSoftwares { get; set; }

    public virtual DbSet<TblDriveJobset> TblDriveJobsets { get; set; }

    public virtual DbSet<TblDriveSetting> TblDriveSettings { get; set; }

    public virtual DbSet<TblInstalledSoftware> TblInstalledSoftwares { get; set; }

    public virtual DbSet<TblInterface> TblInterfaces { get; set; }

    public virtual DbSet<TblInterfaceName> TblInterfaceNames { get; set; }

    public virtual DbSet<TblJobset> TblJobsets { get; set; }

    public virtual DbSet<TblJobsetTiaExtension> TblJobsetTiaExtensions { get; set; }

    public virtual DbSet<TblQlausTask> TblQlausTasks { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblTeam> TblTeams { get; set; }

    public virtual DbSet<TblTiaExtension> TblTiaExtensions { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserRole> TblUserRoles { get; set; }

    public virtual DbSet<TblUserTeam> TblUserTeams { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblComputer>(entity =>
        {
            entity.HasKey(e => e.TblComputerId).HasName("PK__tblCompu__1B7A739897256C66");

            entity.ToTable("tblComputers");

            entity.Property(e => e.TblComputerId).HasColumnName("tblComputerID");
            entity.Property(e => e.TblComputerFuncionalityId).HasColumnName("tblComputerFuncionalityID");
            entity.Property(e => e.TblComputerTypeId).HasColumnName("tblComputerTypeID");

            entity.HasOne(d => d.TblComputerFuncionality).WithMany(p => p.TblComputers)
                .HasForeignKey(d => d.TblComputerFuncionalityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblComputers_tblComputerFunctionalities");

            entity.HasOne(d => d.TblComputerType).WithMany(p => p.TblComputers)
                .HasForeignKey(d => d.TblComputerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblComputers_tblComputerTypes");
        });

        modelBuilder.Entity<TblComputerFunctionality>(entity =>
        {
            entity.HasKey(e => e.TblComputerFuncionalityId).HasName("PK__tblCompu__43917DB21866F0EE");

            entity.ToTable("tblComputerFunctionalities");

            entity.Property(e => e.TblComputerFuncionalityId).HasColumnName("tblComputerFuncionalityID");
        });

        modelBuilder.Entity<TblComputerType>(entity =>
        {
            entity.HasKey(e => e.TblComputerTypeId).HasName("PK__tblCompu__34C645AB64AE600E");

            entity.ToTable("tblComputerTypes");

            entity.Property(e => e.TblComputerTypeId).HasColumnName("tblComputerTypeID");
        });

        modelBuilder.Entity<TblComputerUser>(entity =>
        {
            entity.HasKey(e => new { e.TblComputerId, e.TblUserId });

            entity.ToTable("tblComputerUsers");

            entity.HasOne(d => d.TblComputer).WithMany(p => p.TblComputerUsers)
                .HasForeignKey(d => d.TblComputerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblComputerUsers_tblComputers");

            entity.HasOne(d => d.TblUser).WithMany(p => p.TblComputerUsers)
                .HasForeignKey(d => d.TblUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblComputerUsers_tblUsers");
        });


        modelBuilder.Entity<TblDrive>(entity =>
        {
            entity.HasKey(e => e.TblDriveId).HasName("PK__tblDrive__22F285196F039AB8");

            entity.ToTable("tblDrives");

            entity.Property(e => e.TblDriveId).HasColumnName("tblDriveID");
            entity.Property(e => e.TblComputerId).HasColumnName("tblComputerID");
            entity.Property(e => e.TblDriveFunctionId).HasColumnName("tblDriveFunctionID");

            entity.HasOne(d => d.TblComputer).WithMany(p => p.TblDrives)
                .HasForeignKey(d => d.TblComputerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDrives_tblComputers");

            entity.HasOne(d => d.TblDriveFunction).WithMany(p => p.TblDrives)
                .HasForeignKey(d => d.TblDriveFunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDrives_tblDriveFunctions");
        });

        modelBuilder.Entity<TblDriveFunction>(entity =>
        {
            entity.HasKey(e => e.TblDriveFunctionId).HasName("PK__tblDrive__7721A659B5666400");

            entity.ToTable("tblDriveFunctions");

            entity.Property(e => e.TblDriveFunctionId).HasColumnName("tblDriveFunctionID");
        });

        modelBuilder.Entity<TblDriveInstalledSoftware>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblDriveInstalledSoftwares");

            entity.Property(e => e.TblDriveId).HasColumnName("tblDriveID");
            entity.Property(e => e.TblInstalledSoftwareId).HasColumnName("tblInstalledSoftwareID");

            entity.HasOne(d => d.TblDrive).WithMany()
                .HasForeignKey(d => d.TblDriveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDriveInstalledSoftwares_tblDrives");

            entity.HasOne(d => d.TblInstalledSoftware).WithMany()
                .HasForeignKey(d => d.TblInstalledSoftwareId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDriveInstalledSoftwares_tblInstalledSoftwares");
        });

        modelBuilder.Entity<TblDriveJobset>(entity =>
        {
            entity.ToTable("tblDriveJobsets");

            entity.Property(e => e.TblDriveJobsetId).HasColumnName("tblDriveJobsetID");
            entity.Property(e => e.CreateDate).HasColumnType("date");
            entity.Property(e => e.TblDriveId).HasColumnName("tblDriveID");
            entity.Property(e => e.TblJobsetId).HasColumnName("tblJobsetID");

            entity.HasOne(d => d.TblDrive).WithMany(p => p.TblDriveJobsets)
                .HasForeignKey(d => d.TblDriveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDriveJobsets_tblDrives");

            entity.HasOne(d => d.TblJobset).WithMany(p => p.TblDriveJobsets)
                .HasForeignKey(d => d.TblJobsetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDriveJobsets_tblJobsets");
        });

        modelBuilder.Entity<TblDriveSetting>(entity =>
        {
            entity.HasKey(e => e.TblDriveSettingId).HasName("PK__tblDrive__DF0C58003EBA4BD8");

            entity.ToTable("tblDriveSettings");

            entity.Property(e => e.TblDriveSettingId).HasColumnName("tblDriveSettingID");
            entity.Property(e => e.TblDriveId).HasColumnName("tblDriveID");
            entity.Property(e => e.TblQlausTaskId).HasColumnName("tblQlausTaskID");

            entity.HasOne(d => d.TblDrive).WithMany(p => p.TblDriveSettings)
                .HasForeignKey(d => d.TblDriveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDriveSettings_tblDrives");

            entity.HasOne(d => d.TblQlausTask).WithMany(p => p.TblDriveSettings)
                .HasForeignKey(d => d.TblQlausTaskId)
                .HasConstraintName("FK_tblDriveSettings_tblQlausTasks");
        });

        modelBuilder.Entity<TblInstalledSoftware>(entity =>
        {
            entity.HasKey(e => e.TblInstalledSoftwareId).HasName("PK__tblInsta__D0BC9E1675F66A98");

            entity.ToTable("tblInstalledSoftwares");

            entity.Property(e => e.TblInstalledSoftwareId).HasColumnName("tblInstalledSoftwareID");
        });

        modelBuilder.Entity<TblInterface>(entity =>
        {
            entity.HasKey(e => e.TblInterfacesId).HasName("PK__tblInter__DD05B55EC7ED4DAD");

            entity.ToTable("tblInterfaces");

            entity.Property(e => e.TblInterfacesId).HasColumnName("tblInterfacesID");
            entity.Property(e => e.TblComputerId).HasColumnName("tblComputerID");
            entity.Property(e => e.TblInterfaceNameId).HasColumnName("tblInterfaceNameID");

            entity.HasOne(d => d.TblComputer).WithMany(p => p.TblInterfaces)
                .HasForeignKey(d => d.TblComputerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblInterfaces_tblComputers");

            entity.HasOne(d => d.TblInterfaceName).WithMany(p => p.TblInterfaces)
                .HasForeignKey(d => d.TblInterfaceNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblInterfaces_tblInterfaceNames");
        });

        modelBuilder.Entity<TblInterfaceName>(entity =>
        {
            entity.HasKey(e => e.TblInterfaceNameId).HasName("PK__tblInter__7971E2A670F3EC8F");

            entity.ToTable("tblInterfaceNames");

            entity.Property(e => e.TblInterfaceNameId).HasColumnName("tblInterfaceNameID");
        });

        modelBuilder.Entity<TblJobset>(entity =>
        {
            entity.HasKey(e => e.TblJobsetId).HasName("PK__tblJobse__D5FFDAD16856A070");

            entity.ToTable("tblJobsets");

            entity.Property(e => e.TblJobsetId).HasColumnName("tblJobsetID");
            entity.Property(e => e.Cdfolder).HasColumnName("CDFolder");
        });

        modelBuilder.Entity<TblJobsetTiaExtension>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblJobsetTiaExtensions");

            entity.Property(e => e.TblJobsetId).HasColumnName("tblJobsetID");
            entity.Property(e => e.TblTiaExtensionId).HasColumnName("tblTiaExtensionID");

            entity.HasOne(d => d.TblJobset).WithMany()
                .HasForeignKey(d => d.TblJobsetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblJobsetTiaExtensions_tblJobsets");

            entity.HasOne(d => d.TblTiaExtension).WithMany()
                .HasForeignKey(d => d.TblTiaExtensionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblJobsetTiaExtensions_tblTiaExtensions");
        });

        modelBuilder.Entity<TblQlausTask>(entity =>
        {
            entity.HasKey(e => e.TblQlausTaskId).HasName("PK__tblQlaus__468CE9CFF45F244E");

            entity.ToTable("tblQlausTasks");

            entity.Property(e => e.TblQlausTaskId).HasColumnName("tblQlausTaskID");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.TblRoleId).HasName("PK__tblRoles__C02E1997A7671A56");

            entity.ToTable("tblRoles");

            entity.Property(e => e.TblRoleId).HasColumnName("tblRoleID");
        });

        modelBuilder.Entity<TblTeam>(entity =>
        {
            entity.HasKey(e => e.TblTeamId).HasName("PK__tblTeams__5F1EB477ABA953C4");

            entity.ToTable("tblTeams");

            entity.Property(e => e.TblTeamId).HasColumnName("tblTeamID");
        });

        modelBuilder.Entity<TblTiaExtension>(entity =>
        {
            entity.HasKey(e => e.TblTiaExtensionId).HasName("PK__tblTiaEx__5A11C1C1CF9F6087");

            entity.ToTable("tblTiaExtensions");

            entity.Property(e => e.TblTiaExtensionId).HasColumnName("tblTiaExtensionID");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasMany(d => d.TblComputerUsers)
                .WithOne(p => p.TblUser)
                .HasForeignKey(d => d.TblUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblComputerUsers_tblUsers");
        });


        modelBuilder.Entity<TblUserRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblUserRoles");

            entity.Property(e => e.TblRoleId).HasColumnName("tblRoleID");
            entity.Property(e => e.TblUserId).HasColumnName("tblUserID");

            entity.HasOne(d => d.TblRole).WithMany()
                .HasForeignKey(d => d.TblRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblUserRoles_tblRoles");

            entity.HasOne(d => d.TblUser).WithMany()
                .HasForeignKey(d => d.TblUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblUserRoles_tblUsers");
        });

        modelBuilder.Entity<TblUserTeam>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblUserTeams");

            entity.Property(e => e.TblTeamId).HasColumnName("tblTeamID");
            entity.Property(e => e.TblUserId).HasColumnName("tblUserID");

            entity.HasOne(d => d.TblTeam).WithMany()
                .HasForeignKey(d => d.TblTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblUserTeams_tblTeams");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
