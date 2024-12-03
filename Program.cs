using System;

namespace c_sharp_interface_1
{//lab

    //ex-1
    interface IOutput
    {
        void Show();
        void Show(string info);
    }

    //ex-2
    interface IMath {
        int Max();
        int Min();
        float Avg();
        bool Search(int ValueToSearch);
    }

    //ex-3
    interface ISort {
        void SortAsc();
        public void SortDesc()
        {
        }
        public void SortByParam(bool isAsc)
        {
        }

    }

    public class Array : IOutput, IMath, ISort
    {
        private int[] elements;

        public Array(int[] elements)
        {
            this.elements = elements;
        }

        //ex-1
        public void Show()
        {
            foreach (var element in elements)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        public void Show(string info)
        {
            Console.WriteLine(info);
            Show();
        }

        //ex-2
        public int Max()
        {
            int max = elements[0];
            foreach (var element in elements)
            {
                if (element > max)
                {
                    max = element;
                }
            }
            return max;
        }

        public int Min()
        {
            int min = elements[0];
            foreach (var element in elements)
            {
                if (element < min)
                {
                    min = element;
                }
            }
            return min;
        }

        public float Avg()
        {
            float sum = 0;
            foreach (var element in elements)
            {
                sum += element;
            }
            return sum / elements.Length;
        }

        public bool Search(int ValueToSearch)
        {
            foreach (var element in elements)
            {
                if (element == ValueToSearch)
                {
                    return true;
                }
            }
            return false;
        }

        //ex-3
        public void SortAsc()
        {
            System.Array.Sort(elements);
        }

        public void SortDesc()
        {
            SortAsc();
            System.Array.Reverse(elements);
        }
        public void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }

    }

    internal class Program
    {
        static void Main()
        {
            var random = new Random();
            var numbers = new int[5];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 10);
            }

            Array array = new Array(numbers);

            //ex-1
            array.Show();
            array.Show("Array elements:");


            //ex-2
            Console.WriteLine("Max: " + array.Max());
            Console.WriteLine("Min: " + array.Min());
            Console.WriteLine("Avg: " + array.Avg());
            Console.WriteLine("Search 3: " + array.Search(3));

            //ex-3
            array.SortAsc();
            array.Show("Sorted Ascending:");
            array.SortDesc();
            array.Show("Sorted Descending:");
            array.SortByParam(true);
            array.Show("Sorted Ascending:");
            array.SortByParam(false);
            array.Show("Sorted Descending:");
        }
    }
}
