using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MakeSquare
{
    public partial class ParallelForm : Form
    {


        int x = 90;
        int y = 100;
        int prev_y = 100;

        public ArrayList myarray = new ArrayList();
        public ArrayList stateArray = new ArrayList();



        public ParallelForm()
        {

            InitializeComponent();
            String text = FileParallel.ReadFile();
            try
            {
                string[] lines = text.Split('\n');
                int Noshape = int.Parse(lines[0]);
                Console.WriteLine(lines[0]);

                algorthimParallel algo = new algorthimParallel(Noshape);
                shape[] allshape = new shape[Noshape];
                int prev_row = 1;

                for (int i = 0; i < Noshape; i++)
                {
                    String[] splitLine2 = lines[prev_row].Split(' ');
                    Console.WriteLine(splitLine2[0] + splitLine2[1]);
                    int row = int.Parse(splitLine2[0]);
                    int col = int.Parse(splitLine2[1]);

                    shape sh = new shape(row, col, i + 1);
                    for (int k = 0; k < row; k++)
                    {
                        string[] spiltRow = lines[prev_row + 1 + k].Split(' ');
                        int[] binRow = new int[col];
                        for (int r = 0; r < col; r++)
                        {
                            binRow[r] = int.Parse(spiltRow[r]);
                        }
                        for (int j = 0; j < col; j++)
                        {
                            sh.data[k, j] = binRow[j];
                            Console.Write(sh.data[k, j]);
                        }
                        Console.WriteLine("");
                    }
                    allshape[i] = sh;
                    prev_row = prev_row + row + 1;
                }

                Parallel.For(0, Noshape, i =>
                {
                    allshape[i] = moveParallel.generatePiece(allshape[i]);
                });

                int[,] matrix = new int[4, 4];

                Parallel.For(0, 4, i =>
                {
                    Parallel.For(0, 4, j =>
                    {
                        matrix[i, j] = 0;
                    });
                });




                Stack<shape> CurrentNode;
                CurrentNode = new Stack<shape>();
                 algo.perpar(matrix, allshape);
                //ThreadPool.QueueUserWorkItem(state => algo.perpar(matrix, allshape));

                List<ResultParallel> res = algorthimParallel.result;

                string[] shapeState = new String[Noshape];



                foreach (ResultParallel x in algorthimParallel.result)
                {
                    for (int i = 0; i < Noshape; i++)
                    {
                        shapeState[i] = x.shape[i].value.ToString() + " = " + x.shape[i].state;
                    }
                    CreateSquare(4, x.matrix);
                    WriteState(Noshape, shapeState);

                    /*   Parallel.Invoke(() =>
            {
                CreateSquare(4, x.matrix);

            },  // close first Action

                          () =>
                                             {
                                                 WriteState(Noshape, shapeState);


                                             });
            */
                }
                if (res.Count() == 0)
                {
                    var noSol = new Label();
                    noSol.Text = "Sooorry No Solution :'(";
                    noSol.SetBounds(140, y + 30, 350, 90);
                    noSol.Font = new System.Drawing.Font("Mistral", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    noSol.ForeColor = Color.DarkGoldenrod;

                    this.Controls.Add(noSol);
                    System.Windows.Forms.PictureBox pictureBox1 = new System.Windows.Forms.PictureBox();

                    //rsz_2.jpg
                    pictureBox1.Image = Image.FromFile("rsz_2.jpg");
                    pictureBox1.Location = new System.Drawing.Point(228, 180);
                    pictureBox1.SetBounds(150, y + 130, 700, 700);
                    pictureBox1.Name = "NoSol";
                    pictureBox1.Size = new System.Drawing.Size(300, 300);
                    pictureBox1.TabIndex = 2;
                    pictureBox1.TabStop = false;

                    this.Controls.Add(pictureBox1);

                }
                else
                {
                    var thanks = new Label();
                    thanks.Text = "( " + algorthimParallel.result.Count().ToString() + " )   Shape ";
                    thanks.SetBounds(230, y, 250, 80);

                    thanks.Font = new System.Drawing.Font("Mistral", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    thanks.ForeColor = Color.PaleVioletRed;

                    this.Controls.Add(thanks);
                    var space = new Label();
                    space.Text = "    ";
                    space.SetBounds(230, y + 80, 50, 30);

                    this.Controls.Add(space);
                }
            }
            catch
            {
                var noSol = new Label();
                noSol.Text = "Enter vaild input please :'(";
                noSol.SetBounds(140, y + 30, 350, 90);
                noSol.Font = new System.Drawing.Font("Mistral", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                noSol.ForeColor = Color.DarkGoldenrod;

                this.Controls.Add(noSol);
                System.Windows.Forms.PictureBox pictureBox1 = new System.Windows.Forms.PictureBox();

                //1649616.gif
                pictureBox1.Image = Image.FromFile("c.gif");
                pictureBox1.Location = new System.Drawing.Point(228, 180);
                pictureBox1.SetBounds(150, y + 130, 700, 700);
                pictureBox1.Name = "NoSol";
                pictureBox1.Size = new System.Drawing.Size(300, 300);
                pictureBox1.TabIndex = 2;
                pictureBox1.TabStop = false;

                this.Controls.Add(pictureBox1);
            }

        }
       
        // write state 
        public void WriteState(int size, String[] stateShape)
        {

            var panel = new TableLayoutPanel();
            panel.RowCount = size;
            panel.BackColor = Color.Gray;


            this.Controls.Add(panel);


            for (int i = 0; i < size; i++)
            {
                var percent = 100f / (float)size;
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, percent));
            }

            for (int i = 0; i < size; i++)
            {
                var state = new Label();
                state.Text = stateShape[i];
                string[] value = stateShape[i].Split();
                //  state.BackColor = Color.Beige;
                //  state.BackColor = Color.GhostWhite;
                //state.BackColor = Color.MistyRose;
                state.BackColor = Color.LightGray;
                Console.WriteLine(stateShape[i]);
                state.Font = new Font(state.Font.FontFamily, 9, FontStyle.Bold);
                switch (value[0])
                {
                    case "1":
                        state.ForeColor = Color.HotPink;
                        break;
                    case "2":
                        state.ForeColor = Color.Snow;
                        break;
                    case "3":
                        state.ForeColor = Color.CornflowerBlue;
                        break;
                    case "4":
                        state.ForeColor = Color.DarkOrchid;
                        break;
                    case "5":
                        state.ForeColor = Color.DarkGoldenrod;
                        break;
                }

                panel.Controls.Add(state, 0, i);
            }



            panel.SetBounds(x + 250, prev_y, 100, 100);
            if (x < 100)
            {
                protectMem p = new protectMem();
                p.enter();
                prev_y = y;
                p.leave();
            }


        }
        private void ParallelForm_Load(object sender, EventArgs e)
        {
            var welcome = new Label();
            welcome.Text = "* Make A Square *";
            welcome.SetBounds(150, 20, 300, 50);
            
            welcome.Font = new System.Drawing.Font("Mistral", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));



            welcome.ForeColor = Color.PaleVioletRed;

            this.Controls.Add(welcome);
            var line = new Label();
            line.Text = " ______________________________________________";

            line.SetBounds(130, 70, 350, 30);
            line.ForeColor = Color.White;

            this.Controls.Add(line);
        }

        // create matrix
        public void CreateSquare(int size, int[,] res)
        {

            var panel = new TableLayoutPanel();
            panel.RowCount = size;
            panel.ColumnCount = size;
            panel.BackColor = Color.Gray;
            panel.Location = new Point(0, 40);


            this.Controls.Add(panel);


            for (int i = 0; i < size; i++)
            {
                var percent = 100f / (float)size;
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, percent));
            }


            for (int i = 0; i < size; i++)
            {


                for (int j = 0; j < size; j++)
                {
                    var button = new Button();

                    if (res[i, j] == 1)
                    {
                        button.Text = "1";

                        button.BackColor = Color.HotPink;

                    }
                    if (res[i, j] == 2)
                    {
                        button.BackColor = Color.Snow;
                        button.Text = "2";
                        button.ForeColor = Color.Black;
                    }
                    if (res[i, j] == 3)
                    {
                        button.BackColor = Color.CornflowerBlue;
                        button.Text = "3";
                        button.ForeColor = Color.Black;
                    }
                    if (res[i, j] == 4)
                    {
                        button.BackColor = Color.Plum;
                        button.Text = "4";
                        button.ForeColor = Color.Black;
                    }
                    if (res[i, j] == 5)
                    {
                        button.BackColor = Color.DarkGoldenrod;
                        button.Text = "5";
                        button.ForeColor = Color.Black;
                    }


                    button.Font = new Font(button.Font.FontFamily, 20, FontStyle.Bold);
                    button.FlatStyle = FlatStyle.Flat;


                    button.Text = string.Format("{0}", (i) * size + j + 1);
                    button.Name = string.Format("Button{0}", button.Text);
                    button.Dock = DockStyle.Fill;


                    panel.Controls.Add(button, j, i);


                }


            }



            panel.SetBounds(x, y, 100, 100);
            if (x < 100)
            {
                protectMem p = new protectMem();
                p.enter();
                prev_y = y;
                y += 130;

                p.leave();
            }





        }
    }
}
