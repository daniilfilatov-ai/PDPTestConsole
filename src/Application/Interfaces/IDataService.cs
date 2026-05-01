using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces;

public interface IDataService
{
    Task ProcessAsync(string inputFilePath, string outputFilePath, CancellationToken cancellationToken = default);
}
