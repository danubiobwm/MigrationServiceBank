using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using System.Data;
using MigrationService.Models;
using MigrationService.Interfaces;

namespace MigrationService.Data
{
    public class ProcedureRepository : IProcedureRepository
    {
        private readonly DatabaseContext _context;

        public ProcedureRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<dynamic>> ExecuteProcedureAsync(string procedureName, Dictionary<string, object> parameters)
        {
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = procedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var param in parameters)
            {
                var dbParam = cmd.CreateParameter();
                dbParam.ParameterName = param.Key;
                dbParam.Value = param.Value;
                cmd.Parameters.Add(dbParam);
            }

            await _context.Database.OpenConnectionAsync();
            var reader = await cmd.ExecuteReaderAsync();

            var result = new List<dynamic>();
            while (await reader.ReadAsync())
            {
                var row = new ExpandoObject() as IDictionary<string, object>;
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.Add(reader.GetName(i), reader[i]);
                }
                result.Add(row);
            }

            await _context.Database.CloseConnectionAsync();
            return result;
        }

        public async Task<IEnumerable<DataModel>> GetDataModelsAsync(int idProcesso)
        {
            var query = await _context.DataModels
                .FromSqlInterpolated($"SELECT * FROM TB_SAFRA_PARAM_DS A INNER JOIN TB_SAFRA_PARAM_ARQ_DS B ON B.id_processo = A.id_processo WHERE A.id_processo = {idProcesso}")
                .ToListAsync();
            return query;
        }
    }
}
