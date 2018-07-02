using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSquare
{
    class game
    {
        public bool solution(int[,] matrix)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (matrix[row, col] == 0)
                        return false;
                }
            }

            return true;
        }

        public bool checkInsert(int[,] matrix, shape s)
        {
            bool flag = true;
            for (int row = 0; row < 4; row++)
            {
                if (4 - row >= s.NoRow)
                {

                    for (int col = 0; col < 4; col++)
                    {
                        if (4 - col >= s.NoCol)
                        {
                            flag = true;
                            for (int i = 0, rowMatrix = row; i < s.NoRow; i++, rowMatrix++)
                            {
                                for (int j = 0, colMatrix = col; j < s.NoCol; j++, colMatrix++)
                                {
                                    if (s.data[i, j] == 1 && !(matrix[rowMatrix, colMatrix] == 0))
                                    {
                                        flag = false;
                                        break;
                                    }

                                } // end col shape loop

                                if (!flag)
                                {
                                    break;
                                }

                            } // end row shape loop

                            if (flag)
                            {
                                Insert(matrix, s, row, col);
                                return true;
                            }

                        } // end check col

                    } // end col matrix loop

                }// end if check row

            } // end row matrix loop
            return false;

        } // end function

        public void Insert(int[,] matrix, shape s, int rowMatrix, int colMatrix)
        {
            for (int i = 0, row = rowMatrix; i < s.NoRow; i++, row++)
            {
                for (int j = 0, col = colMatrix; j < s.NoCol; j++, col++)
                {
                    if (s.data[i, j] == 1)
                    {
                        matrix[row, col] = s.value;
                    }
                }
            }
        }
    }
}
