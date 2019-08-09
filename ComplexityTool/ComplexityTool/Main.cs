using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            txtSizeScore.Text =  sComplex.operatorsScore(txtCode.Text.ToString()).ToString();
        }
    }
}
