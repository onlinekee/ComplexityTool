using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComplexityTool.Size;

namespace ComplexityTool
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        SizeComplexity sComplex = new SizeComplexity();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();

            String code = txtCode.Text.ToString();
            String line;
            int scoreCs;
            int totalCs = 0;

            //Read line by line
            for (int i = 0; i < txtCode.Lines.Length; i++)
            {
                line = txtCode.Lines[i];

                //call method to calculate score
                scoreCs = sComplex.operatorsScore(line);

                //add to datagrid view
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = i + 1;
                dataGridView.Rows[i].Cells[1].Value = line;
                dataGridView.Rows[i].Cells[2].Value = scoreCs;

                //calculate total score
                totalCs =  totalCs + scoreCs;
            }

            //display total score
            txtSizeScore.Text = totalCs.ToString(); 

        }

        //Right click menu for richtextbox
        private void txtCode_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
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
            if(txtCode.SelectedText == "")
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
    
    }
}
