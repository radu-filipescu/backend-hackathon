using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Configs
{
    public class CompanyActionsTable
    {
        Dictionary<int, int> actionIdScoreMappings = new Dictionary<int, int>();
        public CompanyActionsTable()
        {
            // recycling stations
            actionIdScoreMappings.Add(7, 1000);
            // solar panels
            actionIdScoreMappings.Add(8, 5000);
            // charging stations
            actionIdScoreMappings.Add(9, 2500);
            // green office
            actionIdScoreMappings.Add(10, 1500);
        }
    }
}
