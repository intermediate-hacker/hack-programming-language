using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pro_compiler
{
    public class FuncTable
    {
        public Dictionary<string, string> NormSet; // normal function calls
        public Dictionary<string, string> ConSet; //conditions e.g if , else etc.
        public Dictionary<string, string> DefSet;

        private FuncTable()
        {
            NormSet = new Dictionary<string, string>();
            ConSet = new Dictionary<string, string>();
            DefSet = new Dictionary<string, string>();

            /* console IO */
            NormSet.Add("writeln", "System.Console.WriteLine");
            NormSet.Add("readln", "System.Console.ReadLine");
            NormSet.Add("write", "System.Console.Write");
            NormSet.Add("read", "System.Console.Read");

            /* processes and environment. */
            NormSet.Add("start", "System.Diagnostics.Process.Start");
            NormSet.Add("exit", "System.Environment.Exit");

            ConSet.Add("if", "if");
            ConSet.Add("else", "else");
            ConSet.Add("while", "while");
            ConSet.Add("for", "for");         

            DefSet.Add("end", "}");
        }      

        private static FuncTable inst = null;

        public static FuncTable Instance
        {
            get
            {
                if (inst == null)
                    inst = new FuncTable();
                return inst;
            }
        }
    }
}
