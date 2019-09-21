using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComplexityTool.Size;
using ComplexityTool.Recursion;
using ComplexityTool.Ctc;
using ComplexityTool.Inheritance;
using ComplexityTool.TotalComplexity;
using System.Collections;

namespace ComplexityTool
{
    public partial class Main : Form
    {
        public static List<string> allTokens = new List<string>();

        SizeComplexity sComplex = new SizeComplexity();
        InheritanceComplexity inComplex = new InheritanceComplexity();
        //RecursionComplexity rComplex = new RecursionComplexity();
        RecursionComplexity recursion = new RecursionComplexity();
        TotalComplexity.TotalComplexity tComplex = new TotalComplexity.TotalComplexity();
        CTCClass ctcComplex = new CTCClass();
        CNCClass cncComplex = new CNCClass();

        public Main()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            cncComplex.scoreTable.Clear();
            dataGridView.Rows.Clear();

            GlobalData.ExtendCount = 0;

            String code = txtCode.Text.ToString();

            int scoreCs;
            //int keyCs;
            int scoreInherit;
            int scoreCnc = 0;
            int scoreCps = 0;
            int scoreCr = 0;
            int totalCs = 0;
            int scoreCTC = 0;
            int totalCTC = 0;
            int scoreCNC = 0;
            int totalCNC = 0;
            int totalCps = 0;
            int totalCr = 0;
            int redCps = 0;
            int weight;
            int totalExtendCount = 0;
            Boolean isRec;
            int i = 0;
            string idenTokens = "";
     
            int y = 0;
            int l = 0;

            String methodNameValue = "";
            ArrayList methodListNames = new ArrayList();


            //Remove all comments in the full code
            //code = Regex.Replace(code, @"(//[\t|\s|\w|\d|\.]*[\r\n|\n])|([\s|\t]*/\*[\t|\s|\w|\W|\d|\.|\r|\n]*\*/)|(\<[!%][ \r\n\t]*(--([^\-]|[\r\n]|-[^\-])*--[ \r\n\t%]*)\>)", "");
            code = Regex.Replace(code, @"(@(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/", "");

            //call method to calculate CNC score
            cncComplex.camputeCNCScoreForCode(code);

        

            //separate code into lines
            string[] lines = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            String[] methodArrayName = new string[lines.Length];

            isRec = recursion.isRecursive(code);

