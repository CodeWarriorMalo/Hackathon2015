using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PsuedoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            M2XInterface m = new M2XInterface();
            m.InitializeM2X("26244b19a6376e900e4ca0fe14803f3e", "df5e75e6785ac96a66dcc30087f56e73");
            //df5e75e6785ac96a66dcc30087f56e73
        }
    }
}
