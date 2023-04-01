using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Configs
{
    public class UserActionsTable
    {
        public Dictionary<int, int> actionIdScoreMappings = new Dictionary<int, int>();
        public UserActionsTable()
        {
            // commuting by bus
            actionIdScoreMappings.Add(1, 50);
            // commuting by bike
            actionIdScoreMappings.Add(2, 100);
            // plastic free 
            actionIdScoreMappings.Add(3, 50);
            // eco quiz
            actionIdScoreMappings.Add(4, 25);
            // planting
            actionIdScoreMappings.Add(5, 300);
            // donating
            actionIdScoreMappings.Add(6, 200);
        }
    }
}
