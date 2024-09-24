using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace labwork2
{
    public partial class SearchInOneDimensionalArray : Window
    {
        public SearchInOneDimensionalArray()
        {
            InitializeComponent();
        }
        private void CalculateButton3_Click(object sender, RoutedEventArgs e)
        {
            string input = inputTextBox3.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                resultTextBlock3.Text = "Пожалуйста, введите строку.";
                return;
            }

            string[] numbers_str = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[numbers_str.Length];
            for (int i = 0; i < numbers_str.Length; i++)
            {
                if (!int.TryParse(numbers_str[i], out numbers[i]))
                {
                    resultTextBlock3.Text = "Пожалуйста, введите строку, содержащую только целые числа.";
                    return;
                }
            }

            int max_length = 1;
            int start_index = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] % numbers[i - 1] == 0)
                {
                    max_length++;
                }
                else
                {
                    if (max_length > 1)
                    {
                        start_index = i - max_length;
                        break;
                    }
                    max_length = 1;
                }
            }

            if (max_length == 1)
            {
                resultTextBlock3.Text = "Такая подпоследовательность не найдена.";
            }
            else
            {
                string result = string.Join(" ", numbers.Skip(start_index).Take(max_length));
                resultTextBlock3.Text = "Максимально длинная подпоследовательность: " + result;
            }
        }
    }
}