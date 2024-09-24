using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace labwork2
{
    public partial class PermutationInOneDimensionalArray : Window
    {
        public PermutationInOneDimensionalArray()
        {
            InitializeComponent();
        }

        private void CalculateButton4_Click(object sender, RoutedEventArgs e)
        {
            string input_array_and_border = inputTextBox4.Text;
            if (string.IsNullOrWhiteSpace(input_array_and_border))
            {
                resultTextBlock4.Text = "Пожалуйста, введите строку.";
                return;
            }

            string[] parts_with_dot = input_array_and_border.Split('.');
            if (parts_with_dot.Length < 2)
            {
                resultTextBlock4.Text = "Пожалуйста, введите строку в формате 'a1 a2 ... an.b'.";
                return;
            }

            string[] numbers_str_array = parts_with_dot[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers_in_array = new int[numbers_str_array.Length];
            for (int i = 0; i < numbers_str_array.Length; i++)
            {
                if (!int.TryParse(numbers_str_array[i], out numbers_in_array[i]))
                {
                    resultTextBlock4.Text = "Пожалуйста, введите строку, содержащую только целые числа.";
                    return;
                }
            }

            int b;
            if (!int.TryParse(parts_with_dot[1], out b))
            {
                resultTextBlock4.Text = "Пожалуйста, введите число b.";
                return;
            }

            int index_array = 0;
            int j = numbers_in_array.Length - 1;

            while (index_array < j)
            {
                if (numbers_in_array[index_array] <= b)
                {
                    index_array++;
                }
                else if (numbers_in_array[j] > b)
                {
                    j--;
                }
                else
                {
                    int temp = numbers_in_array[index_array];
                    numbers_in_array[index_array] = numbers_in_array[j];
                    numbers_in_array[j] = temp;
                    index_array++;
                    j--;
                }
            }

            string result_array = string.Join(" ", numbers_in_array);
            resultTextBlock4.Text = "Переставленный массив: " + result_array;
        }
    }
}