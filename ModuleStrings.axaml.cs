using System;
using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace labwork2
{
    public partial class ModuleStrings : Window
    {
        public ModuleStrings()
        {
            InitializeComponent();
        }
        private void CalculateButton2_Click(object sender, RoutedEventArgs e)
        {
            string input = inputTextBox2.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                resultTextBlock2.Text = "Пожалуйста, введите текст.";
                return;
            }

            if (!Regex.IsMatch(input, @"^[а-яА-Я\s]+$"))
            {
                resultTextBlock2.Text = "Пожалуйста, введите текст, содержащий только русские буквы.";
                return;
            }

            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            string reversed_string = string.Join(" ", words);
            resultTextBlock2.Text = reversed_string;
        }
    }
}