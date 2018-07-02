using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSquare
{
    class shape
    {
        #region attribute

        public int NoCol;
        public int NoRow;
        public int[,] data;
        public int value;
        public string state;
        public shape[] pieces;
        public int position;

        #endregion

        #region constructor

        public shape(int NoRow, int NoCol, int value)
        {
            this.NoCol = NoCol;
            this.NoRow = NoRow;
            this.value = value;
            this.position = 0;
            data = new int[NoRow, NoCol];
            pieces = new shape[12];
            state = "Org";
        }

        #endregion
    }
}
