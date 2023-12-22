using DbFirstCIS2.DATA;
using DbFirstCIS2.DTO;
using DbFirstCIS2.Interfaces;
using DbFirstCIS2.Models;
using Microsoft.EntityFrameworkCore;

public class ComputerDetailsRepository : IComputerDetailsRepository
{
    private readonly ContinousIntegrationScriptDbContext _context;

    public ComputerDetailsRepository(ContinousIntegrationScriptDbContext context)
    {
        _context = context;
    }

    public async Task<ComputerDetailsDto> GetComputerDetails(int id)
    {
        var computer = await _context.TblComputers
            .Include(c => c.TblComputerUsers)
                .ThenInclude(cu => cu.TblUser)
            .Include(c => c.TblDrives)
                .ThenInclude(d => d.TblDriveSettings)
                    .ThenInclude(ds => ds.TblQlausTask)
            .Include(c => c.TblDrives)
                .ThenInclude(d => d.TblDriveJobsets)
                    .ThenInclude(dj => dj.TblJobset)
            .Include(c => c.TblInterfaces)
            .FirstOrDefaultAsync(c => c.TblComputerId == id);

        if (computer == null)
            return null;

        var interfaceAddress = computer.TblInterfaces.FirstOrDefault()?.Address;
        var userFullName = computer.TblComputerUsers.FirstOrDefault()?.TblUser?.Fullname;
        var drive = computer.TblDrives.FirstOrDefault();
        var driveSetting = drive?.TblDriveSettings.FirstOrDefault();
        var qlausTaskId = driveSetting?.TblQlausTask?.QlausTaskId ?? 0;
        var driveJobset = drive?.TblDriveJobsets.FirstOrDefault();
        var jobset = driveJobset?.TblJobset;
        var jobsetName = jobset?.JobsetName;

        var computerDetailDto = new ComputerDetailsDto
        {
            TblComputerId = computer.TblComputerId,
            ComputerName = computer.ComputerName,
            Comment = computer.Comment,
            Address = interfaceAddress,
            Fullname = userFullName,
            QlausTaskId = qlausTaskId,
            JobsetName = jobsetName
        };

        return computerDetailDto;
    }

    public async Task<IEnumerable<ComputerDetailsDto>> GetAllComputerDetails()
    {
        var computers = await _context.TblComputers
            .Include(c => c.TblComputerUsers)
                .ThenInclude(cu => cu.TblUser)
            .Include(c => c.TblDrives)
                .ThenInclude(d => d.TblDriveSettings)
                    .ThenInclude(ds => ds.TblQlausTask)
            .Include(c => c.TblDrives)
                .ThenInclude(d => d.TblDriveJobsets)
                    .ThenInclude(dj => dj.TblJobset)
            .Include(c => c.TblInterfaces)
            .ToListAsync();

        var computerDetails = computers.Select(computer =>
        {
            var interfaceAddress = computer.TblInterfaces.FirstOrDefault()?.Address;
            var userFullName = computer.TblComputerUsers.FirstOrDefault()?.TblUser?.Fullname;
            var drive = computer.TblDrives.FirstOrDefault();
            var driveSetting = drive?.TblDriveSettings.FirstOrDefault();
            var qlausTaskId = driveSetting?.TblQlausTask?.QlausTaskId ?? 0;
            var driveJobset = drive?.TblDriveJobsets.FirstOrDefault();
            var jobset = driveJobset?.TblJobset;
            var jobsetName = jobset?.JobsetName;

            return new ComputerDetailsDto
            {
                TblComputerId = computer.TblComputerId,
                ComputerName = computer.ComputerName,
                Comment = computer.Comment,
                Address = interfaceAddress,
                Fullname = userFullName,
                QlausTaskId = qlausTaskId,
                JobsetName = jobsetName
            };
        });

        return computerDetails;
    }


    public async Task UpdateQlausTaskId(int computerId, int newQlausTaskId)
    {
        if (newQlausTaskId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(newQlausTaskId), "QlausTaskId cannot be negative.");
        }

        var qlausTask = await _context.TblQlausTasks.FirstOrDefaultAsync(q => q.QlausTaskId == newQlausTaskId);

        if (qlausTask == null)
        {
            qlausTask = new TblQlausTask { QlausTaskId = newQlausTaskId };
            await _context.AddAsync(qlausTask);
            await _context.SaveChangesAsync();
        }

        var driveSetting = await _context.TblDriveSettings.FirstOrDefaultAsync(ds => ds.TblDrive.TblComputerId == computerId);

        if (driveSetting == null)
        {
            driveSetting = new TblDriveSetting { TblDrive = new TblDrive { TblComputerId = computerId } };
            await _context.AddAsync(driveSetting);
            await _context.SaveChangesAsync();
        }

        driveSetting.TblQlausTaskId = qlausTask.TblQlausTaskId;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            throw;
        }
    }








    public async Task UpdateJobset(int computerId, string newJobsetName)
    {

        var jobset = await _context.TblJobsets
            .FirstOrDefaultAsync(js => js.JobsetName == newJobsetName);


        if (jobset == null)
        {
            throw new Exception("The provided JobsetName does not exist in the database");
        }


        var driveJobset = await _context.TblDriveJobsets
            .FirstOrDefaultAsync(dj => dj.TblDrive.TblComputer.TblComputerId == computerId);


        if (driveJobset == null)
        {
            throw new Exception("The DriveJobset does not exist for the given computerId");
        }


        driveJobset.TblJobset = jobset;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {

            Console.WriteLine(ex.InnerException.Message);
            throw;
        }
    }

}


