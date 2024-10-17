using JobHub.Domain.Entities;
using JobHub.Domain.IRepositories;
using JobHub.Shared.ApiResponse;


namespace JobHub.Infrastructure.Repositoreis;

public class CandidateRepository : ICandidateRepository
{
    public Task<DataResponse> AddOrUpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<DataResponse<IEnumerable<Candidate>>> GetAllCandidateAsync(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<DataResponse<Candidate>> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
