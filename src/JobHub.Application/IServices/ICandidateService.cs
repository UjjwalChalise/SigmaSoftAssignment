using JobHub.Domain.Entities;
using JobHub.Shared.ApiResponse;
using JobHub.Shared.Dtos;

namespace JobHub.Application.IServices;

public interface ICandidateService
{
    Task<DataResponse<IEnumerable<CandidateListDto>>> GetAllCandidateAsync(CancellationToken cancellationToken);
    Task<DataResponse<CandidateListDto>> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken);
    Task<DataResponse> AddOrUpdateCandidateAsync(CandidateDto candidate, CancellationToken cancellationToken);
}
