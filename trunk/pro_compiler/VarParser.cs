using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pro_compiler
{
    /* Handles all the variable declarations */
    public class VarParser : Parser
    {
        public VarParser( )
            : base()
        {    
        }

        public string Parse(ref string line)
        {
            CheckVariable(ref line);
            return line;
        }

        public void CheckVariable(ref string line)
        {
            /* Check current line for the "var" keyword */
            if (line.StartsWith("var"))
            {
                string decl = line;       
                decl += ';';
                line = decl;
                CheckFunctions(ref line);
            }    
        }

        /* check if the var declaration contains any functions
         * e.g var input = readln; */
        public string CheckFunctions(ref string line)
        {
            var words = line.Split(' '); //check wether each word is a function
            line = ""; // clear the current line

            foreach (var word in words)
            {               
                string w = word.Trim(); //trim all leading and trailing spaces.

                foreach(var pair in FuncTable.Instance.NormSet)
                {
                    if (w.StartsWith(pair.Key)) // if the word is a function 
                    {
                        w = w.Replace(pair.Key, pair.Value + "( )"); // replace it with the C# equivalent
                    }
                }

                w = ((w == words[0]) ? "" : " ") + w; // reinsert trailing and leading spaces
                line += w; // add the words back to the current line
            }

            return line;
        }
    }
}
