using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComplexityTool.Ctc
{
    class CNCClass
    {
        String[] nestWeight = { "if(", "if (", "while(", "while (", "for(", "for (", "do{", "do {", "else{", "else {", "else" };
        public Dictionary<Int32, Int32> scoreTable = new Dictionary<int, int>();

        public void camputeCNCScoreForCode(String code)
        {
            int level = 0;
            int count = 1;
            int score = 0;
            Boolean temp = false;

            foreach (String line in code.Split('\n'))
            {

                //remove double quoted text from the code          
                String modifiedLine = Regex.Replace(line, "\"[^\"]*\"", string.Empty);

                if (String.IsNullOrWhiteSpace(line.Trim()))
                {
                    continue;
                }

                if (temp == true)
                {
                    if (line.Trim().Contains("{"))
                    {
                        level++;
                        Console.WriteLine(line + " ----- " + count + "-----" + level);
                        scoreTable.Add(count, level);
                        count++;
                        temp = false;
                        continue;
                    }
                    else if (line.Trim().EndsWith("}"))
                    {
                        level--;
                        temp = false;
                    }
                }
                else
                {
                    if (nestWeight.Any(modifiedLine.Contains))
                    {
                        temp = true;

                        if (line.Trim().EndsWith("{"))
                        {
                            level++;
                            Console.WriteLine(line + " ----- " + count + "-----" + level);
                            scoreTable.Add(count, level);
                            count++;
                            continue;
                        }
                    }

                    if (level > 0)
                    {
                        if (line.Trim().EndsWith("{"))
                        {
                            level++;
                        }
                        if (line.Trim().EndsWith("}"))
                        {
                            level--;
                        }
                        if (level == 1)
                        {
                            if (line.Trim().EndsWith("}"))
                            {
                                Console.WriteLine("End of Nesting");
                            }
                        }
                    }
                }

                Console.WriteLine(line + " ----- " + count + "-----" + level);
                scoreTable.Add(count, level);
                count++;

            }
        }


        //public int computeCNCScore(String line , Comm com)
        //{
        //    int lineScore = 0;

        //    //remove double quoted text from the code
        //    String sortedLine = Regex.Replace(line, "\"[^\"]*\"", string.Empty);

        //    //remove white spaces in the beginning and the end
        //    String whiteSpacesSortedLine = sortedLine.Trim();



        //    //split line into words
        //    //String[] words = whiteSpacesSortedLine.Split(' ');

        //    String[] nestWeight = { "if", "else", "while", "for" };
        //    String[] brackets = { "{", "}" };
        //    Boolean temp = false;


        //Stack<int> bracketsStack = new Stack<int>();

        ////foreach (String word in words)
        ////{
        //    if (nestWeight.Any(whiteSpacesSortedLine.Contains))
        //    {
        //        temp = true;

        //        if (whiteSpacesSortedLine.Contains("{"))
        //        {
        //            bracketsStack.Push(1);

        //            //while (!whiteSpacesSortedLine.Contains("}"))
        //            //{
        //            //    lineScore++;
        //            //}
        //            bracketsStack.Pop();

        //            lineScore++;
        //        }
        //    }

        //    Console.WriteLine(line);
        ////}

        //    return lineScore;
        //}

    }
}
