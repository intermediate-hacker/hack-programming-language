﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pro_compiler
{
    public class SourceTemplate
    {
        public static string Top =
@"using System;

/* AUTOGENERATED BY HACK COMPILER V 0.1 */
namespace Program
{
    public class MainApp
    {          
        public static void Main(string[] args)
        {   
";

        public static string Bottom =
@"
        }
    }
}
";
    }
}
