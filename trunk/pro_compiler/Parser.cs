using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace pro_compiler
{
    public class Parser
    {
        public List<string> OutSet;
        public List<string> LineSet;

        public Parser()
        {
            OutSet = new List<string>();
            LineSet = new List<string>();
        }

        public List<string> GetOutput()
        {
            return LineSet;
        }

        public List<string> GetResult()
        {
            return OutSet;
        }
    }

    /* Packs everything line by line */
    public class FirstRound : Parser
    {
        public FirstRound(TextReader input)
        {
            LineSet = new List<string>();
            Parse(input);
        }

        public void Parse(TextReader input)
        {         
            while (input.Peek() != -1)
            {
                string current = input.ReadLine().Trim();
                LineSet.Add(current);
            }
        }
    }
}
