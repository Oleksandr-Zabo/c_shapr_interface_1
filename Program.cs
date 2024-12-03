using System;

namespace c_sharp_interface_1
{//lab + hw

    //lab ex-1
    interface IOutput
    {
        void Show();
        void Show(string info);
    }

    //lab ex-2
    interface IMath {
        int Max();
        int Min();
        float Avg();
        bool Search(int ValueToSearch);
    }

    //lab ex-3
    interface ISort {
        void SortAsc();
        public void SortDesc()
        {
        }
        public void SortByParam(bool isAsc)
        {
        }

    }

    //hw ex-1
    interface ICalc {
        int Less(int valueToCompare);
        int Greater(int valueToCompare);

    }

    //hw ex-2
    interface IOutput2 {
        void ShowEven();
        void ShowOdd();
    }

    //hw ex-3
    interface ICalc2
    {
        int CountDistinct();
        int EqualToValue(int valueToCompare);
    }

    public class Array : IOutput, IMath, ISort, ICalc, IOutput2, ICalc2
    {
        private int[] elements;

        public Array(int[] elements)
        {
            this.elements = elements;
        }

        //lab ex-1
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

        //lab ex-2
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

        //lab ex-3
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

        //hw ex-1
        public int Less(int valueToCompare)
        {
            int count = 0;
            foreach (var element in elements)
            {
                if (element < valueToCompare)
                {
                    count++;
                }
            }
            return count;
        }
        public int Greater(int valueToCompare)
        {
            int count = 0;
            foreach (var element in elements)
            {
                if (element > valueToCompare)
                {
                    count++;
                }
            }
            return count;
        }

        //hw ex-2
        public void ShowEven()
        {
            foreach (var element in elements)
            {
                if (element % 2 == 0)
                {
                    Console.Write(element + " ");
                }
            }
            Console.WriteLine();
        }
        public void ShowOdd()
        {
            foreach (var element in elements)
            {
                if (element % 2 != 0)
                {
                    Console.Write(element + " ");
                }
            }
            Console.WriteLine();
        }

        //hw ex-3
        public int CountDistinct()
        {
            int count = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                bool isDistinct = true;
                for (int j = 0; j < elements.Length; j++)
                {
                    if (elements[i] == elements[j] && i != j) 
                    {
                        isDistinct = false;
                        break;
                    }
                }
                if (isDistinct)
                {
                    count++;
                }
            }
            return count;
        }

        public int EqualToValue(int valueToCompare)
        {
            int count = 0;
            foreach (var element in elements)
            {
                if (element == valueToCompare)
                {
                    count++;
                }
            }
            return count;
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

            //lab ex-1
            array.Show();
            array.Show("Array elements:");


            //lab ex-2
            Console.WriteLine("Max: " + array.Max());
            Console.WriteLine("Min: " + array.Min());
            Console.WriteLine("Avg: " + array.Avg());
            Console.WriteLine("Search 3: " + array.Search(3));

            //lab ex-3
            array.SortAsc();
            array.Show("Sorted Ascending:");
            array.SortDesc();
            array.Show("Sorted Descending:");
            array.SortByParam(true);
            array.Show("Sorted Ascending:");
            array.SortByParam(false);
            array.Show("Sorted Descending:");

            //hw ex-1
            Console.WriteLine("Less than 5: " + array.Less(5));
            Console.WriteLine("Greater than 5: " + array.Greater(5));

            //hw ex-2
            Console.WriteLine("Even: ");
            array.ShowEven();
            Console.WriteLine("Odd: ");
            array.ShowOdd();

            //hw ex-3
            Console.WriteLine("Distinct: " + array.CountDistinct());
            Console.WriteLine("Equal to 5: " + array.EqualToValue(5));
        }
    }
}
