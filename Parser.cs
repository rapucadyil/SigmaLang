using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaCompiler
{
    public enum TokenType
    {
        START,
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
        public static List<Token> Tokenize(string input)
        {
            List<Token> tokenized = new List<Token>();

            foreach(var str in input.Split(new Char[] { ' ' })) {
                switch(str)
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

        public static void Interpret(List<Token> tokens)
        {
            for (int i = 0; i < tokens.Count; i++) {
                switch(tokens[i].tokType)
                {
                    case TokenType.OPERATOR:
                        if (tokens[i].tokVal == Constants.PRINT)
                        {
                            if (tokens[i+1].tokType == TokenType.ARROW)
                            {
                                if (tokens[i + 2].tokType == TokenType.OPERATOR 
                                    && tokens[i + 2].tokVal == Constants.STARTLITERAL)
                                {
                                    List<string> toPrint = new List<string>();

                                    while (tokens[i].tokVal != Constants.ENDLITERAL)
                                    {
                                        toPrint.Add(tokens[i + 2].tokVal);
                                        i++;
                                    }
                                    for (int j = 0; j < toPrint.Count; j++)
                                    {
                                        if (toPrint[j] == ">")
                                        {
                                            toPrint.Remove(toPrint[j]);
                                            
                                        }
                                        if (toPrint[j] == "<")
                                        {
                                            toPrint.Remove(toPrint[j]);

                                        }
                                        if (toPrint[j] == "end")
                                        {
                                            toPrint.Remove(toPrint[j]);

                                        }
                                    }
                                    foreach(var str in toPrint)
                                    {
                                        Console.WriteLine(str);
                                    }
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                            }
                        }
                        else if (tokens[i].tokVal == Constants.IF)
                        {
                            Console.WriteLine("Start IF found!");
                        }
                        else if (tokens[i].tokVal == Constants.ENDIF)
                        {
                            Console.WriteLine("End IF found!");
                        }else if (tokens[i].tokVal == Constants.STARTLITERAL)
                        {
                            Console.WriteLine("START Literal > found");
                        }else if (tokens[i].tokVal == Constants.ENDLITERAL)
                        {
                            Console.WriteLine("END Literal < found");
                        }
                        break;

                    case TokenType.ARROW:
                        Console.WriteLine("ARROW operator found!");
                        break;

                    case TokenType.START:
                        break;
                    case TokenType.END_OF_STATEMENT:
                        break;
                }
            }
        }
    }
}
