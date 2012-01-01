using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pro_compiler
{
    /* Handles the Functions */
    public class FunctionCallParser : Parser
    {
        public string Parse(ref string line)
        {
            ParseConditions(ref line);
            ParseFunctions(ref line);
            ParseDefinitions(ref line);

            return line;
        }

        /* Parses all the functions */
        public void ParseFunctions(ref string line, bool colon = true)
        {
            foreach (var pair in LanguageMapper.Instance.FunctionMapper)
            {
                if (line.StartsWith(pair.Key))
                {
                    string decl = line;
                    decl = decl.TrimStart(pair.Key.ToCharArray()); // remove the function name e.g readln
                    decl = string.Concat(pair.Value + "(", decl, " )" + (colon ? ";" : "")); // substitute it with the C# equivelant
                    line = decl;
                }
            }
        }

        /* Parse conditional expression e.g if , else */
        public void ParseConditions(ref string line)
        {
            foreach (var pair in LanguageMapper.Instance.ConditionMapper)
            {
                if (line.StartsWith(pair.Key))
                {
                    string decl = line;
                    decl = decl.TrimStart(pair.Key.ToCharArray()); // trim the condition keyword e.g "if"
                    decl = string.Concat(pair.Value, decl + " {"); // substitute it with the C# equivelant            
                    line = decl;
                    break;
                }
            }
        }

        public void ParseDefinitions(ref string line)
        {
            foreach (var pair in LanguageMapper.Instance.DefinitionMapper)
            {
                if(line.StartsWith(pair.Key))
                {
                    line = line.TrimStart(pair.Key.ToCharArray());
                    line = string.Concat(pair.Value,line);                    
                }                    
            }
        }
    }
}
