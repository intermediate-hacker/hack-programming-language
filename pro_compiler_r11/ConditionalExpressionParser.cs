﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pro_compiler
{
    class ConditionalExpressionParser : Parser
    {
        public override string Parse(string line)
        {
            if (ContainsConditionalExpression(line))
            {
                return ParseConditionalExpression(line);
            }
            return line;
        }

        private bool ContainsConditionalExpression(string line)
        {
            var mapping = LanguageMapper.Instance.ConditionMappings;
            var key = line.Split('(')[0].Trim();

            return mapping.ContainsKey(key);
        }

        private string ParseConditionalExpression(string line)
        {
            var mapping = LanguageMapper.Instance.ConditionMappings;
            var key = line.Split('(')[0].Trim();

            line = line.Trim().TrimStart(key.ToCharArray());
            
            return mapping[key] + line + "{";
        }

    }
}
