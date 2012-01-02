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
        public string Compile(TextReader reader)
        {
            if (reader == null) throw new Exception("TextReader not valid!");

            StringBuilder result = new StringBuilder(SourceTemplate.Top);

            var preprocessor = new PreProcessor();

            Parser[] ParserRounds = {
                                        new PredefinedConstantParser(),
                                        new ConditionalExpressionParser(),
                                        new VariableDeclarationParser(), 
                                        new FunctionCallParser()//,
                                      //new FunctionParser
                                    };
           
            foreach (var l in preprocessor.Process(reader))
            {
                var line = l;

                foreach (var parser in ParserRounds)
                {
                    line = parser.Parse(line);
                }

                result.Append("\t\t\t" + line + "\n");
            }

            result.Append(SourceTemplate.Bottom);

            return result.ToString();
        }

        public static void Start(string[] args)
        {
            TextReader reader = File.OpenText(args[0]);      

            var compiler = new Compiler();
            var source = compiler.Compile(reader);
            
            string target = args[0].TrimEnd(".hack".ToCharArray());
            target += ".cs";

            compiler.SaveToFile(source, target);            
        }

        public void SaveToFile(string source, string targetFileName)
        {
            TextWriter wsrc = File.CreateText(targetFileName);
            wsrc.WriteLine(source);
            wsrc.Close();
        }
    }
}
