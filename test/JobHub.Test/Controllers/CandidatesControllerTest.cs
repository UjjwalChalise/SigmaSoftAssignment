using HobHub.API.Controllers;
using JobHub.Application.IServices;
using JobHub.Shared.ApiResponse;
using JobHub.Shared.Dtos;
using Moq;

namespace JobHub.API.Tests.Controllers
{
    public class CandidatesControllerTests
    {
        private readonly Mock<ICandidateService> _mockCandidateService;
        private readonly CandidatesController _controller;

        public CandidatesControllerTests()
        {
            _mockCandidateService = new Mock<ICandidateService>();
            _controller = new CandidatesController(_mockCandidateService.Object);
        }

        [Fact]
        public async Task GetAllCandidtesInformation_ReturnsSuccessResponse()
        {
            // Arrange
            var candidates = new List<CandidateListDto>
            {
                new CandidateListDto { FirstName = "John", LastName = "John", Email = "john@example.com" },
                new CandidateListDto { FirstName = "Jane Smith", LastName = "John", Email = "jane@example.com" }
            };
            var response = new DataResponse<IEnumerable<CandidateListDto>>
            {
                Message = "Success",
                Data = candidates
            };
            _mockCandidateService.Setup(s => s.GetAllCandidateAsync(It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(response);

            // Act
            var result = await _controller.GetAllCandidtesInformation();

            // Assert
            var okResult = Assert.IsType<DataResponse<IEnumerable<CandidateListDto>>>(result);
            Assert.Equal("Success", okResult.Message);
            Assert.Equal(candidates, okResult.Data);
        }

        [Fact]
        public async Task GetCandidtesInformationByEmail_ReturnsSuccessResponse()
        {
            // Arrange
            var candidate = new CandidateListDto { FirstName = "John", LastName = "John", Email = "john@example.com" };
            var response = new DataResponse<CandidateListDto>
            {
                Message = "Success",
                Data = candidate
            };
            _mockCandidateService.Setup(s => s.GetCandidateByEmailAsync("john@example.com", It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(response);

            // Act
            var result = await _controller.GetCandidtesInformationByEmail("john@example.com");

            // Assert
            var okResult = Assert.IsType<DataResponse<CandidateListDto>>(result);
            Assert.Equal("Success", okResult.Message);
            Assert.Equal(candidate, okResult.Data);
        }

        [Fact]
        public async Task AddOrUpdateCandidate_ReturnsSuccessResponse()
        {
            // Arrange
            var candidateDto = new CandidateDto(){ FirstName = "John", LastName = "John", Email = "john@example.com" , FreeTextComment ="Test"};
            var response = new DataResponse
            {
                Message = "Candidate added or updated successfully"
            };
            _mockCandidateService.Setup(s => s.AddOrUpdateCandidateAsync(candidateDto, It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(response);

            // Act
            var result = await _controller.AddOrUpdateCandidate(candidateDto);

            // Assert
            var okResult = Assert.IsType<DataResponse>(result);
            Assert.Equal("Candidate added or updated successfully", okResult.Message);
        }

        // Additional Tests

        [Fact]
        public async Task GetCandidtesInformationByEmail_ReturnsFailureResponse_WhenCandidateNotFound()
        {
            // Arrange
            _mockCandidateService.Setup(s => s.GetCandidateByEmailAsync("unknown@example.com", It.IsAny<CancellationToken>()))
                                 .ReturnsAsync((DataResponse<CandidateListDto>)null);

            // Act
            var result = await _controller.GetCandidtesInformationByEmail("unknown@example.com");

            // Assert
            Assert.IsType<DataResponse<CandidateListDto>>(result);
            var response = result as DataResponse<CandidateListDto>;
            Assert.Null(response.Data);
            Assert.Equal("Not Found", response.Message); // Adjust this message as per your implementation
        }

        [Fact]
        public async Task AddOrUpdateCandidate_ReturnsFailureResponse_WhenInvalidCandidate()
        {
            // Arrange
            var candidateDto = new CandidateDto() { FirstName = null, LastName = null, Email = null, FreeTextComment = null };
            var response = new DataResponse
            {
                Message = "Invalid candidate data"
            };
            _mockCandidateService.Setup(s => s.AddOrUpdateCandidateAsync(candidateDto, It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(response);

            // Act
            var result = await _controller.AddOrUpdateCandidate(candidateDto);

            // Assert
            var okResult = Assert.IsType<DataResponse>(result);
            Assert.Equal("Invalid candidate data", okResult.Message);
        }
    }
}
