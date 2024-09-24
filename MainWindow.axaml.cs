using Avalonia.Controls;
using Avalonia.Interactivity;

namespace labwork2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (MenuButton.ContextMenu != null)
            {
                MenuButton.ContextMenu.Open(MenuButton);
            }
        }

        private void Problem1_Click(object sender, RoutedEventArgs e)
        {
            ModuleNumbers window = new ModuleNumbers();
            window.Show();
        }
        private void Problem2_Click(object sender, RoutedEventArgs e)
        {
            ModuleStrings window = new ModuleStrings();
            window.Show();
        }
        private void Problem3_Click(object sender, RoutedEventArgs e)
        {
            SearchInOneDimensionalArray window = new SearchInOneDimensionalArray();
            window.Show();
        }
        private void Problem4_Click(object sender, RoutedEventArgs e)
        {
            PermutationInOneDimensionalArray window = new PermutationInOneDimensionalArray();
            window.Show();
        }
        private void Problem5_Click(object sender, RoutedEventArgs e)
        {
            SortingInTwoDimensionalArray window = new SortingInTwoDimensionalArray();
            window.Show();
        }
    }
}