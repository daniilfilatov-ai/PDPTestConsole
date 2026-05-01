using Application.Interfaces;
using Domain.Models;
using Infrastructure.PeopleData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Service;

public sealed class FileDataService<TInputData, TOutputData>(
    IFileReader<TInputData> reader,
    IDataMapper<TInputData, TOutputData> mapper,
    IFileWriter<TOutputData> writer) : IDataService

{
    public async Task ProcessAsync(string inputFilePath, string outputFilePath, CancellationToken cancellationToken = default)
    {
        var rawData = await reader.ReadAsync(inputFilePath, cancellationToken);
        var processedData = mapper.DataMapper(rawData);
        await writer.WriteAsync(processedData, outputFilePath, cancellationToken);
    }
}
