using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pro_compiler
{
    public class LanguageMapper
    {
        public Dictionary<string, string> FunctionMapper; // normal function calls
        public Dictionary<string, string> ConditionMapper; //conditions e.g if , else etc.
        public Dictionary<string, string> DefinitionMapper; // simple syntax definitions

        private LanguageMapper()
        {
            FunctionMapper = new Dictionary<string, string>();
            ConditionMapper = new Dictionary<string, string>();
            DefinitionMapper = new Dictionary<string, string>();

            /* console IO */
            FunctionMapper.Add("writeln", "System.Console.WriteLine");
            FunctionMapper.Add("readln", "System.Console.ReadLine");
            FunctionMapper.Add("write", "System.Console.Write");
            FunctionMapper.Add("read", "System.Console.Read");

            /* processes and environment. */
            FunctionMapper.Add("start", "System.Diagnostics.Process.Start");
            FunctionMapper.Add("exit", "System.Environment.Exit");

            ConditionMapper.Add("if", "if");
            ConditionMapper.Add("else", "else");
            ConditionMapper.Add("while", "while");
            ConditionMapper.Add("for", "for");         

            DefinitionMapper.Add("end", "}");
            DefinitionMapper.Add("#__csc__", "/* INLINE C-SHARP CODE */");
            DefinitionMapper.Add("#__end__", "/* END */");
        }      

        private static LanguageMapper inst = null;

        public static LanguageMapper Instance
        {
            get
            {
                if (inst == null)
                    inst = new LanguageMapper();
                return inst;
            }
        }
    }
}
