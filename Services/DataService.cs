using MigrationService.Data;
using MigrationService.Interfaces;

namespace MigrationService.Services
{
    public class DataService : IDataService
    {
        public List<MockData> GetMockData(int idProcesso)
        {
            // Dados de mock para diferentes idProcesso
            var mockData = new List<MockData>
        {
            new MockData { IdProcesso = 1, Data = "2023-07-01", Value = "Sample Data 1" },
            new MockData { IdProcesso = 1, Data = "2023-07-02", Value = "Sample Data 2" },
            // Adicione mais dados de mock conforme necessário
        };

            return mockData.Where(md => md.IdProcesso == idProcesso).ToList();
        }
    }
}
