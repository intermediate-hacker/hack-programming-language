using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pro_compiler
{
    public class LanguageMapper
    {
        public Dictionary<string, string> FunctionMappings; // normal function calls
        public Dictionary<string, string> ConditionMappings; //conditions e.g if , else etc.
        public Dictionary<string, string> DefinitionMappings; // simple syntax definitions

        private LanguageMapper()
        {
            FunctionMappings = new Dictionary<string, string>();
            ConditionMappings = new Dictionary<string, string>();
            DefinitionMappings = new Dictionary<string, string>();

            /* console IO */
            FunctionMappings.Add("writeln", "System.Console.WriteLine");
            FunctionMappings.Add("readln", "System.Console.ReadLine");
            FunctionMappings.Add("write", "System.Console.Write");
            FunctionMappings.Add("read", "System.Console.Read");

            /* processes and environment. */
            FunctionMappings.Add("start", "System.Diagnostics.Process.Start");
            FunctionMappings.Add("exit", "System.Environment.Exit");

            ConditionMappings.Add("if", "if");
            ConditionMappings.Add("else", "else");
            ConditionMappings.Add("while", "while");
            ConditionMappings.Add("for", "for");

            DefinitionMappings.Add("function", "public static dynamic ");
            DefinitionMappings.Add("end", "}");
            DefinitionMappings.Add("#__csc__", "/* INLINE C-SHARP CODE */");
            DefinitionMappings.Add("#__end__", "/* END */");
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
