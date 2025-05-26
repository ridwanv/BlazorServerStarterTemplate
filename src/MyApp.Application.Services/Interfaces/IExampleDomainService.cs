namespace CleanArchitecture.Blazor.Application.Services.Interfaces
{
    /// <summary>
    /// Example domain service interface
    /// </summary>
    public interface IExampleDomainService
    {
        Task<string> ProcessDomainLogicAsync(string input);
    }
}