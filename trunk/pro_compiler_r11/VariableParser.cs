using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* syntax: var myvar = 2; */
/* special thanks to codesparkle @ codereview.stackexchange.com */
namespace pro_compiler
{
    /* Handles all the variable declarations */
    public class VariableDeclarationParser : Parser
    {
        public override string Parse(string line)
        {
            if (ContainsVariableDeclaration(line))
            {
                return ParseLine(line);
            }
            return line;
        }

        private bool ContainsVariableDeclaration(string line)
        {
            return line.TrimStart().StartsWith("var");
        }

        private string ParseLine(string line)
        {
            string parsedline = string.Empty;
            foreach (string word in line.Split(' '))
            {
                parsedline += GetFunctionOrVariable(word);
            }
            return parsedline.TrimEnd() + ";";
        }

        /* check if the var declaration contains any functions
            * e.g var input = readln; */
        private string GetFunctionOrVariable(string word)
        {
            string key = word.Trim();
            var mappings = LanguageMapper.Instance.FunctionMappings;
            if (mappings.ContainsKey(key)) return mappings[key] + "() ";
            return word + " ";
        }
    }
}
