using MigrationService.Data;

namespace MigrationService.Interfaces
{
    public interface IDataService
    {
        List<MockData> GetMockData(int idProcesso);
    }
}
