using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSquare
{
    class moveParallel
    {

        #region rotate
        /// <summary>
        /// this function rotate shape 90 degree
        /// </summary>
        /// <param name="s"></param>
        /// <returns>new shape after rotate 90</returns>
        public static shape Rotate90(shape s)
        {

            shape newShape = new shape(s.NoCol, s.NoRow, s.value);
            for (int i = 0; i < s.NoRow; i++)
            {
                for (int j = 0; j < s.NoCol; j++)
                {
                    int newRow = s.NoCol - 1 - j; // new row equal large col -1 - old row
                    int newCol = i; // new col equal old row
                    newShape.data[newRow, newCol] = s.data[i, j];
                }
            }
            newShape.state = "R90";
            return newShape;
        }

        /// <summary>
        /// do rotate 90 twice
        /// </summary>
        /// <param name="s"></param>
        /// <returns>new shape after rotate 180 degree</returns>
        public static shape Rotate180(shape s)
        {
            shape newShape = Rotate90(s);
            newShape = Rotate90(newShape);
            newShape.state = "R180";
            return newShape;
        }

        /// <summary>
        /// rotate 90 three time
        /// </summary>
        /// <param name="s"></param>
        /// <returns>new shape after rotate 270 degree</returns>
        public static shape Rotate270(shape s)
        {
            shape newShape = Rotate180(s);
            newShape = Rotate90(newShape);
            newShape.state = "R270";
            return newShape;
        }
        #endregion
        #region flipfop
        /// <summary>
        /// filp flop vertical 
        /// </summary>
        /// <param name="s"></param>
        /// <returns>new shape after flipflop it</returns>
        public static shape FlipFlopVertical(shape s)
        {
            shape newShape = new shape(s.NoRow, s.NoCol, s.value);

            for (int i = 0; i < s.NoRow; i++)
            {
                for (int j = 0; j < s.NoCol; j++)
                {
                    int newRow = s.NoRow - 1 - i;//new row equal large col -1 - old row
                    int newCol = j; // new col equal old col
                    newShape.data[newRow, newCol] = s.data[i, j];
                }
            }
            newShape.state = "FV";
            return newShape;
        }

        public static shape FlipFlopHorzental(shape s)
        {
            shape newShape = new shape(s.NoRow, s.NoCol, s.value);
            for (int i = 0; i < s.NoRow; i++)
            {
                for (int j = 0; j < s.NoCol; j++)
                {
                    int newRow = i;//new row equal old row
                    int newCol = s.NoCol - 1 - j; // new col equal large col -1- old col
                    newShape.data[newRow, newCol] = s.data[i, j];
                }
            }
            newShape.state = "FH";
            return newShape;
        }
        #endregion

        public static shape generatePiece(shape s)
        {
            s.pieces[0] = s;
            s.pieces[1] = moveParallel.Rotate90(s);
            s.pieces[2] = moveParallel.Rotate180(s);
            s.pieces[3] = moveParallel.Rotate270(s);

            Parallel.Invoke(() =>
            {
                s.pieces[4] = moveParallel.FlipFlopVertical(s);

            }, //close second Action
            () =>
               {
                s.pieces[5] = moveParallel.FlipFlopHorzental(s);

                }, //close second Action
                () =>
                 {
                                       s.pieces[6] = moveParallel.FlipFlopHorzental(s.pieces[1]);
                                       s.pieces[6].state = "R90 + FH";

                                   }, //close second Action
                                    () =>
                                    {
                                        s.pieces[7] = moveParallel.FlipFlopVertical(s.pieces[1]);
                                        s.pieces[7].state = "R90 + FV";

                                    }, //close second Action
                                     () =>
                                     {
                                         s.pieces[8] = moveParallel.FlipFlopHorzental(s.pieces[2]);
                                         s.pieces[8].state = "R180 + FH";

                                     }, //close second Action
                                      () =>
                                      {
                                          s.pieces[9] = moveParallel.FlipFlopVertical(s.pieces[2]);
                                          s.pieces[9].state = "R180 + FV";

                                      }, //close second Action

                                      () =>
                                      {
                                          s.pieces[10] = moveParallel.FlipFlopHorzental(s.pieces[3]);
                                          s.pieces[10].state = "R270 + FH";

                                      }, //close second Action

                                      () =>
                                      {
                                          s.pieces[11] = moveParallel.FlipFlopVertical(s.pieces[3]);
                                          s.pieces[11].state = "R270 + FV";

                                      });




            return s;

        }
    }
}
