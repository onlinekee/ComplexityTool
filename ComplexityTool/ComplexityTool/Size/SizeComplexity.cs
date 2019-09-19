using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComplexityTool.Size
{
    class SizeComplexity
    {
        List<String> variableList = new List<string>();
        List<String> methodList = new List<string>();

        public int operatorsScore(String code)
        {
            int flag = 0;
            int chflag = 0;
            int score = 0;
            string quotes = "";
            int quoteCount = Regex.Matches(code, "\"[^\"]*\"").Count;

            

            score = score + quoteCount;

            //remove double quoted text from the code
            string str = Regex.Replace(code, "\"[^\"]*\"", string.Empty);
           
            //split code into words separated by spaces
            //string[] words = str.Split(' ');

            str = str.Trim();
            string[] words = str.Split(new[] { " ", ";", ".", ",", "(", ")", "[", "]", "{", "}" }, StringSplitOptions.None);

            //create a array with all characters in the code
            char[] charArray = new char[str.Length];
            charArray = str.ToCharArray();

            if ((words[0] == "import") || words[0] == "package" || str.Contains("class"))
            {
                score = 0;
            }
            else {
            
                try
                {
                    
                   
                    //loop the word by word in the code
                    foreach (String word in words)
                    {
                        String tWord = word.Trim().ToString();

                        if (String.IsNullOrWhiteSpace(tWord))
                        {
                            continue;
                        }
                        else
                        {
                            string[] singleOperators = new string[] { "+", "-", "*", "/", "%", ">", "<", "!", "|", "^", "~", "=" };

                            string[] otherOperators = new string[] { "++", "--", "==", "<<", ">>", "!=", ">=", "<=", "&&", "||", "->", "::", "+=", "-=", "*=", "/=", ">>>=", "|=", "&=", "%=", "<<=", ">>=", "^=", ">>>", "<<<" };

                            string[] notConsidered = new string[] { "public", "static", "else", "try", "return" };


                            if(tWord.Contains("<") && tWord.Contains(">"))
                            {
                                string[] tempArr = tWord.Split(new[] { "<", ">" }, StringSplitOptions.None);

                            }

                            if (otherOperators.Any(tWord.Contains))
                            {
                                if (otherOperators.Any(tWord.Equals))
                                {
                                    Main.allTokens.Add(tWord.ToString());
                                    score = score + 1;
                                }
                                else
                                {
                                    foreach (string op in otherOperators)
                                    {
                                        if (tWord.Contains(op))
                                        {
                                            Main.allTokens.Add(op.ToString());
                                            score = score + 1;
                                        }
                                    }

                                    string[] temp = tWord.Split(otherOperators, StringSplitOptions.None);

                                    if (temp != null)
                                    {
                                        foreach (string t in temp)
                                        {
                                            if (t.Length > 0 && isName(t))
                                            {
                                                Main.allTokens.Add(t.ToString());
                                                score = score + 1;

                                            }
                                            else if (isNumber(t))
                                            {
                                                Main.allTokens.Add(t.ToString());
                                                score = score + 1;
                                            }
                                        }
                                    }
                                }





                            }
                            else if (singleOperators.Any(tWord.Contains))
                            {
                                if (singleOperators.Any(tWord.Equals))
                                {
                                    Main.allTokens.Add(tWord.ToString());
                                    score = score + 1;
                                }
                                else
                                {
                                    if (tWord.Contains("<") && tWord.Contains(">"))
                                    {

                                    }
                                    else
                                    {
                                    
                                        foreach (string op in singleOperators)
                                        {

                                            if (tWord.Contains(op.ToString()))
                                            {
                                                Main.allTokens.Add(op.ToString());
                                                score = score + 1;
                                            }
                                        }
                                    }

                                    string[] temp = tWord.Split(singleOperators, StringSplitOptions.None);

                                    if (temp != null)
                                    {
                                        foreach (string t in temp)
                                        {
                                            if (t.Length > 0 && isName(t))
                                            {
                                                Main.allTokens.Add(t.ToString());
                                                score = score + 1;

                                            }else if (isNumber(t))
                                            {
                                                Main.allTokens.Add(t.ToString());
                                                score = score + 1;
                                            }
                                        }
                                    }
                                }

                            }
                            else if (tWord.Trim().Equals("new") || tWord.Trim().Equals("delete") || tWord.Trim().Equals("throw") || tWord.Trim().Equals("throws"))
                            {
                                Main.allTokens.Add(tWord.ToString());
                                score = score + 2;
                                //Console.WriteLine(tWord, score);
                            }
                            else if (isKeyword(tWord))
                            {
                                Main.allTokens.Add(tWord.ToString());
                                score = score + 1;
                                //Console.WriteLine(tWord, score);

                            }
                            else if (isName(tWord) && !notConsidered.Any(tWord.Contains))
                            {
                                Main.allTokens.Add(tWord.ToString());
                                score = score + 1;
                                //Console.WriteLine(tWord, score);
                            }                            
                            else if ((tWord.Length > 1) && (tWord.Substring(0, 1) == "&") && Regex.IsMatch(tWord.Substring(1, 1), @"^[a-zA-Z]+$"))
                            {
                                Main.allTokens.Add(tWord.ToString());
                                score = score + 2;
                                //Console.WriteLine(tWord, score);

                            }
                            else if ((tWord.Length > 1) && (tWord.Substring(0, 1) == "*"))
                            {
                                Main.allTokens.Add(tWord.ToString());
                                score = score + 1;
                                //Console.WriteLine(tWord, score);

                            }else if (isNumber(tWord))
                            {
                                Main.allTokens.Add(tWord.ToString());
                                score = score + 1;
                            }

                            if (tWord.Contains("//"))
                            {
                                score = score - 1;
                            }

                            //if(quoteCount > 0)
                            //{
                            //    Main.allTokens.Add(quotes);
                            //    quotes = "";
                            //}
                        }                       
                       
                    }

                    //add quoted texts
                    Regex regex = new Regex("\"(.*?)\"");

                    var matches = regex.Matches(code);

                    foreach (Match match in matches)
                    {
                        Main.allTokens.Add("\"" + match.Groups[1] + "\"");
                    }

                    //loop characters in the charArray
                    foreach (char ch in charArray)
                    {

                        //check for "." and ","
                        if (Regex.IsMatch(ch.ToString(), @"^[,.]"))
                        {
                            Main.allTokens.Add(ch.ToString());
                            score = score + 1;
                        }

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            return score;
        }

        public Boolean isKeyword(String word)
        {
            string[] keyWords = new string[] { "void", "long", "double", "int", "float", "String", "string",
                "printf", "print", "cout", "cin", "if", "for", "while", "do", "switch", "case", "abstract",
                "boolean", "break", "default", "extends", "implements", "System", "out", "println", "Exception",
                "continue",  "enum", "instanceof", "transient", "assert", "catch", "goto", "short", "synchronized",
                "boolean", "char", "final", "interface", "this", "class", "strictfp", "volatile", "byte", "const",
                "native", "super" };

            string[] manipulators = new string[] { "endl", "ends", "flush", "dec", "hex", "oct", "resetiosflags", "setbase",
                "setfill", "setiosflags", "setprecision", "setw", "\n" };

            if (keyWords.Any(word.Contains))
            {
                return true;
            }else if (manipulators.Any(word.Contains))
            {
                return true;
            }else
            {
                return false;
            }

        }

        public void findMethods(String line)
        {
            String str = line;
            String method = null;
            String[] words = str.Split(' ');

            string[] methodTypes = new string[] { "public", "private", "void" };

            if (methodTypes.Any(line.Contains))
            {
                foreach (String word in words)
                {
                    if (word.Contains("("))
                    {
                        method = word.Substring(0, word.IndexOf("(") + 1);
                        methodList.Add(method);
                        //Console.WriteLine(method);
                    }

                }
            }


        }

        public Boolean isName(String word)
        {
            if((Regex.IsMatch(word.Substring(0, 1), @"^[a-zA-Z]+$")) || (word.Substring(0, 1).Equals('_')))
            {
                return true;
                
            }
            else
            {
                return false;
            }
        }

        public Boolean isNumber(String word)
        {
            if(Regex.IsMatch(word, @"^[0-9.9]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
