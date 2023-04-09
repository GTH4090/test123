using Avalonia.Controls;
using Avalonia.Interactivity;
using KhrDesktop.Pages;
using static KhrDesktop.Classes.Helper;

namespace KhrDesktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Win = this;
        Navigationn = MainFrame;
        Navigationn.Content = new Auth();

    }

    private void ExitBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new Auth();
    }
}