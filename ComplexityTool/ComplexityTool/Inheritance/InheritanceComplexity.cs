using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComplexityTool.Inheritance
{
    class InheritanceComplexity
    {

        public int inheritanceScore(String code)
        {
            int flag = 0;
            int score = 0;
            int iteration = 0;
            int extendCount = 0;
            String str = code;
            bool isSameLine = false;
            //split code into words separated by spaces
            String[] words = str.Split(' ');

            //create a array with all characters in the code
            char[] charArray = new char[str.Length];
            charArray = str.ToCharArray();


            try
            {
                isSameLine = true;
                

                foreach (string word in words)
                {
                    ExtendedProperties extendedProperties = new ExtendedProperties();

                    // create as a stack
                    if (word.Contains('{'))
                    {

                        GlobalData.bracketsList.Push(word[word.IndexOf('{')].ToString());          //push words
                    }
                    else if (word.Contains('}'))
                    {

                        GlobalData.bracketsList.Pop();            //pop  words
                    }



                    if (words.Length > 3)
                    {
                        if (word.ToLower().Equals("class"))
                        {
                            extendedProperties.ClassName = words[iteration + 1];

                            string temp = words[iteration + 1];          //store temp

                            if (words[iteration + 2].Equals(":"))
                            {
                                int rowEC = GlobalData.list.Find(x => x.ClassName.Equals(words[iteration + 3])).Value + 1;
                                extendCount = rowEC + extendCount;

                                if (!GlobalData.list.Any(x => x.ClassName.ToLower().Equals(words[iteration + 1].ToLower())))
                                {
                                    extendedProperties.Value = rowEC;
                                    GlobalData.list.Add(extendedProperties);
                                }
                                else
                                {
                                    GlobalData.list.Where(x => x.ClassName.ToLower().Equals(word.ToLower())).ToList().ForEach(x => x.Value = extendCount);
                                }

                                GlobalData.isExtendedRow = true;
                                GlobalData.isInsideOfBrackets = false;
                            }

                            GlobalData.className = words[iteration + 1];
                        }
                        else if (word.ToLower().Equals("class"))
                        {
                            if (!GlobalData.list.Any(x => x.ClassName.ToLower().Equals(word.ToLower())))
                            {
                                extendedProperties.Value = 2;
                                extendedProperties.ClassName = words[iteration + 1];
                                GlobalData.list.Add(extendedProperties);
                            }

                            GlobalData.className = words[iteration + 1];
                        }
                    }
                    if (word.ToLower().Equals("class"))
                    {
                        if (!GlobalData.list.Any(x => x.ClassName.ToLower().Equals(words[iteration + 1].ToLower())))
                        {
                            //extendCount = 2;
                            extendedProperties.Value = 2;
                            extendedProperties.ClassName = words[iteration + 1];
                            GlobalData.list.Add(extendedProperties);
                            //GlobalData.isExtendedRow = true;
                        }


                        GlobalData.className = words[iteration + 1];
                    }

                    if (GlobalData.bracketsList.Count > 0 && !word.Equals("{") && !word.Equals("}") && isSameLine == true && !String.IsNullOrWhiteSpace(word))
                    {
                        GlobalData.ExtendValueinsideBra = GlobalData.list.Find(x => x.ClassName.Equals(GlobalData.className)).Value;
                        GlobalData.isInsideOfBrackets = true;
                        isSameLine = false;
                    }
                    //else
                    //{
                    //    GlobalData.ExtendValueinsideBra = 0;
                    //    GlobalData.isInsideOfBrackets = false;

                    //}

                    iteration++;
                }
                GlobalData.ExtendCount = GlobalData.ExtendCount + extendCount;
                extendCount = 0;
                iteration = 0;

            }
            catch (Exception ex)
            {
                //throw ex;
            }

            return score;
        }
    }
}
