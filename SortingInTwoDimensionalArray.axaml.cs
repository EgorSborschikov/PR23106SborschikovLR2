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
            string input_dimension = inputTextBox5.Text;
            string[] parts_dot = input_dimension.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int m = int.Parse(parts_dot[0]);
            int n = int.Parse(parts_dot[1]);

            _array = GenerateArray(m, n);
            string original_array = PrintArray(_array);
            string ascending_array = PrintArray(SortArray(_array, true));
            string descending_array = PrintArray(SortArray(_array, false));

            resultTextBlock5.Text = $"Исходный массив:\n{original_array}\n\nВ порядке возрастания:\n{ascending_array}\n\nВ порядке убывания:\n{descending_array}";
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

            int[] flat_array = array.Cast<int>().ToArray();
            Array.Sort(flat_array);

            if (!ascending)
            {
                Array.Reverse(flat_array);
            }

            int[,] sorted_array = new int[array.GetLength(0), array.GetLength(1)];
            int index_array = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sorted_array[i, j] = flat_array[index_array++];
                }
            }

            return sorted_array;
        }

        private string PrintArray(int[,] array)
        {
            string result_arrays = "";

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    result_arrays += array[i, j].ToString() + " ";
                }
                result_arrays += "\n";
            }

            return result_arrays;
        }
    }
}