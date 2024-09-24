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
            string input_posled = inputTextBox3.Text;
            if (string.IsNullOrWhiteSpace(input_posled))
            {
                resultTextBlock3.Text = "Пожалуйста, введите строку.";
                return;
            }

            string[] numbers_str_posled = input_posled.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers_posled = new int[numbers_str_posled.Length];
            for (int i = 0; i < numbers_str_posled.Length; i++)
            {
                if (!int.TryParse(numbers_str_posled[i], out numbers_posled[i]))
                {
                    resultTextBlock3.Text = "Пожалуйста, введите строку, содержащую только целые числа.";
                    return;
                }
            }

            int max_length = 1;
            int start_index = 0;
            for (int i = 1; i < numbers_posled.Length; i++)
            {
                if (numbers_posled[i] % numbers_posled[i - 1] == 0)
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
                string result_posled = string.Join(" ", numbers_posled.Skip(start_index).Take(max_length));
                resultTextBlock3.Text = "Максимально длинная подпоследовательность: " + result_posled;
            }
        }
    }
}