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
   
        public int operatorsScore(String code)
        {
            int flag = 0;
            int score = 0;
            String str = code;

            //split code into words separated by spaces
            String[] words = str.Split(' ');
          
            //create a array with all characters in the code
            char[] charArray = new char[str.Length];
            charArray = str.ToCharArray();

 
            try
            {
                //loop characters in the charArray
                foreach (char ch in charArray)
                {
                    //check for "." and ","
                    if (Regex.IsMatch(ch.ToString(), @"^[,.]"))
                    {
                        score = score + 1;
                    }

                }

                //loop the word by word in the code
                foreach (String word in words)
                {
                    //check for double quotes and skip
                    if(Regex.Matches(word, "\"").Count == 2)
                    {
                        flag = 0;
                        continue;
                    }

                    if (Regex.Matches(word, "\"").Count == 1) //check start of a double quote
                    {
                        flag = 1;
                        
                    }

                    if ((flag == 1) && Regex.Matches(word, "\"").Count == 1) //check end of a double quote
                    {
                        flag = 0;
                        continue;
                    }
                    else if(flag == 0) //executes following if word is not within double quotes
                    {

                        string[] singleOperators = new string[] { "+", "-", "*", "/", "%", ">", "<", "!", "|", "^", "~", "=" };

                        string[] otherOperators = new string[] { "++", "--", "==", "<<", ">>", "!=", ">=", "<=", "&&", "||", "->", "::", "+=", "-=", "*=", "/=", ">>>=", "|=", "&=", "%=", "<<=", ">>=", "^=", ">>>", "<<<" };

                        if (otherOperators.Any(word.Contains))
                        {
                            score = score + 1;
                        }
                        else if (singleOperators.Any(word.Contains))
                        {
                            score = score + 1;
                        }

                        if (word.Contains("//"))
                        {
                            score = score - 1;
                        }
                    }
                }

                
            }
            catch(Exception e)
            {

            }

            return score;
        }
    }
}
