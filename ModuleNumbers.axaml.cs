using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace labwork2
{
    public partial class ModuleNumbers : Window
    {
        public ModuleNumbers()
        {
            InitializeComponent();
        }
        private void CalculateButton1_Click(object sender, RoutedEventArgs e)
        {
            int number;
            if (int.TryParse(inputTextBox.Text, out number) && number <= 100 && number > 0)
            {
                long result = Calculate2nFactorial(number);
                resultTextBlock.Text = result.ToString();
            }
            else 
            {
                resultTextBlock.Text = "Некорректный ввод";
            }

        }

        private long Calculate2nFactorial(int number)
        {
            long result =1;
            for (int i=1; i<=number; i++)
            {
                result *= i;
            }
            long two_to_the_tower_of_number = (long)Math.Pow(2, number);
            long final_result = two_to_the_tower_of_number * result;
            return final_result;
        }
    }
}