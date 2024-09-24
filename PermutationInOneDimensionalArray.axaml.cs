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
            string input = inputTextBox4.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                resultTextBlock4.Text = "Пожалуйста, введите строку.";
                return;
            }

            string[] parts = input.Split('.');
            if (parts.Length < 2)
            {
                resultTextBlock4.Text = "Пожалуйста, введите строку в формате 'a1 a2 ... an.b'.";
                return;
            }

            string[] numbers_str = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[numbers_str.Length];
            for (int i = 0; i < numbers_str.Length; i++)
            {
                if (!int.TryParse(numbers_str[i], out numbers[i]))
                {
                    resultTextBlock4.Text = "Пожалуйста, введите строку, содержащую только целые числа.";
                    return;
                }
            }

            int b;
            if (!int.TryParse(parts[1], out b))
            {
                resultTextBlock4.Text = "Пожалуйста, введите число b.";
                return;
            }

            int index = 0;
            int j = numbers.Length - 1;

            while (index < j)
            {
                if (numbers[index] <= b)
                {
                    index++;
                }
                else if (numbers[j] > b)
                {
                    j--;
                }
                else
                {
                    int temp = numbers[index];
                    numbers[index] = numbers[j];
                    numbers[j] = temp;
                    index++;
                    j--;
                }
            }

            string result = string.Join(" ", numbers);
            resultTextBlock4.Text = "Переставленный массив: " + result;
        }
    }
}