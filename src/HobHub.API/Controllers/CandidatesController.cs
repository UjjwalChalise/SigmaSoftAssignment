using JobHub.Application.IServices;
using JobHub.Shared.ApiResponse;
using JobHub.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HobHub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidatesController : ControllerBase
{
    private readonly ICandidateService _candidateService;
    public CandidatesController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    [HttpGet]
    public async Task<DataResponse<IEnumerable<CandidateListDto>>> GetAllCandidtesInformation(CancellationToken cancellationToken = default)
    {
        var result = await _candidateService.GetAllCandidateAsync(cancellationToken);
        return DataResponse<IEnumerable<CandidateListDto>>.Success(result.Message, result.Data);
    }

    [HttpGet("{email}")]
    public async Task<DataResponse<CandidateListDto>> GetCandidtesInformationByEmail(string email, CancellationToken cancellationToken = default)
    {
        var result = await _candidateService.GetCandidateByEmailAsync(email, cancellationToken);
        return DataResponse<CandidateListDto>.Success(result.Message, result.Data);
    }

    [HttpPost]
    public async Task<DataResponse> AddOrUpdateCandidate([FromBody] CandidateDto candidate, CancellationToken cancellationToken = default)
    {
        var result = await _candidateService.AddOrUpdateCandidateAsync(candidate, cancellationToken);
        return DataResponse.Success(result.Message);
    }
}
