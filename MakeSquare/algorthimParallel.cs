using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MakeSquare
{
    class algorthimParallel
    {
        public Stack<shape> CurrentNode;
        public int NoShape;
        public static List<ResultParallel> result;
        public gameParallel Game;
        public static int finish=0;
        public int shapeFinish = 0;

        public algorthimParallel(int NoShape)
        {
            CurrentNode = new Stack<shape>();
            this.NoShape = NoShape;
            Game = new gameParallel();
            algorthimParallel.result = new List<ResultParallel>();
            
        }
        /// <summary>
        /// function check soluation repeat or not 
        /// call this function in add solution 
        /// </summary>
        /// <param name="mat1">first matrix</param>
        /// <param name="mat2">seconde matrix </param>
        /// <returns>true repeat   false not repeat</returns>
        public bool equal(int[,] mat1, int[,] mat2)
        {
            
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (mat1[i, j] != mat2[i, j])
                            return false;
                    }
                }
            
            return true;
        }
        /// <summary>
        /// add soluation to array list result 
        /// but check at first this solution not repeated
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="node"></param>
        public void AddSolution(int[,] matrix, Stack<shape> node)
        {
            bool flag = true;
            
                lock (algorthimParallel.result)
                {
                    foreach (ResultParallel item in algorthimParallel.result)
                    {
                    if (equal(item.matrix, matrix))
                    {
                        flag = false;
                        return;
                    }

                  
                }

                    
                    ResultParallel res = new ResultParallel(matrix, NoShape, node);
                    if (flag)
                    {
                    algorthimParallel.result.Add(res);
                   
                }
                

                }
            
        }
        /// <summary>
        /// Remove specific shape from matrix
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="value">is int number from 1 to 5 or 4</param>
        public void Removeshape(int[,] matrix, int value)
        {
            lock (matrix)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (matrix[i, j] == value)
                        {
                            matrix[i, j] = 0;
                        }
                    }
                }
             //   Console.WriteLine("remove");
            }
            }
        
        
        /// <summary>
        /// send to our algorthim all combination for shapes
        /// make 2D array busyPostion have 5 postion (0-4)
        /// if Noshape 4 i will use 4 element only
        /// if Noshape 5 i will use all element in 2D
        /// col 1 have (0=>empty,1=>busy)
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="allshape"> array of shape have 4 /5 shape</param>
        /// 


        public shape[] copyFun(shape[] allshape)
        {
            shape[] copy = new shape[NoShape];
           
               for (int i = 0; i < allshape.Length; i++)
                {
                    {
                        copy[i] = allshape[i];
                    }
                }
        
            return copy;
        }
        //async Task

        public async Task perpar(int[,] matrix, shape[] allshape)
        {
            shape[] ConstShape = new shape[5];
            int[][] busyPosition = new int[5][];

           
                for (int i = 0; i < NoShape; i++)
                {
                    ConstShape[i] = allshape[i];
                   // allshape[i] = new shape(1, 1, 0);
                    busyPosition[i] = new int[1];
                    busyPosition[i][0] = 0;
                }

                for (int a = 0; a < NoShape; a++)
                {
                    for (int i = 0; i < NoShape; i++)
                    {
                        allshape[i] = new shape(1, 1, 0);

                        busyPosition[i][0] = 0;
                    }

                    allshape[a] = ConstShape[0];

                    busyPosition[a][0] = 1;

                    Console.WriteLine("a is:" + a.ToString());

                    for (int b = a, IB = 0; IB < NoShape - 1; IB++, b++)
                    {
                        int pos = (b + 1) % NoShape;
                        Console.WriteLine("b is:" + pos.ToString());

                        allshape[pos] = ConstShape[1];

                        busyPosition[pos][0] = 1;

                        for (int c = 0; c < NoShape; c++)
                        {
                            if (busyPosition[c][0] == 0)
                            {
                                Console.WriteLine("c is:" + c.ToString());
                                busyPosition[c][0] = 1;

                                allshape[c] = ConstShape[2];

                                for (int d = 0; d < NoShape; d++)
                                {
                                    if (busyPosition[d][0] == 0)
                                    {
                                        Console.WriteLine("d is:" + d.ToString());
                                        busyPosition[d][0] = 1;

                                        allshape[d] = ConstShape[3];

                                        if (NoShape == 5)
                                        {
                                            for (int e = 0; e < NoShape; e++)
                                            {
                                                if (busyPosition[e][0] == 0)
                                                {
                                                   

                                                    allshape[e] = ConstShape[4];

                                                   

                                                shape[] copyarray = copyFun(allshape);
                                                List<Task> TaskList = new List<Task>();
                                                TaskList.Add(OurAlgorthim(matrix, copyarray));
                                                Task.WaitAll(TaskList.ToArray());

                                              //  OurAlgorthim(matrix, allshape);
                                               // ThreadPool.QueueUserWorkItem(state => OurAlgorthim(matrix, allshape));
                                                }
                                            }
                                        }
                                        else
                                        {
                                        shape[] copyarray = copyFun(allshape);
                                        List<Task> TaskList = new List<Task>();
                                        TaskList.Add(OurAlgorthim(matrix, copyarray));
                                        Task.WaitAll(TaskList.ToArray());

                                      
                                       
                                        }


                                        busyPosition[d][0] = 0;

                                    }
                                }

                                busyPosition[c][0] = 0;

                            }
                        }

                        busyPosition[pos][0] = 0;
                    } //end b
                    busyPosition[a][0] = 0;
                }// end a
            
        }

        /// <summary>
        /// algorthim take allshape is array contain 4/5 shape
        /// each shape have 12 shape
        /// algorthim try to put all shapes and if this led to solution or not
        /// if yes solution add this solution 
        /// if not try another shape
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="allshape"></param>

        public async Task OurAlgorthim(int[,] matrix, shape[] allshape)
        {

            for (int A = 0; A < 12; A++)
            {
                Game.checkInsert(matrix, allshape[0].pieces[A]);

                

                for (int B = 0; B < 12; B++)
                {

                    Game.checkInsert(matrix, allshape[1].pieces[B]);
                   

                    for (int C = 0; C < 12; C++)
                    {

                        Game.checkInsert(matrix, allshape[2].pieces[C]);
                        


                        for (int D = 0; D < 12; D++)
                        {


                            Game.checkInsert(matrix, allshape[3].pieces[D]);
                            
                           
                            if (this.NoShape == 4)
                            {


                                if (Game.solution(matrix))
                                {
                                    lock (CurrentNode)
                                    {
                                        CurrentNode.Push(allshape[0].pieces[A]);
                                        CurrentNode.Push(allshape[1].pieces[B]);
                                        CurrentNode.Push(allshape[2].pieces[C]);
                                        CurrentNode.Push(allshape[3].pieces[D]);
                                    }
                                    
                                    AddSolution(matrix, CurrentNode);
                                   // Console.WriteLine("loloolololololy");
                                    lock (CurrentNode)
                                    {
                                        CurrentNode.Clear();
                                    }

                                }//end if soluation
                               
                            }
                            else
                            {
                                for (int E = 0; E < 12; E++)
                                {

                                    Game.checkInsert(matrix, allshape[4].pieces[E]);
                                   
                                    if (Game.solution(matrix))
                                    {
                                        lock (CurrentNode)
                                        {
                                            CurrentNode.Push(allshape[0].pieces[A]);
                                            CurrentNode.Push(allshape[1].pieces[B]);
                                            CurrentNode.Push(allshape[2].pieces[C]);
                                            CurrentNode.Push(allshape[3].pieces[D]);
                                            CurrentNode.Push(allshape[4].pieces[E]);
                                        }
                                        AddSolution(matrix, CurrentNode);
                                        lock (CurrentNode)
                                        {
                                            CurrentNode.Clear();
                                        }
                                    } // end game sol
                                    Removeshape(matrix, allshape[4].value);
                                
                                }//end for E
                            }// else Noshape equal 5
                          Removeshape(matrix, allshape[3].value);
            

                        }//end D
                        Removeshape(matrix, allshape[2].value);
                     
                    }//end C
                    Removeshape(matrix, allshape[1].value);
                  
                }//end B

                Removeshape(matrix, allshape[0].value);
            
            }// end A
        }//end function
    }
    
}
