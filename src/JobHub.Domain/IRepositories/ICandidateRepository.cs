using JobHub.Domain.Entities;
using JobHub.Shared.ApiResponse;


namespace JobHub.Domain.IRepositories;

public interface ICandidateRepository
{
    Task<DataResponse<IEnumerable<Candidate>>> GetAllCandidateAsync(CancellationToken cancellationToken);
    Task<DataResponse<Candidate>> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken);
    Task<DataResponse> AddCandidateAsync(Candidate candidate, CancellationToken cancellationToken);
    Task<DataResponse<Candidate>> UpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken);
}
