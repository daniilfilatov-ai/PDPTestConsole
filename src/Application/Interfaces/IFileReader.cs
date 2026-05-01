namespace Application.Interfaces;

public interface IFileReader<TDataInput>
{
    Task <IEnumerable<TDataInput>> ReadAsync(string filePath, CancellationToken cancellationToken = default);
}
