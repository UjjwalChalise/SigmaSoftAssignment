using AutoMapper;
using JobHub.Domain.Entities;
using JobHub.Shared.Dtos;

namespace JobHub.Application.MappingProfiles;

public class CandidateMappingProflie : Profile
{
    public CandidateMappingProflie()
    {
        CreateMap<Candidate, CandidateListDto>();
        CreateMap<CandidateDto, Candidate>();
    }
}
