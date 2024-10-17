using AutoMapper;
using JobHub.Application.IServices;
using JobHub.Domain.Entities;
using JobHub.Domain.IRepositories;
using JobHub.Shared.ApiResponse;
using JobHub.Shared.Dtos;
using JobHub.Shared.Enums;

namespace JobHub.Application.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IMapper _mapper;
    public CandidateService(ICandidateRepository candidateRepository,
        IMapper mapper)
    {
        _candidateRepository = candidateRepository;
        _mapper = mapper;
    }

    public async Task<DataResponse<CandidateListDto>> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var respone = new DataResponse<CandidateListDto>();
        var user = await _candidateRepository.GetCandidateByEmailAsync(email, cancellationToken);

        if (user.Data is null)
            return DataResponse<CandidateListDto>.Failure($"Candidate with email {email} is not found.");

        var result = _mapper.Map<CandidateListDto>(user.Data);
        respone.ResponseType = ResponseTypeOption.Success;
        respone.Message = "Data Fetched Successfully";
        respone.Data = result;
        return respone;
    }

    public async Task<DataResponse<IEnumerable<CandidateListDto>>> GetAllCandidateAsync(CancellationToken cancellationToken)
    {
        var respone = new DataResponse<IEnumerable<CandidateListDto>>();
        var allUsers = await _candidateRepository.GetAllCandidateAsync(cancellationToken);

        if (allUsers.Data is null)
            return DataResponse<IEnumerable<CandidateListDto>>.Failure($"No Data Found");

        var result = _mapper.Map<IEnumerable<CandidateListDto>>(allUsers.Data);
        respone.ResponseType = ResponseTypeOption.Success;
        respone.Message = "Data Fetched Successfully";
        respone.Data = result;
        return respone;
    }

    public async Task<DataResponse> AddOrUpdateCandidateAsync(CandidateDto candidate, CancellationToken cancellationToken = default)
    {
        var respone = new DataResponse();

        var existingCandidate = await _candidateRepository.GetCandidateByEmailAsync(candidate.Email, cancellationToken);

        if (existingCandidate.Data != null)
        {
            // Update Existing Candiate

            var updatedCandidate = existingCandidate.Data;

            updatedCandidate.Email = candidate.Email;
            updatedCandidate.FirstName = candidate.FirstName;
            updatedCandidate.LastName = candidate.LastName;
            updatedCandidate.PhoneNumber = candidate.PhoneNumber;
            updatedCandidate.TimeIntervalToCall = candidate.TimeIntervalToCall;
            updatedCandidate.LinkedInProfileUrl = candidate.LinkedInProfileUrl;
            updatedCandidate.GitHubProfileUrl = candidate.GitHubProfileUrl;
            updatedCandidate.FreeTextComment = candidate.FreeTextComment;

            var result = await _candidateRepository.UpdateCandidateAsync(updatedCandidate, cancellationToken);

            respone.Message = result.Message;
            result.ResponseType = ResponseTypeOption.Success;
            result.Data = result.Data;
        }
        else
        {
            // Add New Candidate
            var candidateToAdd = _mapper.Map<Candidate>(candidate);
            var result = await _candidateRepository.AddCandidateAsync(candidateToAdd, cancellationToken);

            respone.Message = result.Message;
            result.ResponseType = ResponseTypeOption.Success;
            result.Data = result.Data;
        }

        return respone;
    }



}
