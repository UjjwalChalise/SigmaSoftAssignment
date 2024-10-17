﻿using JobHub.Domain.Entities;
using JobHub.Shared.ApiResponse;


namespace JobHub.Domain.IRepositories;

public interface ICandidateRepository
{
    Task<DataResponse<IEnumerable<Candidate>>> GetAllCandidateAsync(string email, CancellationToken cancellationToken);
    Task<DataResponse<Candidate>> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken);
    Task<DataResponse> AddOrUpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken);
}