            //retrieve each line
            foreach (String line in lines)
            {
                if (String.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
   
                //call method to calculate score
                scoreCs = sComplex.operatorsScore(line);
                scoreCTC = ctcComplex.ComputeScore(line);
                scoreInherit = inComplex.inheritanceScore(line);

                //add to datagrid view
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = i + 1;
                dataGridView.Rows[i].Cells[1].Value = line;
                dataGridView.Rows[i].Cells[2].Value = scoreCs;
                dataGridView.Rows[i].Cells[3].Value = scoreCTC;

            
                if(allTokens != null)
                {
                    foreach(string t in allTokens)
                    {
                        idenTokens = idenTokens + t + " , ";
                    }
                }

                idenTokens = idenTokens.Trim();
                dataGridView.Rows[i].Cells[9].Value = idenTokens.Trim(',');
                idenTokens = "";
                allTokens.Clear();


                //---Welarathne K.T--IT17186070
                if (GlobalData.isExtendedRow)
                {

                    dataGridView.Rows[i].Cells[5].Value = GlobalData.ExtendCount;
                    totalExtendCount = totalExtendCount + GlobalData.ExtendCount;

                    if (Regex.IsMatch(line.ToString(), @"^(public class \w*)"))
                    {
                        dataGridView.Rows[i].Cells[5].Value = 0;
                    }
                }
                else
                {

                    dataGridView.Rows[i].Cells[5].Value = "0";
                }

                if (GlobalData.isInsideOfBrackets)
                {
                    if (Regex.IsMatch(line.ToString(), @"^(\s*try)|^(\s*else\s+\W)|^(\s*else)$|^(\s*else){$|^\s*}(\s*finally)|^}(\s*else\s+\W)|^\s*}(\s*else){$|^\s*}(\s*else)$|^(\s*else)\s*$|^(\s*{\s*)$|^(\s*}\s*)$|^(\s*class \w*)|^(public class \w*)"))
                    {
                        dataGridView.Rows[i].Cells[5].Value = 0;
                        if (Regex.IsMatch(line.ToString(), @"^(\s*else{)"))
                        {
                            dataGridView.Rows[i].Cells[5].Value = 0;
                        }

                    }
                    else
                    {
                        dataGridView.Rows[i].Cells[5].Value = GlobalData.ExtendValueinsideBra;
                        totalExtendCount = totalExtendCount + GlobalData.ExtendValueinsideBra;
                        GlobalData.ExtendValueinsideBra = 0;
                    }

                    GlobalData.isInsideOfBrackets = false;
                    //totalCr = totalCr + int.Parse(dataGridView.Rows[i].Cells[5].Value.ToString());
                }

                GlobalData.isExtendedRow = false;
                GlobalData.ExtendCount = 0;
               
                //calculate total score
                totalCs = totalCs + scoreCs;
                totalCTC = totalCTC + scoreCTC;


                //--Galappaththi I.U.E--IT17165730
                // Recursion Function Starts Here           
                String row = line;
                for (int j = 0; j < 20; j++)
                {
                    row = row.Replace(" (", "(");
                }

                int publicCount = row.Split(new[] { "public" }, StringSplitOptions.None).Length - 1;
                int privateCount = row.Split(new[] { "private" }, StringSplitOptions.None).Length - 1;
                int protectedCount = row.Split(new[] { "protected" }, StringSplitOptions.None).Length - 1;
                String[] publicArray = row.Split(new[] { "public" }, StringSplitOptions.None);
                String[] privateArray = row.Split(new[] { "private" }, StringSplitOptions.None);
                String[] protectedArray = row.Split(new[] { "protected" }, StringSplitOptions.None);

                if ((publicCount > 0) || (privateCount > 0) || (protectedCount > 0))
                {

                    String[] methodVal = "".Split(new[] { "" }, StringSplitOptions.None);
                    if ((publicCount > 0))
                    {
                        // methodVal = pblc_ar[1].Split(new[] { "" }, StringSplitOptions.None);
                        methodVal = publicArray[1].ToCharArray().Select(c => c.ToString()).ToArray();
                    }
                    else if ((privateCount > 0))
                    {
                        // methodVal = pvt_ar[1].Split(new[] { "" }, StringSplitOptions.None);
                        methodVal = privateArray[1].ToCharArray().Select(c => c.ToString()).ToArray();
                    }
                    else if ((protectedCount > 0))
                    {
                        //methodVal = prtd_ar[1].Split(new[] { "" }, StringSplitOptions.None);
                        methodVal = protectedArray[1].ToCharArray().Select(c => c.ToString()).ToArray();
                    }

                    methodNameValue = "";

                    int a = 0;

                    if (row.Split(new[] { "public static void main" }, StringSplitOptions.None).Length > 1)
                    {
                        methodNameValue = "Main Method";
                    }
                    else
                    {
                        for (int j = methodVal.Length - 1; j >= 0; j--)
                        {
                            if (methodVal[j].Equals("("))
                            {
                                a = 1;
                            }
                            if (methodVal[j].Equals(" ") && a == 1)
                            {
                                break;
                            }
                            methodNameValue = methodVal[j] + methodNameValue;
                        }

                    }
                }


                string[] firstMethodArray = methodNameValue.ToCharArray().Select(c => c.ToString()).ToArray();

                String fullMethodName = "";
                int x = 0;
                for (int j = firstMethodArray.Length - 1; j >= 0; j--)
                {

                    if (firstMethodArray[j].Equals("("))
                    {
                        x = 1;

                    }
                    if (x == 1)
                    {
                        fullMethodName = firstMethodArray[j] + fullMethodName;
                    }
                }

                if (fullMethodName.Equals(""))
                {
                    fullMethodName = "abc abc 123 123";
                }

                if (methodNameValue.Equals(""))
                {
                    methodNameValue = "no method";
                }

                //dataGridView.Rows[i].Cells[10].Value = methodNameValue.Replace("[{]", "");
                methodArrayName[i] = methodNameValue.Replace("[{]", "");

                if (row.Contains(methodNameValue))
                {
                    dataGridView.Rows[i].Cells[8].Value = 0;
                }
                else if (row.Contains(fullMethodName))
                {
                    methodListNames.Add(methodNameValue.Replace("[{]", ""));
                    scoreCr = scoreCps * 2;
                    dataGridView.Rows[i].Cells[8].Value = scoreCr;
                }
                else
                {
                    dataGridView.Rows[i].Cells[8].Value = 0;
                }

                i++;
            }

            //--Wimaladasa G.W.P.N--IT17163132
            //Display Cnc values
            int k = 0;
            foreach (KeyValuePair<int, int> ele2 in cncComplex.scoreTable)
            {

                Console.WriteLine("{0} and {1}", ele2.Key, ele2.Value);
                dataGridView.Rows[k].Cells[4].Value = ele2.Value;
                k++;

            }

            //--Yasathilaka W.S.L--IT17163750
            //Calculate weight and total Cps
            i = 0;
            foreach (string line in lines)
            {
                if (String.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                weight = tComplex.getTotalWeight(int.Parse(dataGridView.Rows[i].Cells[3].Value.ToString()), int.Parse(dataGridView.Rows[i].Cells[4].Value.ToString()), int.Parse(dataGridView.Rows[i].Cells[5].Value.ToString()));
                dataGridView.Rows[i].Cells[6].Value = weight;
                scoreCps = tComplex.statementTotalComplexity(int.Parse(dataGridView.Rows[i].Cells[2].Value.ToString()), weight);
                dataGridView.Rows[i].Cells[7].Value = scoreCps;
                totalCps = totalCps + scoreCps;

                i++;
            }

            //--Galappaththi I.U.E--IT17165730
            foreach (String name in methodListNames)
            {
                l = 0;
                foreach (String line in lines)
                {
                    if (String.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    //if (dataGridView.Rows[l].Cells[10].Value.ToString().Equals(name))
                    if (methodArrayName[l].Equals(name))
                    {


                        if (line.Contains(";") || line.Contains("{"))
                        {

                            scoreCps = int.Parse(dataGridView.Rows[l].Cells[7].Value.ToString());
                            scoreCr = scoreCps * 2;
                            totalCr = totalCr + scoreCr;
                            dataGridView.Rows[l].Cells[8].Value = scoreCr;
                            redCps = redCps + int.Parse(dataGridView.Rows[l].Cells[7].Value.ToString());
                        }
                    }

                    l++;
                }

            }



            //Display total Cp
            if (isRec == true)
            {
                txtCp.Text = (totalCps - redCps + totalCr).ToString();
            }
            else
            {
                txtCp.Text = totalCps.ToString();
            }



        }

        //Right click menu for richtextbox
        private void txtCode_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu contextMenu = new ContextMenu();
                MenuItem menuItem = new MenuItem("Cut");
                menuItem.Click += new EventHandler(CutAction);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Copy");
                menuItem.Click += new EventHandler(CopyAction);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Paste");
                menuItem.Click += new EventHandler(PasteAction);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Select All");
                menuItem.Click += new EventHandler(SelectAll);
                contextMenu.MenuItems.Add(menuItem);
                txtCode.ContextMenu = contextMenu;
            }
        }

        void CutAction(object sender, EventArgs e)
        {
            txtCode.Cut();
        }

        void CopyAction(object sender, EventArgs e)
        {
            if (txtCode.SelectedText == "")
            {

                Clipboard.Clear();
            }
            else
            {
                Clipboard.SetText(txtCode.SelectedText);
            }

        }

        void PasteAction(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txtCode.Text += Clipboard.GetText(TextDataFormat.Text).ToString();
            }
        }

        void SelectAll(object sender, EventArgs e)
        {
            txtCode.SelectAll();
            txtCode.Focus();
        }

        public String[] separateMethods(String code)
        {
            String[] methodsArray = { };
            return methodsArray;
        }


    }
}
