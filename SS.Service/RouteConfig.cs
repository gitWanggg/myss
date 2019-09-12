using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    class RouteConfig
    {
        static Dictionary<string, ChainBuilder> DicBuilder;
        public static ChainBuilder FindBuilder(string RouteKey)
        {
            if (DicBuilder.ContainsKey(RouteKey))
                return DicBuilder[RouteKey];
            else
                return null;
        }
        public static void Reg(string RouteKey, ChainBuilder ChBuilder)
        {
            if (DicBuilder.ContainsKey(RouteKey))
                DicBuilder[RouteKey] = ChBuilder;
            else
                DicBuilder.Add(RouteKey, ChBuilder);
        }
        static RouteConfig()
        {
            DicBuilder = new Dictionary<string, ChainBuilder>();
        }

    
    }
}
