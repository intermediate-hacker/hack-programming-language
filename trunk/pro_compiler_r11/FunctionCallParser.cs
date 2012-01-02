using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pro_compiler
{
    /* Handles the Functions */
    public class FunctionCallParser : Parser
    {
        public override string Parse(string line)
        {         
            if (ContainsFunctionCall(line))
            {
                return ParseFunctionCall(line);
            }         

            return line;
        }

        private bool ContainsFunctionCall(string line)
        {        
            var mapping = LanguageMapper.Instance.FunctionMappings;
            var key = line.Trim().Split(' ')[0];

            return mapping.ContainsKey(key);
        }
     
        private string ParseFunctionCall(string line)
        {
            var mapping = LanguageMapper.Instance.FunctionMappings;
            var key = line.Trim().Split(' ')[0];         

            line = line.TrimStart(key.ToCharArray());
            return mapping[key] + "(" + line + ")" + ";";
        }
    }
}
