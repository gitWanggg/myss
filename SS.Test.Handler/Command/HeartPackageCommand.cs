using SS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Test.Handler.Command
{
    class HeartPackageCommand : WrapActionCommand
    {
        public override string Name
        {
            get
            {
                return CommandRoutes.HeartPackage;
            }
        }
        protected override byte[] HandAction(HanderContext context)
        {
            return System.Text.Encoding.UTF8.GetBytes("ok");
        }
    }
}
