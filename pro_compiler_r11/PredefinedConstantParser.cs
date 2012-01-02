using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pro_compiler
{
    class PredefinedConstantParser : Parser
    {
        public override string Parse(string input)
        {
            if (ContainsPredefinedConstant(input))
            {
                return ParsePredefinedConstant(input);
            }
            return input;
        }

        private bool ContainsPredefinedConstant(string line)
        {
            var mapping = LanguageMapper.Instance.DefinitionMappings;
            var key = line.TrimStart().Split(' ')[0];

            return mapping.ContainsKey(key);
        }

        private string ParsePredefinedConstant(string line)
        {
            var mapping = LanguageMapper.Instance.DefinitionMappings;
            var key = line.TrimStart().Split(' ')[0];

            return mapping[key] + line.TrimStart(key.ToCharArray());
        }
    }
}
