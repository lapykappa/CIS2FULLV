using DbFirstCIS2.DTO;

public interface IStatusComputerDetailsRepository
{
    Task<IEnumerable<StatusComputerDetailsDto>> GetAllStatusComputerDetails();
    Task<StatusComputerDetailsDto> GetStatusComputerDetails(int id);
}
