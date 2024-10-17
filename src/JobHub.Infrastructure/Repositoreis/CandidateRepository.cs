using JobHub.Domain.Entities;
using JobHub.Domain.IRepositories;
using JobHub.Infrastructure.Data;
using JobHub.Shared.ApiResponse;
using JobHub.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace JobHub.Infrastructure.Repositoreis;

public class CandidateRepository : ICandidateRepository
{
    private readonly JobHubApplicationDbContext _dbContext;
    public CandidateRepository(JobHubApplicationDbContext context)
    {
        _dbContext = context;
    }
    public async Task<DataResponse> AddCandidateAsync(Candidate candidate, CancellationToken cancellationToken)
    {
        var response = new DataResponse<Candidate>();
        using (var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                await _dbContext.Candidates.AddAsync(candidate);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync(cancellationToken);
                return DataResponse<Candidate>.Success("New Candidate added successfully");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                return DataResponse<Candidate>.Failure("An error occurred while adding the new candidate.");
            }
        }
    }

    public async Task<DataResponse<Candidate>> UpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                _dbContext.Candidates.Update(candidate);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return DataResponse<Candidate>.Success("Candidate updated successfully", candidate);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                return DataResponse<Candidate>.Failure("An error occurred while updating the Candidate");
            }
        }
    }

    public async Task<DataResponse<IEnumerable<Candidate>>> GetAllCandidateAsync(CancellationToken cancellationToken)
    {
        var response = new DataResponse<IEnumerable<Candidate>>();

        var existingCandidate = await _dbContext.Candidates.AsNoTracking().ToListAsync();

        response.ResponseType = ResponseTypeOption.Success;
        response.Data = existingCandidate;
        response.Message = "Success!!";
        return response;
    }

    public async Task<DataResponse<Candidate>> GetCandidateByEmailAsync([DataType(DataType.EmailAddress)] string email, CancellationToken cancellationToken)
    {
        var response = new DataResponse<Candidate>();

        var existingCandidate = await _dbContext.Candidates.Where(x => x.Email == email).AsNoTracking().FirstOrDefaultAsync();

        response.ResponseType = ResponseTypeOption.Success;
        response.Data = existingCandidate;
        response.Message = "Success!!";
        return response;
    }
}
