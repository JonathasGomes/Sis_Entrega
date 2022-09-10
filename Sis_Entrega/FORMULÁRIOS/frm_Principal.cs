using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sis_Entrega
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
        }


        private void SAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Cliente obj_frm_Cliente = new frm_Cliente();
            obj_frm_Cliente.ShowDialog();
        }

        private void cLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PRODUTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Produto obj_frm_Produto = new frm_Produto();
            obj_frm_Produto.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
