using JobHub.Application.IServices;
using JobHub.Domain.Entities;
using JobHub.Domain.IRepositories;
using JobHub.Shared.ApiResponse;

namespace JobHub.Application.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _candidateRepository;
    public CandidateService(ICandidateRepository candidateRepository)
    {
        _candidateRepository = candidateRepository;
    }

    Task<DataResponse<IEnumerable<Candidate>>> ICandidateService.GetAllCandidateAsync(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public Task<DataResponse> AddOrUpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<DataResponse<Candidate>> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

}
