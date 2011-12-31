using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace pro_compiler
{
    class Scanner
    {
        List<object> result;
        public Scanner(TextReader input)
        {
            result = new List<object>();

        }

        public void Scan(TextReader input)
        {
            while(input.Peek() != -1)
            {
                char ch = (char)input.Peek();

                if(char.IsWhiteSpace(ch))
                {
                    input.Read();
                }

                else if(char.IsLetter(ch) || ch == '_')
                {
                    StringBuilder accum = new StringBuilder();
                        
                    input.Read(); // skip the '"'

                    if(input.Peek() ==  -1)
                    {
                        throw new Exception("unterminated string literal");
                    }

                    while((ch = (char)input.Peek()) != '"')
                    {
                        accum.Append(ch);
                        input.Read();

                        if(input.Peek() == -1)
                        {
                            throw new Exception("unterminated string literal");
                        }
                    }

                    //skip the terminating '"'
                    input.Read();
                    result.Add(accum);
                }
            }
        }
    }
}
