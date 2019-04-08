using System;
using System.Collections.Generic;
using System.IO;

namespace SigmaCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("basic.sgm");
            SyntaxTree test = Parser.GenerateSyntaxTree(input);
            Parser.AnalyzeSyntaxTree(test);
            Console.WriteLine("Hello THis is a breakpoint");
        }
    }
}

/*
 * E.g ->
 * start
 *  out -> >Hello World< end 
 * end
 * 
 */
