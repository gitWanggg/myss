using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Service;
namespace SS.Test.Handler.Command
{
    public class AddCommand:WrapActionCommand
    {
        public override string Name
        {
            get
            {
                return CommandRoutes.Add;
            }
        }


        protected override byte[] HandAction(HanderContext context)
        {
            throw new NotImplementedException();
        }
    }
}
