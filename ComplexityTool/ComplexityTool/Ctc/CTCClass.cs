using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComplexityTool.Ctc
{
    class CTCClass
    {
        public int ComputeScore(String line)
        {
            int lineScore = 0;

            //remove double quoted text from the code
            String sortedLine = Regex.Replace(line, "\"[^\"]*\"", string.Empty);

            //remove white spaces in the beginning and the end
            String whiteSpacesSortedLine = sortedLine.Trim();

            //split line into words
            String[] words = whiteSpacesSortedLine.Split(' ');

            String[] oneWeight = { "if", "case", "catch" };
            String[] twoWeight = { "while", "for" };
            String[] opWeight = { "&&", "&", "||", "|" };
            String temp = "";


            foreach (String word in words)
            {
                if (oneWeight.Any(word.Contains))
                {
                    if (word.Equals("if"))
                    {
                        temp = word;
                    }

                    lineScore++;
                }
                else if (twoWeight.Any(word.Contains))
                {
                    if (word.Equals("while") || word.Equals("for"))
                    {
                        temp = word;
                    }

                    lineScore += 2;
                }
                else if (opWeight.Any(word.Contains))
                {
                    if (temp == "if")
                    {
                        lineScore++;
                    }
                    else if (temp == "for" || temp == "while")
                    {
                        lineScore += 2;
                    }
                }
            }

            //if (line.Contains("if"))
            //{
            //    lineScore++;

            //    if (line.Contains("&&") || line.Contains("&"))
            //    {
            //        lineScore++;
            //    }

            //    if (line.Contains("||") || line.Contains("|"))
            //    {
            //        lineScore++;
            //    }
            //}


            //if (line.Contains("while"))
            //{
            //    lineScore += 2;

            //    if (line.Contains("&&") || line.Contains("&"))
            //    {
            //        lineScore += 2;
            //    }

            //    if (line.Contains("||") || line.Contains("|"))
            //    {
            //        lineScore += 2;
            //    }
            //}

            //if (line.Contains("for"))
            //{
            //    lineScore += 2;

            //    if (line.Contains("&&") || line.Contains("&"))
            //    {
            //        lineScore += 2;
            //    }

            //    if (line.Contains("||") || line.Contains("|"))
            //    {
            //        lineScore += 2;
            //    }
            //}

            //if (line.Contains("catch"))
            //{
            //    lineScore++;

            //}

            //if(line.Contains("case"))
            //{

            //}

            return lineScore;
        }


    }
}
