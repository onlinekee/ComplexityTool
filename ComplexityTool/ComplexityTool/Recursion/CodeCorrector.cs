using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexityTool.Recursion
{
    class CodeCorrector
    {
        private String txtCode;

        public CodeCorrector()
        {

        }

        public String commentRemover(String txtCode)
        {
            this.txtCode = txtCode;
            return txtCode.Replace("(?:/\\(?:[^]|(?:\\+[^/]))\\+/)|(?://.*)", "");
        }

        public String stringRemover(String txtCode)
        {
            this.txtCode = txtCode;
            String appender = "";

            //indicater indicate to append or not
            Boolean indicator = true;

            int length = txtCode.Length;

            for (int i = 0; i < length; i++)
            {
                //get the character
                char position = txtCode[i];

                if (indicator)
                {
                    //adding character to appender
                    appender = appender + position;
                    //check for string literals
                    if (position == '"')
                    {
                        indicator = false;
                    }
                }
                else
                {
                    if (position == '"')
                    {
                        indicator = true;
                        appender = appender + position;
                    }
                }

            }

            return appender;
        }
    }
}
