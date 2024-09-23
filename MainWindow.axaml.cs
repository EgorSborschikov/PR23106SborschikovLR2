using Avalonia.Controls;
using Avalonia.Interactivity;

namespace labwork2;

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

}