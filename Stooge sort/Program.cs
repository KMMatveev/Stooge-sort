using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Stooge_sort
{
    internal class Program
    {
        

        static void Main()
        {
            long count = 0;

            //int[] GenerateMas(int n)
            //{
            //    int[] res = new int[n];
            //    Random random= new Random();
            //    for(int i=0;i<n;i++)
            //    {
            //        res[i] = random.Next(-100,100);
            //    }
            //    return res;
            //}

            //void PrintMas(int[]mas)
            //{
            //    foreach(int i in mas) 
            //    {
            //        Console.Write($"{i} ");
            //    }
            //    Console.WriteLine();
            //}

            //void WriteToNewFile(string text,string filename)
            //{
            //    FileStream fstream = new FileStream(filename, FileMode.Create);
            //    byte[] buffer = Encoding.Default.GetBytes(text);
            //    fstream.Write(buffer, 0, buffer.Length);
            //    fstream.Close();
            //}

            int[] ReadFromFile(string filename)
            {
                List<int> res = new List<int>();
                FileStream fstream = new FileStream(filename, FileMode.Open);
                byte[] buffer=new byte[fstream.Length];
                fstream.Read(buffer,0,Convert.ToInt32(fstream.Length));
                string text = Encoding.Default.GetString(buffer);
                foreach(string str in text.Split(','))
                {
                    res.Add(Convert.ToInt32(str));
                }
                fstream.Close();
                return res.ToArray();
            }

            void Results(string filename)
            {
                List<int> res = new List<int>();
                FileStream fstream = new FileStream(filename, FileMode.Open);
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, Convert.ToInt32(fstream.Length));
                string text = Encoding.Default.GetString(buffer);
                //var text2 = text.Split('\n');
                foreach (string str in text.Split('\n'))
                {
                    var x = (str.Split(',')[1]).Split('.');
                    Console.WriteLine(Convert.ToInt32(x[0])*3600+ Convert.ToInt32(x[1])*60+ Convert.ToInt32(x[2])+ Convert.ToInt32(x[3]) * Math.Pow(0.1, x[3].Length));
                    //Console.WriteLine((str.Split(',')[1]));
                }
                fstream.Close();
                return;
                //return res.ToArray();
            }

            //string TransformToText(int[]arr)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    foreach(int i in arr)
            //    {
            //        sb.Append($"{i},");
            //    }
            //    sb.Remove(sb.Length-1,1);
            //    return sb.ToString();
            //}

            //void GenerateFiles(int n)
            //{
            //    int c;
            //    int[] arr;
            //    string text;
            //    Random random= new Random();
            //    for (int i = 1; i < n+1; i++)
            //    {
            //        c = i * 100;
            //        arr = GenerateMas(c);
            //        text=TransformToText(arr);
            //        WriteToNewFile(text, $"{c}n");
            //    }
            //}

            void stoogesort0(int[] item, int left, int right)
            {
                count++;
                int tmp, k;
                if (item[left] > item[right])
                {
                    tmp = item[left];
                    item[left] = item[right];
                    item[right] = tmp;
                }
                if ((left + 1) >= right)
                    return;
                k = (int)((right - left + 1) / 3);
                stoogesort0(item, left, right - k); 
                stoogesort0(item, left + k, right); 
                stoogesort0(item, left, right - k);
            }

            //int stoogesort1(int[] item, int left, int right)
            //{
            //    int tmp, k;
            //    if (item[left] > item[right])
            //    {
            //        tmp = item[left];
            //        item[left] = item[right];
            //        item[right] = tmp;
            //    }
            //    if ((left + 1) >= right)
            //        return 1;
            //    k = (int)((right - left + 1) / 3);
            //    return stoogesort1(item, left, right - k)+stoogesort1(item, left + k, right)+stoogesort1(item, left, right - k);
            //}

            //////////////GenerateFiles(100);

            void ReadAndPrint()
            {
                for (int c = 1; c <= 100; c++)
                {
                    int[] array1 = ReadFromFile($"{c * 100}n");
                    //PrintMas(array1);
                    DateTime start = DateTime.Now;
                    //var iter = stoogesort1(array1, 0, array1.Length - 1);ь
                    stoogesort0(array1, 0, array1.Length - 1);
                    var time = DateTime.Now - start;
                    //PrintMas(array1);
                    Console.WriteLine($"{c * 100} : {time} ({count})");
                    count = 0;
                }
            }

            ///Results("S.txt");

            Console.ReadKey();
        }
    }
}
