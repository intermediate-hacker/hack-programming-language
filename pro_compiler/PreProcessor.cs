using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace pro_compiler
{
    /* Packs everything line by line */
    public class PreProcessor : Parser
    {      
        public List<string> Process(TextReader input)
        {
            var rtn = new List<string>();

            while (input.Peek() != -1)
            {
                rtn.Add(input.ReadLine().Trim());
            }

            return rtn;
        }

        /* Preprocessor, pretty much useless for now */
        private void PreProcess(string input)
        {
            if (input.StartsWith("#"))
            {
                string decl = input.TrimStart('#');

                if (decl.StartsWith("define"))
                {
                    decl = decl.TrimStart("define".ToCharArray()).Trim();
                    var tmp = decl.Split(' ');
                    LanguageMapper.Instance.ConditionMappings.Add(tmp[0], tmp[1]);
                }
            }
        }
    }
}
