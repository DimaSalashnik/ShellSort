using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellSort
{
    class Program
    {
        static void Main(string[] args) => Process();

        static void Process() {
            Console.Write("Enter array elements: ");
            var arrayTemp = Console.ReadLine().Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try {
                var array = new int[arrayTemp.Length];
                for (int i = 0; i < arrayTemp.Length; i++)
                    array[i] = Convert.ToInt32(arrayTemp[i]);
                Console.WriteLine($"\nSorted array: {string.Join(", ", ShellSort(array))}");
                Repeat();
                return;
            }
            catch {
                Console.Clear();
                Console.WriteLine("Try again...\n");
                Process();
                return;
            }
        }

        static void Repeat() {
            Console.Write("Want to sort another array? (yes/no)  ");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes") {
                Console.Clear();
                answer = "";
                Process();
                return;
            }
            else if (answer == "no") {
                Console.WriteLine("Shutting down...");
                return;
            }
            else {
                answer = "";
                Console.Clear();
                Console.WriteLine("Try again...\n");
                Repeat();
                return;
            }
        }

        static int[] ShellSort(int[] array) {
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }

        static void Swap(ref int el1, ref int el2) {
            var temp = el1;
            el1 = el2;
            el2 = temp;
        }
    }
}
