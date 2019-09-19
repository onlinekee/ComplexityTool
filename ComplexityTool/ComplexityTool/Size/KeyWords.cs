using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComplexityTool.Size
{
    class KeyWords
    {
        List<String> variableList = new List<string>();
        List<String> methodList = new List<string>();

        string[] keyWordOperators = new string[] { "void", "long", "double", "int", "float", "String", "printf", "println", "cout", "cin", "if", "for", "while", "do", "switch", "case", "abstract", "boolean", "break", "default", "extends", "implements", "System", "out", "println", "Exception" };

        string[] manipulators = new string[] { "endl", "\n", "ends", "flush" };

        string[] numbers = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

        string[] names = new string[] { "new", "[]" };

        string[] dataTypes = new string[] { "long", "double", "int", "float", "String", "boolean", "float" };

        
        public int KeyWordsScore(String code)
        {
            int count = 0;
            int keyScore = 0;
            String text = code;


            //List<String> variableList = new List<string>();

            //string[] keyWordOperators = new string[] { "void", "long", "double", "int", "float", "String", "printf", "println", "cout", "cin", "if", "for", "while", "do", "switch", "case", "abstract", "boolean", "break", "default", "extends", "implements", "System", "out", "println" };

            //string[] manipulators = new string[] { "endl", "\n", "ends", "flush" };

            //string[] numbers = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            //string[] names = new string[] { "class", "new", "[]" };

            //string[] dataTypes = new string[] { "long", "double", "int", "float", "String", "boolean", "float" };

            int quoteCount = Regex.Matches(code, "\"[^\"]*\"").Count;
            keyScore = keyScore + quoteCount;

            //remove double quoted text from the code
            text = Regex.Replace(text, "\"[^\"]*\"", string.Empty);

            //get variables in the line
            getVariables(text);
            getMethods(text);

            //split code into words separated by spaces
            String[] words = text.Split(' ');

            //create an array with all characters in the code
            char[] charArray = new char[text.Length];
            charArray = text.ToCharArray();

            
            string[] variables = new string[words.Length];
            //variables.Length
       
            try
            {
                int flag = 0;
                

                //if(getMethod(text) != null && (methodList.Any(text.Contains) ==  false))
                //{
                //    methodList.Add(getMethod(text).Substring(0, getMethod(text).IndexOf("(")));
                    
                //    keyScore = keyScore + 1;
                //    //Console.WriteLine(getMethod(text).Substring(0, getMethod(text).IndexOf("(")));

                //}

                //loop the word by word in the code
                foreach (String word in words)
                {
                   
                    if (keyWordOperators.Any(word.Contains))
                    {
                        String[] temp = word.Split('.');
                     
                        foreach(String w in temp)
                        {
                            if (keyWordOperators.Any(word.Contains))
                            {
                                keyScore = keyScore + 1;
                               
                            }
                        }
                        
                    }
                    if (manipulators.Any(word.Contains))
                    {
                        keyScore = keyScore + 1;
                    }
     
                    if (numbers.Any(word.Contains))
                    {
                        
                        keyScore = keyScore + 1;
                    }

                    if (names.Any(word.Contains))
                    {
                        //Console.WriteLine(word);
                        keyScore = keyScore + 1;
                        
                    }

                    if (variableList.Any(word.Contains))
                    {
                        //Console.WriteLine(word);
                        keyScore = keyScore + 1;
                    }

                    if (methodList.Any(word.Contains))
                    {
                        //Console.WriteLine(word);
                        keyScore = keyScore + 1;
                    }

                    if ((flag == 1) && (getMethod(word) == null))
                    {
                        //variableList.Add(word.Replace("(", String.Empty).Replace(")", String.Empty).Trim());
                        //Console.WriteLine(variables[count]);
                        //Console.WriteLine(word.Replace("(", String.Empty).Replace(")", String.Empty));
                        //keyScore = keyScore + 1;
                        count++;
                        
                    }

                    //dataTypes.Any(word.Substring(word.IndexOf(")")).Contains)
                    if (dataTypes.Any(word.Contains))
                    {
                        //Console.WriteLine(word);
                        flag = 1;
                        
                    }
                    else
                    {
                        flag = 0;
                    }

                    


                }


            }
            catch (Exception e)
            {

            }

            return keyScore;
        }

        public String getMethod(String statement)
        {
            String str = statement;
            String method = null;
            String[] words = str.Split(' ');

            string[] methodTypes = new string[] { "public", "private", "void" };

            if (methodTypes.Any(statement.Contains))
            {
                foreach (String word in words)
                {
                    if (word.Contains("("))
                    {
                        method = word.Substring(0, word.IndexOf("(") + 1);
                        break;
                    }

                }
            }

            return method;
        }

        public String getVariables(String statement)
        {
            String str = statement;
            String variable = null;
            int flag = 0;
            String temp = "";
            String[] words = str.Split(' ');

            foreach (String word in words)
            {
              
                if(getMethod(word) == null && flag == 1)
                {
                    if(word.Length > 1 )
                    {
                        
                        if (word.Contains(")"))
                        {
                            temp = word.Substring(0, word.IndexOf(")"));
                        }
                        else
                        {
                            temp = word;
                        }
                        
                        variableList.Add(temp.Replace("(", String.Empty).Replace(")", String.Empty).Replace("[", String.Empty).Trim());
                        //Console.WriteLine(temp.Replace("(", String.Empty).Replace(")", String.Empty).Replace("[", String.Empty).Trim());
                    }
                    
                }

                if (dataTypes.Any(word.Contains))
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                }
            }

            return variable;
        }

        public String getMethods(String statement)
        {
            String str = statement;
            String method = null;
            String[] words = str.Split(' ');

            string[] methodTypes = new string[] { "public", "private", "void" };

            if (methodTypes.Any(statement.Contains))
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

            return method;
        }
    }
}
