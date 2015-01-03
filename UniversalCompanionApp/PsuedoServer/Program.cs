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
            m.InitializeM2X("26244b19a6376e900e4ca0fe14803f3e", "f63302dddf5a42e63bffe192e6fcb920");
        }
    }
}
