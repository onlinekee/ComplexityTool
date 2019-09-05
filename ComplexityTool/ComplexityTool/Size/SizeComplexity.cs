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
            int chflag = 0;
            int score = 0;

            //remove double quoted text from the code
            String str = Regex.Replace(code, "\"[^\"]*\"", string.Empty);
           
            //split code into words separated by spaces
            String[] words = str.Split(' ');
          
            //create a array with all characters in the code
            char[] charArray = new char[str.Length];
            charArray = str.ToCharArray();

            if (words[0] == "import")
            {
                score = 0;
            }
            else {

            
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
                        String tWord = word.Trim();

                        string[] singleOperators = new string[] { "+", "-", "*", "/", "%", ">", "<", "!", "|", "^", "~", "=" };

                        string[] otherOperators = new string[] { "++", "--", "==", "<<", ">>", "!=", ">=", "<=", "&&", "||", "->", "::", "+=", "-=", "*=", "/=", ">>>=", "|=", "&=", "%=", "<<=", ">>=", "^=", ">>>", "<<<" };

                        if (otherOperators.Any(tWord.Contains))
                        {
                            score = score + 1;
                        }
                        else if (singleOperators.Any(tWord.Contains))
                        {
                            score = score + 1;
                        }

                        if (tWord.Contains("//"))
                        {
                            score = score - 1;
                        }

                        if (tWord.Trim().Equals("new") || tWord.Trim().Equals("delete") || tWord.Trim().Equals("throw") || tWord.Trim().Equals("throws"))
                        {
                            score = score + 2;
                        }

                        if ((tWord.Length > 1) && (tWord.Substring(0, 1) == "&") && Regex.IsMatch(tWord.Substring(1, 1), @"^[a-zA-Z]+$"))
                        {

                            score = score + 2;
                        }
                        else if ((tWord.Length > 1) && (tWord.Substring(0, 1) == "*"))
                        {
                            score = score + 1;
                        }
                    }

                }
                catch (Exception e)
                {

                }
            }
            return score;
        }
    }
}
