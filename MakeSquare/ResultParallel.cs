using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSquare
{
    class ResultParallel
    {
        public int[,] matrix;
        public shape[] shape;


        public ResultParallel(int[,] matrix, int NoShape, Stack<shape> st)
        {

            this.matrix = new int[4, 4];
           
                Parallel.For(0, 4, i =>
               {
                   Parallel.For(0, 4, j =>
                   {
                       this.matrix[i, j] = matrix[i, j];
                   });
               });
           
            shape = new shape[NoShape];

                shape = st.ToArray();

        }
    }
}
