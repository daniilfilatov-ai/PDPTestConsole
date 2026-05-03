namespace Application.Interfaces;

public interface IDataMapper<TDataInput, TDataOutput>
{
    public IEnumerable<TDataOutput> DataMapper(IEnumerable<TDataInput> rawData);
}
