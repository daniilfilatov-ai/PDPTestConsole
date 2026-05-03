namespace Application.Interfaces;

public interface IFileWriter<TDataOutput>
{
    public Task WriteAsync(IEnumerable<TDataOutput> people, string filePath, CancellationToken cancellationToken = default);
}
