using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Test.Handler
{
    public static class RConstant
    {
        //##[序号][实例ID][Route]body%%
        public static string MarkBeginChar = "##";
        public static string MarkEndChar = "%%";
        public readonly static byte[] BeginMarkByte = new byte[] { 0x23, 0x23 };//##
        public readonly static byte[] EndMarkByte = new byte[] { 0x25, 0x25 };//%%

        public readonly static byte Semicolon = 0x3B;
    }
}
