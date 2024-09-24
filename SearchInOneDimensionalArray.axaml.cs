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

            string[] numbersStr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[numbersStr.Length];
            for (int i = 0; i < numbersStr.Length; i++)
            {
                if (!int.TryParse(numbersStr[i], out numbers[i]))
                {
                    resultTextBlock3.Text = "Пожалуйста, введите строку, содержащую только целые числа.";
                    return;
                }
            }

            int maxLength = 1;
            int startIndex = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] % numbers[i - 1] == 0)
                {
                    maxLength++;
                }
                else
                {
                    if (maxLength > 1)
                    {
                        startIndex = i - maxLength;
                        break;
                    }
                    maxLength = 1;
                }
            }

            if (maxLength == 1)
            {
                resultTextBlock3.Text = "Такая подпоследовательность не найдена.";
            }
            else
            {
                string result = string.Join(" ", numbers.Skip(startIndex).Take(maxLength));
                resultTextBlock3.Text = "Максимально длинная подпоследовательность: " + result;
            }
        }
    }
}