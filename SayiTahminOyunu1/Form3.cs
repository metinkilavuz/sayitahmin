using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayiTahminOyunu1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        public void gameOverScreen(int param)
        {
            if (param==0)
            {
                lblEnd.Text = "Malesef meteoru durduramadın.\n Tekrar Oynamak için Tekrar butonuna basınız.";
            }
            else 
            {
                lblEnd.Text = "Tebrikler. Meteoru durdurdun.\n Tekrar Oynamak için Tekrar butonuna basınız.";
            }

        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
