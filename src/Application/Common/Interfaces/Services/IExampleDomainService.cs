namespace CleanArchitecture.Blazor.Application.Common.Interfaces.Services
{
    /// <summary>
    /// Example domain service interface that would be implemented in the Application.Services project
    /// </summary>
    public interface IExampleDomainService
    {
        Task<string> ProcessDomainLogicAsync(string input);
    }
}