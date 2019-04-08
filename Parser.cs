using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaCompiler
{
    public enum TokenType
    {
        START,
        ENDPRG,
        OPERATOR,
        STRING,
        NUMBER,
        END_OF_STATEMENT,
        ARROW,
        BOOL
    }


    public class Token
    {
        public string tokVal;
        public TokenType tokType;

        public Token(string val, TokenType type)
        {
            this.tokVal = val;
            this.tokType = type;
        }

        public override string ToString()
        {
            return "Token -> Value : " + this.tokVal + " Type : " + this.tokType;
        }

    }


    public class Parser
    {
        private static List<Token> Tokenize(string input)
        {
            List<Token> tokenized = new List<Token>();

            foreach (var str in input.Split(new Char[] { ' ', '\t', '\r', '\n' }))
            {
                switch (str)
                {
                    case Constants.STARTPROG:
                        tokenized.Add(new Token(str, TokenType.START));
                        break;
                    case Constants.PRINT:
                        tokenized.Add(new Token(str, TokenType.OPERATOR));
                        break;
                    case Constants.IF:
                        tokenized.Add(new Token(str, TokenType.OPERATOR));
                        break;
                    case Constants.ENDIF:
                        tokenized.Add(new Token(str, TokenType.OPERATOR));
                        break;
                    case Constants.STARTLITERAL:
                        tokenized.Add(new Token(str, TokenType.OPERATOR));
                        break;
                    case Constants.ENDLITERAL:
                        tokenized.Add(new Token(str, TokenType.OPERATOR));
                        break;
                    case Constants.END_OF_STATEMENT:
                        tokenized.Add(new Token(str, TokenType.END_OF_STATEMENT));
                        break;
                    case Constants.END_OF_PROGRAM:
                        tokenized.Add(new Token(str, TokenType.ENDPRG));
                        break;
                    case Constants.ARROW:
                        tokenized.Add(new Token(str, TokenType.ARROW));
                        break;
                    case Constants.BOOL_TRUE:
                        tokenized.Add(new Token(str, TokenType.BOOL));
                        break;
                    case Constants.BOOL_FALSE:
                        tokenized.Add(new Token(str, TokenType.BOOL));
                        break;
                    default:
                        tokenized.Add(new Token(str, TokenType.STRING));
                        break;
                }
            }

            return tokenized;
        }


        public static SyntaxTree GenerateSyntaxTree(string sourceFile)
        {
            List<Token> tokens = Tokenize(sourceFile);
            SyntaxTree generatedTree = new SyntaxTree();

            for (int i = 0; i < tokens.Count; i++)
            {
                switch(tokens[i].tokType)
                {
                    case TokenType.OPERATOR:
                        if (tokens[i].tokVal == Constants.PRINT)
                        {
                            generatedTree.nodes.Add(new SynTreeNode("", tokens[i].tokVal));
                            while(tokens[i + 2].tokType != TokenType.END_OF_STATEMENT)
                            {
                                generatedTree.nodes[0].data += tokens[i + 2].tokVal + " ";
                                i++;
                            }
                            generatedTree.nodes.Add(new SynTreeNode("", tokens[i + 2].tokVal));
                        }
                        break;
                }
            }

            return generatedTree;
        }

        public static void AnalyzeSyntaxTree(SyntaxTree compiledSyntax)
        {
            for (int i = 0; i < compiledSyntax.nodes.Count; i++)
            {
                switch(compiledSyntax.nodes[i].opr)
                {
                    case Constants.PRINT:
                        Console.WriteLine(compiledSyntax.nodes[i].data);
                        break;
                }
            }
        }
    }
}