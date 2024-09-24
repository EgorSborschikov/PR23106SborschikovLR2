using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace labwork2
{
    public partial class SortingInTwoDimensionalArray : Window
    {
        private int[,] _array;

        public SortingInTwoDimensionalArray()
        {
            InitializeComponent();
        }

        private void CalculateButton5_Click(object sender, RoutedEventArgs e)
        {
            string input = inputTextBox5.Text;
            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int m = int.Parse(parts[0]);
            int n = int.Parse(parts[1]);

            _array = GenerateArray(m, n);
            string originalArray = PrintArray(_array);
            string ascendingArray = PrintArray(SortArray(_array, true));
            string descendingArray = PrintArray(SortArray(_array, false));

            resultTextBlock5.Text = $"Исходный массив:\n{originalArray}\n\nВ порядке возрастания:\n{ascendingArray}\n\nВ порядке убывания:\n{descendingArray}";
        }
        private int[,] GenerateArray(int m, int n)
        {
            int[,] array = new int[m, n];
            Random random = new Random();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = random.Next(-10, 11);
                }
            }

            return array;
        }

        private int[,] SortArray(int[,] array, bool ascending)
        {

            int[] flatArray = array.Cast<int>().ToArray();
            Array.Sort(flatArray);

            if (!ascending)
            {
                Array.Reverse(flatArray);
            }

            int[,] sortedArray = new int[array.GetLength(0), array.GetLength(1)];
            int index = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sortedArray[i, j] = flatArray[index++];
                }
            }

            return sortedArray;
        }

        private string PrintArray(int[,] array)
        {
            string result = "";

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    result += array[i, j].ToString() + " ";
                }
                result += "\n";
            }

            return result;
        }
    }
}