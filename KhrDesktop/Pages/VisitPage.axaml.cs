using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KhrDesktop.Pages;

public partial class VisitPage : UserControl
{
    public VisitPage()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}