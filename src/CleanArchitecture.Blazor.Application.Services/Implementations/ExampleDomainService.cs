using CleanArchitecture.Blazor.Application.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Blazor.Application.Services.Implementations
{
    /// <summary>
    /// Example domain service implementation that contains business logic
    /// </summary>
    public class ExampleDomainService : IExampleDomainService
    {
        private readonly ILogger<ExampleDomainService> _logger;

        public ExampleDomainService(ILogger<ExampleDomainService> logger)
        {
            _logger = logger;
        }

        public Task<string> ProcessDomainLogicAsync(string input)
        {
            _logger.LogInformation("Processing domain logic with input: {Input}", input);
            
            // Complex business logic would go here
            var result = $"Processed: {input}";
            
            return Task.FromResult(result);
        }
    }
}