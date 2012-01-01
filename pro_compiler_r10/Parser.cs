using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace pro_compiler
{
    public class Parser
    {
        public List<string> result;

        public Parser()
        {
            Output = new List<string>();
            Result = new List<string>();
        }

        public List<string> Output
        {
            get;
            set;
        }

        public List<string> Result
        {
            get;
            set;
        }
    }
}
