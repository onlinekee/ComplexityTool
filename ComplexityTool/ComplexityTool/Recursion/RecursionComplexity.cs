using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComplexityTool.Recursion
{
    class RecursionComplexity
    {

        //public Boolean isRec(String code)
        //{
        //    Boolean indication = false;
        //    String recMethod = null;

        //    //separate code into lines
        //    string[] statements = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        //    //String[] words = code.Split(' ');

        //    //retrieve each line and check for a recursiveMethod
        //    foreach (String line in statements)
        //    {
        //        String lines = line.Trim();
        //        //Console.WriteLine(statements);
        //        if (recMethod != null)
        //        {
        //            if (getMethod(lines) != null)
        //            {
        //                recMethod = getMethod(lines);
        //                Console.WriteLine(recMethod);
        //                continue;

        //            }
        //            String[] words = lines.Split(' ');

        //            foreach (String word in words)
        //            {
        //                String tWord = word.Trim();
        //                //Console.WriteLine(tWord);
        //                if (tWord.Contains(recMethod))
        //                {
        //                    Console.WriteLine(word);
        //                    indication = true;
        //                    break;
        //                }
        //                else
        //                {
        //                    indication = false;
        //                }
        //            }
        //        }
        //        else
        //        {

        //            recMethod = getMethod(lines);
        //        }

        //        if (indication == true)
        //        {
        //            break;
        //        }

        //    }

        //    return indication;
        //}

        public String getMethod(String statement)
        {
            String newStr = statement;
            String method = null;
            String[] words = newStr.Split(' ');

            string[] methodTypeWords = new string[] { "public", "private", "void" };

            if (methodTypeWords.Any(statement.Contains))
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

        public Boolean isRecursive(String code)
        {
            Boolean flag = false;
            String method = null;

            //separate code into lines
            string[] lines = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            //String[] words = code.Split(' ');

            //retrieve each line and check for a method
            foreach (String line in lines)
            {
                String tLine = line.Trim();
                //Console.WriteLine(tLine);
                if (method != null)
                {
                    if(getMethod(tLine) != null)
                    {
                        method = getMethod(tLine);
                        //Console.WriteLine(method);
                        continue;

                    }
                    String[] words = tLine.Split(' ');

                    foreach (String word in words)
                    {
                        String tWord = word.Trim();
                        //Console.WriteLine(tWord);
                        if (tWord.Contains(method))
                        {
                            //Console.WriteLine(word);
                            flag = true;
                            break;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
                else {

                    method = getMethod(tLine);
                }

                if (flag == true)
                {
                    break;
                }
            }

            return flag;
        }

        //public String getMethod(String statement)
        //{
        //    String str = statement;
        //    String method = null;
        //    String[] words = str.Split(' ');

        //    string[] methodTypes = new string[] { "public", "private", "void" };

        //    if (methodTypes.Any(statement.Contains)){
        //        foreach (String word in words)
        //        {
        //            if (word.Contains("("))
        //            {
        //                method = word.Substring(0, word.IndexOf("(") + 1);
        //                break;
        //            }

        //        }
        //    }

        //    return method;
        //}

        public String[] separateMethods(String code)
        {
            String[] methodsArray = new string[] { };
            String[] methodLines = new string[] { };

            int startIndex = 0;
            int endIndex = 0;
            int counter = 0;
            string temp = null;
            Boolean flag = false;

            string[] lines = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach( string line in lines)
            {
                if(flag == true && getMethod(line) != null)

                if(getMethod(line) != null)
                {
                    //startIndex = counter;
                    methodLines[counter] = line;
                    flag = true;
                    temp = getMethod(line);
                    
                }

                if(temp != getMethod(line))
                {
                    
                }

                counter++;
            }

            return methodsArray;
        }
    }
}
