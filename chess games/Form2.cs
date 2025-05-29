using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kk
{
    public partial class Form2 : Form
    {

        public kk.Form1.PieceType PromotedType { get; private set; }
        public Form2()
        {
            InitializeComponent();
        }
       

        private void button2_Click(object sender, EventArgs e)
        {

            PromotedType = kk.Form1.PieceType.Bishop;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnQueen_Click_1(object sender, EventArgs e)
        {
            PromotedType = kk.Form1.PieceType.Queen;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnRook_Click_1(object sender, EventArgs e)
        {
            PromotedType = kk.Form1.PieceType.Rook;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnKnight_Click_1(object sender, EventArgs e)
        {
            PromotedType = kk.Form1.PieceType.Knight;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

