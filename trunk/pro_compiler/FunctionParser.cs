using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pro_compiler
{
    /* Parses all the functions declarations */
    class FunctionParser : Parser     
    {        
        public string Parse(ref string input)
        {        
            var rtn = CheckFunction(ref input);
            return rtn;
        }

        public string CheckFunction(ref string line)
        {
            if (line.StartsWith("function"))
            {
                string decl = line.TrimStart("function".ToCharArray());
                decl = decl.Trim();
                if (!decl.Contains("<<"))
                {
                    throw new Exception("Syntax error in function: no '<<' found!");
                }
                line = ProcessFunction(decl);
                Result.Add((string)line.Clone());
                line = null;
            }

            return line;
        }

        public string ProcessFunction(string input)
        {
            input = input.Trim();
            var funcSpt = input.Split("<<".ToCharArray());

            Console.WriteLine(funcSpt[0] + funcSpt[1]);
            //if (funcSpt.Length > 2)
            //{
            //    throw new Exception("Syntax Error in function: more than one '<<' found!");
            //}

            var name = funcSpt[1];
            name = name.Trim();

            var param = funcSpt[2];
            param = ProcessParameters(param);

            var result = SourceTemplate.FuncTop + name + "(" + param + ")" + "{";
            return result;
        }

        public string ProcessParameters(string param)
        {
            param = param.Trim();

            var parSet = param.Split(',');
            var retSet = new List<string>();

            foreach (var par in parSet)
            {
                retSet.Add(string.Concat("dynamic ", par + ","));
            }

            param = "";
            foreach (var par in retSet)
            {
                param += par;
            }

            return param;
        }

        public string GetFunctions()
        {
            string rtn = "";

            foreach (var s in Result)
            {
                rtn += s + "\n";
            }

            return rtn;
        }
    }
}
