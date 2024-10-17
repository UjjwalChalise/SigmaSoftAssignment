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
        return null;
    }


    [HttpPost]
    public async Task<DataResponse> AddOrUpdateCandidate([FromBody] CandidateDto candidate)
    {

        return null;
    }
}
