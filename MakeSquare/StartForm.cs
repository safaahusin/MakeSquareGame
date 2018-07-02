using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeSquare
{
    public partial class StartForm : Form
    {
        public static String fileName="";

        public StartForm()
        {
            InitializeComponent();
        }
        private void StartForm_Load(object sender, EventArgs e)
        {
            Label l = new Label();
            l.Text = "input/input1/input2/input3";
            l.SetBounds(140, 100, 30, 89);
            this.Controls.Add(l);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ParallelForm form = new ParallelForm();
            form.Show();
        }

        private void line_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fileName = input.Text;
         
        }
    }
}
