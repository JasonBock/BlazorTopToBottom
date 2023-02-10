using EngineAnalyticsWebApp.Shared.Models.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineAnalyticsWebApp.Shared.Services.Data
{
    public interface IAutomobileDataService
    {
        Task<IEnumerable<Automobile>> GetAutomobiles();

        Task AddAutomobile(Automobile automobile);
    }
}
