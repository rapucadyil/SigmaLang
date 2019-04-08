using System;
using System.Collections.Generic;

namespace SigmaCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Token> temp = Parser.Tokenize(" start out -> > hello world < " +
                                               "end");
            Parser.Interpret(temp);
            Console.WriteLine("Hello THis is a breakpoint");
        }
    }
}

/*
 * start
 *  out -> >Hello World< end 
 * end
 * 

 */
