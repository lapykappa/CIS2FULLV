using DbFirstCIS2.DATA;
using DbFirstCIS2.DTO;
using Microsoft.EntityFrameworkCore;

public class StatusComputerDetailsRepository : IStatusComputerDetailsRepository
{
    private readonly ContinousIntegrationScriptDbContext _context;

    public StatusComputerDetailsRepository(ContinousIntegrationScriptDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<StatusComputerDetailsDto>> GetAllStatusComputerDetails()
    {
        var computers = await _context.TblComputers
        .Include(c => c.TblInterfaces)
        .ToListAsync();

        var statusComputerDetails = computers.Select(computer =>
        {
            var interfaceAddress = computer.TblInterfaces.FirstOrDefault()?.Address;

            return new StatusComputerDetailsDto
            {
                ComputerName = computer.ComputerName,
                Comment = computer.Comment,
                Address = interfaceAddress
            };
        });

        return statusComputerDetails;
    }
    public async Task<StatusComputerDetailsDto> GetStatusComputerDetails(int id)
    {
        var computer = await _context.TblComputers
        .Include(c => c.TblInterfaces)
        .FirstOrDefaultAsync(c => c.TblComputerId == id);

        if (computer == null)
            return null;

        var interfaceAddress = computer.TblInterfaces.FirstOrDefault()?.Address;

        var statusComputerDetails = new StatusComputerDetailsDto
        {
            ComputerName = computer.ComputerName,
            Comment = computer.Comment,
            Address = interfaceAddress
        };

        return statusComputerDetails;
    }
}

