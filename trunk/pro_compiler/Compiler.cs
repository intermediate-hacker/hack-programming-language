using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace pro_compiler
{
    class Compiler
    {        
        public string Compile(TextReader src)
        {
            string rtn = SourceTemplate.Top;

            var preprocessor = new PreProcessor();

            Parser[] ParserRounds = {
                                        new PredefinedConstantParser(),
                                        new VariableDeclarationParser(), 
                                        new ConditionalExpressionParser(),
                                        new FunctionCallParser()//,
                                      //new FunctionParser
                                    };
           
            foreach (var l in preprocessor.Process(src))
            {
                var line = l;

                foreach (var parser in ParserRounds)
                {
                    line = parser.Parse(line);
                }

                rtn += "\t\t\t" + line + "\n";
            }

            return rtn + SourceTemplate.Bottom;
        }

        public static void Start(string[] args)
        {
            TextReader src = File.OpenText(args[0]);      

            var com = new Compiler();
            var source = com.Compile(src);
            
            string target = args[0].TrimEnd(".hack".ToCharArray());
            target += ".cs";                     
        }

        public void SaveToFile(string source, string target)
        {
            TextWriter wsrc = File.CreateText(target);
            wsrc.WriteLine(source);
            wsrc.Close();
        }
    }
}
