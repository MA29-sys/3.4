using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace katalog;

public partial class DetailsScreen : UserControl
{
    private Action _showList = () => throw new InvalidOperationException(
        "Ekran szczegółów nie został skonfigurowany.");

    public DetailsScreen()
    {
        InitializeComponent();
    }

    public void Configure(CatalogItem item, Action showList)
    {
        _showList = showList;
        TitleText.Text = item.Title;
        YearText.Text = $"Rok wydania: {item.Year}";
        RatingText.Text = $"Ocena: {item.Rating}/10";
    }

    private void OnBackClick(object? sender, RoutedEventArgs e)
    {
        _showList();
    }
}
