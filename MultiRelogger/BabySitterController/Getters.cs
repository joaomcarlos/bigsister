using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BigSister
{
    static partial class BSController
    {
        public static List<BabySitter> GetAllBabySitters()
        {
            return BabySitters;
        }
        public static List<Settings> GetAllBabySitterSettings()
        {
            return BabySitterSettings;
        }
        public static BabySitter GetSitterByAlias(string alias)
        {
            return BabySitters.Find(s => s.Sets.Alias == alias);
        }
        public static BabySitter GetAllSittersByAlias(string alias)
        {
            return BabySitters.Find(s => s.Sets.Alias == alias);
        }

    }
}
