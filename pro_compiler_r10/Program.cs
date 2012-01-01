using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pro_compiler
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                throw new ArgumentException("No source files!");
            }

            Compiler.Start(args);
        }
    }
}
