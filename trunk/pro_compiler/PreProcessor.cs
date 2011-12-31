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
        public PreProcessor(TextReader input)
            :base()
        {       
            Parse(input);
        }

        public void Parse(TextReader input)
        {
            while (input.Peek() != -1)
            {
                string current = input.ReadLine().Trim();
                Result.Add(current);
            }
        }

        /* Preprocessor, pretty much useless for now */
        public void PreProcess(ref string input)
        {
            if (input.StartsWith("#"))
            {
                string decl = input.TrimStart('#');

                if (decl.StartsWith("define"))
                {
                    decl = decl.TrimStart("define".ToCharArray()).Trim();
                    var tmp = decl.Split(' ');
                    LanguageMapper.Instance.ConditionMapper.Add(tmp[0], tmp[1]);
                }
            }
        }
    }
}
