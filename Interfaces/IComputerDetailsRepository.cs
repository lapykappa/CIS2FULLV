using DbFirstCIS2.DTO;

namespace DbFirstCIS2.Interfaces
{
    public interface IComputerDetailsRepository
    {
        Task<ComputerDetailsDto> GetComputerDetails(int id);
        Task<IEnumerable<ComputerDetailsDto>> GetAllComputerDetails();

        Task UpdateQlausTaskId(int computerId, int newQlausTaskId);
        Task UpdateJobset(int computerId, string newJobsetName);
    }

}
