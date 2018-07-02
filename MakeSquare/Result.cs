using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSquare
{
    class Result
    {
        public int[,] matrix;
        public shape[] shape;


        public Result(int[,] matrix, int NoShape, Stack<shape> st)
        {

            this.matrix = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.matrix[i, j] = matrix[i, j];
                }
            }
            shape = new shape[NoShape];

            shape = st.ToArray();
        }
    }
}
