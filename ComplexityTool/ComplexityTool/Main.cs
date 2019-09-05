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



namespace ComplexityTool
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SizeComplexity sComplex = new SizeComplexity();

            InheritanceComplexity inComplex = new InheritanceComplexity();

            KeyWords keyComplex = new KeyWords();

            //RecursionComplexity rComplex = new RecursionComplexity();

            RecursionComplexity recursion = new RecursionComplexity();

            TotalComplexity.TotalComplexity tComplex = new TotalComplexity.TotalComplexity();

            CTCClass ctcComplex = new CTCClass();

            dataGridView.Rows.Clear();

            GlobalData.ExtendCount = 0;

            String code = txtCode.Text.ToString();
            //String line;
            int scoreCs;
            int keyCs;
            int scoreInherit;
            int scoreCnc = 0;
            int scoreCps = 0;
            int scoreCr = 0;
            int totalCs = 0;
            int scoreCTC = 0;
            int totalCTC = 0;
            int totalCps = 0;
            int totalCr = 0;
            int weight;
            //int totalComplexity = 20;
            int totalExtendCount = 0;
            Boolean isRec;
            int i = 0;


            //Remove all comments in the full code
            //code = Regex.Replace(code, @"(//[\t|\s|\w|\d|\.]*[\r\n|\n])|([\s|\t]*/\*[\t|\s|\w|\W|\d|\.|\r|\n]*\*/)|(\<[!%][ \r\n\t]*(--([^\-]|[\r\n]|-[^\-])*--[ \r\n\t%]*)\>)", "");
            code = Regex.Replace(code, @"(@(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/", "");

            //separate code into lines
            string[] lines = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            isRec = recursion.isRecursive(code);

            //retrieve each line
            foreach (String line in lines)
            {
                //call method to calculate score
                scoreCs = sComplex.operatorsScore(line);
                keyCs = keyComplex.KeyWordsScore(line);
                scoreCTC = ctcComplex.ComputeScore(line);
                scoreInherit = inComplex.inheritanceScore(line);


                //isRec = recursion.isRecursive(line);

                //add to datagrid view
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = i + 1;
                dataGridView.Rows[i].Cells[1].Value = line;
                dataGridView.Rows[i].Cells[2].Value = scoreCs + keyCs;
                dataGridView.Rows[i].Cells[3].Value = scoreCTC;


                if (GlobalData.isExtendedRow)
                {

                    dataGridView.Rows[i].Cells[5].Value = GlobalData.ExtendCount;
                    totalExtendCount = totalExtendCount + GlobalData.ExtendCount;
                }
                else
                {

                    dataGridView.Rows[i].Cells[5].Value = "0";
                }

                if (GlobalData.isInsideOfBrackets)
                {
                    dataGridView.Rows[i].Cells[5].Value = GlobalData.ExtendValueinsideBra;
                    totalExtendCount = totalExtendCount + GlobalData.ExtendValueinsideBra;
                    GlobalData.ExtendValueinsideBra = 0;
                    GlobalData.isInsideOfBrackets = false;
                    totalCr = totalCr + int.Parse(dataGridView.Rows[i].Cells[5].Value.ToString());
                }

                GlobalData.isExtendedRow = false;
                GlobalData.ExtendCount = 0;
       

                //calculate total score
                totalCs = totalCs + scoreCs + keyCs;
                totalCTC = totalCTC + scoreCTC;

                weight = tComplex.getTotalWeight(scoreCTC, scoreCnc, int.Parse(dataGridView.Rows[i].Cells[5].Value.ToString()));
                dataGridView.Rows[i].Cells[6].Value = weight;
                scoreCps = tComplex.statementTotalComplexity(scoreCs, weight);
                dataGridView.Rows[i].Cells[7].Value = scoreCps;
                totalCps = totalCps + scoreCps;

                if (isRec == true)
                {
                    //MessageBox.Show("Recursive");
                    scoreCr = scoreCps * 2;
                    dataGridView.Rows[i].Cells[8].Value = scoreCr;

                }

                else
                {
                    //Recurstion Value is 0
                    dataGridView.Rows[i].Cells[8].Value = "0";
                }

                //scoreCr = scoreCps * 2;

                i++;
            }

 

            //display total score
            txtSizeScore.Text = totalCs.ToString();
            txtTotalCtc.Text = totalCTC.ToString();

            if (isRec == true)
            {
                txtCp.Text = (totalCps + totalCr).ToString();

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
