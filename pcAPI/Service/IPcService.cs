using pcAPI.DTOs;

namespace pcAPI.Service;

public interface IPcService
{
    Task<IEnumerable<PCDTO>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<PCDetailsDTO> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    Task<PCDTO> AddAsync(CreatePCDTO request, CancellationToken cancellationToken);
    
    Task UpdateAsync(int id, UpdatePCDTO request, CancellationToken cancellationToken);
    
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}