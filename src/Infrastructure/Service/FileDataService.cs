using Application.Interfaces;

namespace Infrastructure.Service;

public sealed class FileDataService<TInputData, TOutputData>(
    IFileReader<TInputData> reader,
    IDataMapper<TInputData, TOutputData> mapper,
    IFileWriter<TOutputData> writer) : IDataService

{
    public async Task <bool> ProcessAsync(string inputFilePath, string outputFilePath, CancellationToken cancellationToken = default)
    {
        var rawData = await reader.ReadAsync(inputFilePath, cancellationToken);
        var processedData = mapper.DataMapper(rawData);
        await writer.WriteAsync(processedData, outputFilePath, cancellationToken);
        if (rawData.Count() != processedData.Count())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
