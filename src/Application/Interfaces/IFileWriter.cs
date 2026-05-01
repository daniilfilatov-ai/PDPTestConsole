using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces;

public interface IFileWriter<TDataOutput>
{
    public Task WriteAsync(IEnumerable<TDataOutput> people, string filePath, CancellationToken cancellationToken = default);
}
