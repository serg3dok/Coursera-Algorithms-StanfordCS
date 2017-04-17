using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
    class Program
    {
        //private List<Int32> n;
        protected int[] fNum;
        protected int[] sNum;
        protected int[,] addNumMatrix;
        protected string result;
        

        Program(string str1, string str2)
        {
            this.fNum = new int[str1.Length];
            for (int i = 0; i < fNum.Length; i++)
            {
                fNum[i] = int.Parse(str1.Substring(i,1));
            }

            this.sNum = new int[str2.Length];
            for (int i = 0; i < sNum.Length; i++)
            {
                sNum[i] = Int32.Parse(str2.Substring(i, 1));
            }

            addNumMatrix = new int[sNum.Length, sNum.Length + fNum.Length + 1];

            
        }


        public static void Main(string[] args)
        {
            Console.Write("first number: ");
            string input = Console.ReadLine();
            Console.Write("second number: ");
            string input2 = Console.ReadLine();

            Program mult = new Program(input, input2);
            
            mult.multiply(mult.fNum, mult.sNum);

            //mult.printOutMatrix(mult.addNumMatrix);

            mult.add(mult.addNumMatrix);

            
            Console.Write("result: ");
            Console.WriteLine(mult.result);
            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();

        }

        private void multiply(int[] fNum, int[] sNum)
        {
            int col;
            int row = 0;
            int shift = 0;
            for (int i = sNum.Length - 1; i >= 0; i--)
            {
                col = addNumMatrix.GetLength(1) - 1 - shift++;
                int mem = 0;
                for (int j = fNum.Length - 1; j >= 0; j--)
                {
                    if (col < 0) Console.WriteLine("k < 0"); // debug

                    int num = sNum[i] * fNum[j] + mem;

                    if (num > 9)
                    {
                        mem = num / 10;
                        num = num % 10;
                    }
                    else
                    {
                        mem = 0;
                    }

                    addNumMatrix[row,col--] = num;
                    
                }
                if (mem > 0) addNumMatrix[row, col--] = mem;
                row++;

            }
            
        }

        private void add(int[,] arrToAdd)
        {
            Stack<int> sum = new Stack<int>();

            int mem = 0;
            for (int i = arrToAdd.GetLength(1) - 1; i >= 0; i--)
                {

                
                int s = 0; // summ for current iteration
                s = s + mem;

                for (int j = 0; j < arrToAdd.GetLength(0); j++) // 
                {
                    s = s + arrToAdd[j, i];

                }

                if (s > 9)
                {
                    mem = s / 10;
                    s = s % 10;
                }
                else mem = 0;

                sum.Push(s);
                

            }

            if (mem != 0) sum.Push(mem);

            // Stack to string
            string strSum = "";

            while (sum.Peek() == 0)
            {
                // skip zeros
                sum.Pop();
            }

            while (sum.Count > 0)
            {
                strSum = strSum + sum.Pop();
            }

            result = strSum;
            //return strSum;
        }

        private void printOutMatrix(int[,] arr)
        {
            Console.WriteLine("arr: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
