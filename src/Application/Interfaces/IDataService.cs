namespace Application.Interfaces;

public interface IDataService
{
    Task <bool> ProcessAsync(string inputFilePath, string outputFilePath, CancellationToken cancellationToken = default);
}
