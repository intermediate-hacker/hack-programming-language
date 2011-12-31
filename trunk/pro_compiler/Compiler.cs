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
        public static string outsrc;    
        public Compiler(TextReader src)
        {
            var r1 = new PreProcessor(src);
            var r2 = new VariableDeclarationParser();
            var r3 = new FunctionCallParser();
            var r4 = new FunctionParser();

            outsrc = SourceTemplate.Top;
            foreach (var l in r1.Result)
            {
                var line = l;
                line = r2.Parse(line);
                r3.Parse(ref line);
                outsrc += "            " + line + "\n";
            }

            outsrc = string.Concat(outsrc, SourceTemplate.Bottom);
        }

        public string GetSource()
        {
            return outsrc;
        }

        public static void Start(string[] args)
        {
            TextReader src = File.OpenText(args[0]);      

            var com = new Compiler(src);
            
            string target = args[0].TrimEnd(".hack".ToCharArray());
            target += ".cs";            

            RunCSC(target);
        }

        public static void RunCSC(string target)
        {
            TextWriter wsrc = File.CreateText(target);
            wsrc.WriteLine(Compiler.outsrc);
            wsrc.Close();

            //string exetar = target.TrimEnd(".cs".ToCharArray());
            //exetar += ".exe";

            //ProcessStartInfo sinfo = new ProcessStartInfo();
            //sinfo.FileName = "csc.exe";
            //sinfo.Arguments = " /out:" + exetar + " " + target;
            //Process.Start(sinfo);
        }
    }
}
