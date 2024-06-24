using MigrationService.Models;
using System.Collections.Generic;

namespace MigrationService.Services
{
    public interface ISiglaService
    {
        SiglaModel GetSigla(string sigla);
        List<SiglaModel> GetAllSiglas();
    }
}
